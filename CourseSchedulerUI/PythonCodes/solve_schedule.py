#!/usr/bin/env python
# Uses PuLP to generate plausible completions for a partial schedule.
# Provided under the terms of the MIT License, as stated in LICENSE.txt.

from course_selection import Preferences, Schedule, read_combined_file
from check_schedule import print_conflict_report, print_student_report

from pulp import *
import pulp as pl
from progressbar import ProgressBar

from optparse import OptionParser
import sys
import string

# Helper function that isn't in Python, but should have been:

# NOTE: only flattens one level, unlike the common definition.
def flatten(l):
  out = []
  for item in l:
    if isinstance(item, (list, tuple)):
        # out.extend(flatten(item))
        out.extend(item)
    else:
        out.append(item)
  return out

# Actual logic relating to schedule generation:

def format_schedules_html(offering, schedule, num_conflicts, preferences, opts, consolidate=True):
    slotlist = schedule.slotlist
    if num_conflicts is None:
        num_conflicts = 0
    
    if num_conflicts < 0: # The caller might not know this...
        header = "Results of Course Scheduling"
    else:
        header = "Results of Course Scheduling, %d Conflict%s" \
            % (num_conflicts, "" if num_conflicts == 1 else "s")

    print ("<html>")
    print ("<head>")
    print ("<title>" + header + "</title>")
    print ("<style>table, th, td { border: 1px solid black; }</style>")
    print ("</head>")
    print ("<body>")
    print ("<h1>" + header + "</h1>")
    print ("<table>")

    # Consolidate columns where teacher only teaches one course:
    teachers, misc_courses = [], []
    if consolidate:
        teachers = sorted(filter(lambda k: len(offering.people[k]) != 1, offering.people.keys()))
        misc_courses = sorted(filter(lambda p: len(p[1]) == 1, offering.people.items()))
    else:
        teachers = sorted(offering.people.keys())

    # header row
    print ("  <tr>")
    print ("    <td><strong>Timeslots</strong></td>")
    for teacher in teachers:
        print ("    <td><strong>" + teacher + "</strong></td>")
    if consolidate: print ("    <td><strong>Misc Courses</strong></td>")
    # TODO Include column for the conflict summary
    print ("  </tr>")

    def timeslot_key(row):
        slot, _stuff = row
        return slotlist.index(slot)
    schedule_rows = schedule.timeslots.items()
    schedule_rows = sorted(schedule_rows, key = timeslot_key) # -- show rows in correct order!

    # timeslot rows
    for slot, row in schedule_rows:
        print ("  <tr>")
        print ("    <td>" + slot +"</td>")

        # per-teacher columns
        for teacher in teachers:
            if teacher not in row: # -- empty schedule slot:
                print ("    <td>&nbsp;</td>")
            else:
                print ("    <td>" + row[teacher] + "</td>")

        # "Misc Courses" column:
        if consolidate:
            print ("    <td>")
            for teacher, courses in misc_courses:
                course = courses[0]
                if teacher in row:
                    print ("<strong>" + teacher + "</strong>: " + row[teacher] + "<br/>")
            print ("    &nbsp;</td>")
        print ("  </tr>")

    print ("</table>")
    print ("</body>")
    print ("</html>")

def format_schedules(offering, schedule, num_conflicts, slotlist, preferences, opts):
    slotlist = schedule.slotlist
    if num_conflicts is None:
        num_conflicts = 0
    # Print solution header:
    if num_conflicts == 1:
        cfl_str = "conflict"
    else:
        cfl_str = "conflicts"
    print ("Solution, %d %s:" % (num_conflicts, cfl_str))
    print ("===") # marker for check_schedule.py

    # Print the schedule - determine column widths and format a table:
    teachers = sorted(offering.people.keys())
    col_widths = [len("Timeslots")] + [len(t) for t in teachers]
    for slot, row in schedule.timeslots.items():
        col_widths[0] = max(col_widths[0], len(slot))
        for teacher, course in row.items():
            i = teachers.index(teacher) + 1
            col_widths[i] = max(col_widths[i], len(course))

    line = "Timeslots".ljust(col_widths[0])
    for teacher in teachers:
        i = teachers.index(teacher) + 1
        line += " / " + teacher.ljust(col_widths[i])
    print (line)

    def timeslot_key(row):
        slot, _stuff = row
        return slotlist.index(slot)
    schedule_rows = schedule.timeslots.items()
    schedule_rows = sorted(schedule_rows, key=timeslot_key)
    #schedule_rows.sort(key=timeslot_key) # -- show rows in correct order!

    for slot, row in schedule_rows:
        line = slot.ljust(col_widths[0])
        for teacher in teachers:
            i = teachers.index(teacher) + 1
            if teacher not in row: # -- empty schedule slot:
                line += " / " + "-".ljust(col_widths[i])
            else:
                line += " / " + row[teacher].ljust(col_widths[i])
        print (line)
    print ("===") # marker for check_schedule.py
    print ("") # -- extra newline.

    if opts.show_conflicts:
        if opts.by_student:
            print_student_report(preferences, schedule)
        else:
            print_conflict_report(preferences, schedule)

def gen_schedules(offering, preferences, schedule, opts):
  all_teachers = set(flatten(offering.people.keys()))
  all_students = set(flatten(preferences.people.keys()))
  all_courses = set(flatten([[c for c, _c in l] for l in offering.people.values()]))
  classlists = preferences.classes # -- courses that were actually requested.
  all_slots = schedule.slotlist

  prob = LpProblem("Course Scheduling", LpMinimize)

  ## Define variables:

  # scheduled[slot, course] == 1 : course scheduled in slot.
  names = [s+"_"+c for s in all_slots for c in all_courses]
  scheduled = LpVariable.dicts("Scheduled_", names, 0, 1, LpInteger)
  def get_scheduled(s, c): return scheduled[s+"_"+c]

  # conflict[course1, course2] == 1 : courses in same slot.
  names = [c1+"_"+c2 for c1 in all_courses for c2 in all_courses]
  conflict = LpVariable.dicts("Conflict_", names, 0, 1, LpInteger)
  def get_conflict(c1, c2): return conflict[c1+"_"+c2]

  print ("Created %d schedule variables and %d conflict variables." \
      % (len(all_slots)*len(all_courses), len(all_courses)*len(all_courses)))

  ## Define objective function:

  # overlap[course1, course2] == number of students taking both courses.
  overlap, total_conflicts = {}, 0
  for course1 in all_courses:
    if course1 not in classlists: continue # -- no one was interested.
    for course2 in all_courses:
      if course2 not in classlists: continue # -- no one was interested.
      if course1 == course2: continue # -- a course can't conflict with itself.
      overlap_size = len(classlists[course1]&classlists[course2])
      overlap[course1, course2] = overlap_size
      # sometimes we need to deprioritize a course to gain extra flexibility
      #if course1 == "Drama" or course2 == "Drama": overlap_size /= 10.0
      if overlap_size > 0: # -- there could be actual conflicts here:
        total_conflicts += (overlap_size/2.0) * get_conflict(course1, course2)
        # ... division by 2.0 is necessary to avoid counting conflicts twice.
  # print overlap # TODO formatting an overlap list may be useful!
  def get_overlap(c1, c2): return overlap[c1, c2]
  prob += total_conflicts, "minimize the number of conflicts."
  
  print ("Calculated %d course overlaps and objective function." \
      % (len(all_courses)*len(all_courses)))

  print ("")

  ## Define constraints:

  print ("Defining constraints:")

  print ("(1) every course is scheduled in exactly one slot")
  pbar, i = ProgressBar(len(all_slots)*len(all_courses)).start(), 0
  for course in all_courses:
    places_scheduled = 0
    for slot in all_slots:
      places_scheduled += get_scheduled(slot, course)
      i = i+1; pbar.update(i) # -- display a progress bar.
    prob += places_scheduled == 1, "%s sched." % (course)
  pbar.finish()

  print ("(2) absolutely no course conflicts for the teachers")
  pbar, i = ProgressBar(len(all_teachers) * len(all_slots)).start(), 0
  for teacher in all_teachers:
    for slot in all_slots:
      courses_in_slot = 0
      for course, _comment in offering.people[teacher]:
        # course_no = all_courses.index(course)
        courses_in_slot += get_scheduled(slot, course)
      prob += courses_in_slot <= 1, "%s no conf. at %s" % (teacher, slot)
      i = i+1; pbar.update(i) # -- display a progress bar.
  pbar.finish()

  print ("(3) our conflict table contains correct values")
  pbar, i = \
      ProgressBar(len(all_courses)*len(all_courses)*len(all_slots)).start(), 0
  for course1 in all_courses:
    if course1 not in classlists: continue # -- no one was interested.
    for course2 in all_courses:
      # Check if an actual conflict here is even possible:
      if course2 not in classlists: continue # -- no one was interested.
      if course1 == course2: continue # -- a course can't conflict with itself.
      if get_overlap(course1, course2) == 0: continue

      # ... and then define the actual constraint for each slot:
      for slot in all_slots:
        comment_str = "%s and %s conf. at %s" % (course1, course2, slot)
        lhs = get_scheduled(slot, course1) + get_scheduled(slot, course2) - 1
        prob += lhs <= get_conflict(course1, course2), comment_str
        i = i+1; pbar.update(i)
  pbar.finish()

  print ("(4) existing scheduled entries are in the solution [constraints]")
  for slot, course_map in schedule.timeslots.items():
    for course in course_map.values():
      comment_str = "%s sched. at %s" % (slot, course)
      prob += get_scheduled(slot, course) == 1

  if True:
    print ("(5) EXPERIMENTAL 'teacher can't come in' constraints")
    for teacher, items in schedule.bad_slots.items():
      for slot in items:
        for course, _comment in offering.people[teacher]:
          print ("CONSTRAINT %s : %s no %s" % (teacher, slot, course))
          comment_str = "%s not sched. at %s since teach away" % (slot, course)
          prob += get_scheduled(slot, course) == 0

  ## Solve the problem and return the solution:

  ## MAKE SURE TO USE GLPK SOLVER ON SCHOOL COMPUTERS TODO NO THAT WON'T WORK:
  # solver = solvers.PULP_CBC_CMD(maxSeconds=int(opts.time_limit)*60)
  # solver = solvers.COIN_CMD(maxSeconds=int(opts.time_limit)*60)
  #print(pl.pulpTestAll())
  solver = pl.getSolver('PULP_CBC_CMD')
  # solver = solvers.GLPK(options=['--tmlim', str(opts.time_limit), '--nopresol'])
  prob.solve(solver=solver)

  # If no solution was found, abort:
  #if LpStatus[prob.status] != "Optimal":
  #  print "ERROR: Linear solver returned '%s'.\n" % LpStatus[prob.status]
  #  return []

  # Build a schedule from the resulting solution:
  resulting_schedule = Schedule()
  for slot in all_slots:
    for course in all_courses:
      if get_scheduled(slot, course).varValue == 1:
        the_teacher = None
        for teacher in all_teachers:
          course_lst = [a for a, b in offering.people[teacher]]
          if course in course_lst:
            the_teacher = teacher
            break
        resulting_schedule.add(the_teacher, course, slot)
  resulting_schedule.slotlist = schedule.slotlist

  # Return our (single) solution:
  num_conflicts = value(prob.objective)
  return (resulting_schedule, num_conflicts,)

  # TODO - add constraints for obtaining multiple solutions and solve again...

if __name__=="__main__":
    usage = "%prog <preferences> <teacher info> <partial schedule>\n%prog -p <preference file> <partial schedule>"
    parser = OptionParser(usage=usage)

    # parser.add_option('-c', '--show-conflicts', action="store_true",
    #                  default=True, help="print detailed conflict info")

    parser.add_option('-t', '--solver-time', dest="time_limit", default="4",
                      help="time to spend looking for solution, in minutes")
    parser.add_option('-s', '--by-student', action="store_true", \
                      default=False, \
                      help="print conflict report by student, not by course")

    # New 'single file' mode:
    parser.add_option('-p', '--preferences', dest="preference_file", default="", \
                     help="obtain student and teacher preferences for single file")

    # New 'output file' option:
    parser.add_option('-o', '--outfile', dest="output_file", default="", \
                          help="also write results in plaintext to this file")
    parser.add_option('-H', '--html', dest="html_output_file", default="", \
                          help="also write results in HTML format to this file")

    (opts, args) = parser.parse_args()
    opts.show_conflicts = True # we ALWAYS want to see the conflicts

    if opts.preference_file != "":
      if len(args) != 1:
        parser.error("1 argument required with option '-p': schedule")
      selection_file = args[0]
      offering, preferences = read_combined_file(opts.preference_file)
      schedule = Schedule(selection_file)
    else:
      if len(args) != 3:
        parser.error("3 arguments required: students, teachers, and schedule")
      data_dir, off_dir, selection_file = args[0], args[1], args[2]
      offering = Preferences(off_dir) # -- courses offered by teachers.
      preferences, schedule = Preferences(data_dir), Schedule(selection_file)

    # In case a sanity check is needed:
    # print str(offering.people) + " " + str(offering.classes)
    # print str(preferences.people) + " " + str(preferences.classes)

    schedule, num_conflicts = gen_schedules(offering, preferences, schedule, opts)
    print ("\n") # -- visual separation from the solver output above
    format_schedules(offering, schedule, num_conflicts, schedule.slotlist, preferences, opts)

    # Also save to file, if needed:
    if opts.output_file != "":
      outfile = open(opts.output_file, "w")
      # XXX I really can't vouch for this redirection hack:
      with outfile as sys.stdout:
        format_schedules(offering, schedule, num_conflicts, schedule.slotlist, preferences, opts)
      sys.stdout = sys.__stdout__
      print ("")
      print ("(also wrote raw output to " + opts.output_file + ")")
    if opts.html_output_file != "":
      outfile = open(opts.html_output_file, "w")
      # XXX redirection hack again
      with outfile as sys.stdout:
        format_schedules_html(offering, schedule, num_conflicts, preferences, opts)
      sys.stdout = sys.__stdout__
      print ("")
      print ("(also wrote HTML output to " + opts.html_output_file + ")")
