using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseSchedulerUI.Models;

namespace CourseSchedulerUI
{
    public partial class Form1 : Form
    {
        private bool browserCreated = false;
        private List<Tuple<string, List<string>>> courseTeacher = new List<Tuple<string, List<string>>>();
        private List<Tuple<string, List<string>>> courseStudent = new List<Tuple<string, List<string>>>();
        private List<Models.Constraint> constraints = new List<Models.Constraint>();
        private object[] hourList = new object[] {
            "8:00am",
            "9:00am",
            "10:00am",
            "11:00am",
            "12:00am",
            "1:00pm",
            "2:00pm",
            "3:00pm",
            "4:00pm",
            "5:00pm"};



        public Form1()
        {
            InitializeComponent();
            this.cbHour.Items.AddRange(hourList);
            this.tabControl1.SelectedIndex = 0;
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            if (!lstCourses.Items.Contains(txtCourseName.Text) && !String.IsNullOrEmpty(txtCourseName.Text))
            {
                lstCourses.Items.Add(txtCourseName.Text);

            }

            //if (!lbNotAddedCourses.Items.Contains(txtCourseName.Text))
            //{
            //    lbNotAddedCourses.Items.Add(txtCourseName.Text);

            //}
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            if (!lstTeacher.Items.Contains(txtTeacherName.Text) && !String.IsNullOrEmpty(txtTeacherName.Text))
            {
                lstTeacher.Items.Add(txtTeacherName.Text);
            }
            if (!cbTeacher.Items.Contains(txtTeacherName.Text) && !String.IsNullOrEmpty(txtTeacherName.Text))
            {
                cbTeacher.Items.Add(txtTeacherName.Text);
            }
            if (!cbTeacherCons.Items.Contains(txtTeacherName.Text) && !String.IsNullOrEmpty(txtTeacherName.Text))
            {
                cbTeacherCons.Items.Add(txtTeacherName.Text);
            }
        }

        private void btnAddCourseTeacher_Click(object sender, EventArgs e)
        {
            if (lbNotAddedCourses.SelectedItem != null && cbTeacher.SelectedItem != null)
            {
                var theTeacher = cbTeacher.SelectedItem.ToString();
                var theSelectedCourse = lbNotAddedCourses.SelectedItem.ToString();
                lbNotAddedCourses.Items.Remove(theSelectedCourse);
                lbAddedCourses.Items.Add(theSelectedCourse);

                if (!courseTeacher.Any(c => c.Item1 == theTeacher))
                {
                    courseTeacher.Add(new Tuple<string, List<string>>(theTeacher, new List<string> { theSelectedCourse }));
                }
                else
                {
                    var listItem = courseTeacher.FirstOrDefault(c => c.Item1 == theTeacher);
                    listItem.Item2.Add(theSelectedCourse);
                }
            }

        }

        private void btnRemoveCourseFromTeacher_Click(object sender, EventArgs e)
        {
            if (lbAddedCourses.SelectedItem != null && cbTeacher.SelectedItem != null)
            {
                var theTeacher = cbTeacher.SelectedItem.ToString();
                var theSelectedCourse = lbAddedCourses.SelectedItem.ToString();
                lbNotAddedCourses.Items.Add(theSelectedCourse);
                lbAddedCourses.Items.Remove(theSelectedCourse);

                if (courseTeacher.Any(c => c.Item1 == theTeacher))
                {
                    var listItem = courseTeacher.FirstOrDefault(c => c.Item1 == theTeacher);
                    listItem.Item2.Remove(listItem.Item2.Single(i => i == theSelectedCourse));
                }
            }

        }

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbAddedCourses.Items.Clear();
            lbNotAddedCourses.Items.Clear();
            var theTeacher = cbTeacher.SelectedItem.ToString();
            var listItem = courseTeacher.FirstOrDefault(c => c.Item1 == theTeacher);
            var courses = lstCourses.Items.Cast<String>().ToList();
            if (listItem != null)
            {

                lbAddedCourses.Items.AddRange(listItem.Item2.Cast<object>().ToArray());
                lbNotAddedCourses.Items.AddRange(courses.Where(p => listItem.Item2.All(p2 => p2 != p)).Cast<object>().ToArray());
            }
            else
            {
                lbNotAddedCourses.Items.AddRange(courses.Cast<object>().ToArray());

            }
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            try
            {
                var path = AppDomain.CurrentDomain.BaseDirectory;//System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                path = path.Replace("\\", "/");
                path += "/sample_preference_files/Example.txt"; //@"C:\Users\user\Desktop\course-scheduler-master\sample_preference_files\Example.txt";
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();

                    using (TextWriter tw = new StreamWriter(path))
                    {
                        foreach (var item in courseTeacher)
                        {
                            tw.WriteLine(item.Item1 + ": " + string.Join(", ", item.Item2));

                        }

                        tw.WriteLine("----");
                        var courses = courseStudent.SelectMany(c => c.Item2).Select(o => o).Distinct();
                        if (!courses.Any())
                        {
                            MessageBox.Show("Please select Student for Course");
                            return;
                        }
                        var last = courses.Last();
                        foreach (var course in courses)
                        {
                            var students = courseStudent.SelectMany(c => c.Item2).Where(o => o.Contains(course)).Select(o => o).Distinct();
                            if (course == last)
                            {
                                tw.Write(course + ": " + string.Join(", ", students));

                            }
                            else
                            {
                                tw.WriteLine(course + ": " + string.Join(", ", students));

                            }

                        }
                    }

                }
                else if (File.Exists(path))
                {
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        foreach (var item in courseTeacher)
                        {
                            tw.WriteLine(item.Item1 + ": " + string.Join(", ", item.Item2));

                        }

                        tw.WriteLine("----");

                        var courses = courseStudent.SelectMany(c => c.Item2).Select(o => o).Distinct();
                        if (!courses.Any())
                        {
                            MessageBox.Show("Please select Student for Course");
                            return;
                        }
                        var last = courses.Last();
                        foreach (var course in courses)
                        {
                            var students = courseStudent.Where(o => o.Item2.Contains(course)).Select(o => o.Item1).Distinct();
                            if (course == last)
                            {
                                tw.Write(course + ": " + string.Join(", ", students));

                            }
                            else
                            {
                                tw.WriteLine(course + ": " + string.Join(", ", students));

                            }

                        }
                    }
                }

                MessageBox.Show("Matching has been completed successfully");
            }
            catch (Exception)
            {

                MessageBox.Show("An exception occured");
            }

        }

        private void cbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbAddedCoursesStd.Items.Clear();
            lbNotAddedCoursesStd.Items.Clear();
            var theStudent = cbStudents.SelectedItem.ToString();
            var listItem = courseStudent.FirstOrDefault(c => c.Item1 == theStudent);
            var courses = lstCourses.Items.Cast<String>().ToList();
            if (listItem != null)
            {

                lbAddedCoursesStd.Items.AddRange(listItem.Item2.Cast<object>().ToArray());
                lbNotAddedCoursesStd.Items.AddRange(courses.Where(p => listItem.Item2.All(p2 => p2 != p)).Cast<object>().ToArray());
            }
            else
            {
                lbNotAddedCoursesStd.Items.AddRange(courses.Cast<object>().ToArray());

            }
        }

        private void btnAddCourseStd_Click(object sender, EventArgs e)
        {
            if (lbNotAddedCoursesStd.SelectedItem != null && cbStudents.SelectedItem != null)
            {
                var theStudent = cbStudents.SelectedItem.ToString();
                var theSelectedCourse = lbNotAddedCoursesStd.SelectedItem.ToString();
                lbNotAddedCoursesStd.Items.Remove(theSelectedCourse);
                lbAddedCoursesStd.Items.Add(theSelectedCourse);

                if (!courseStudent.Any(c => c.Item1 == theStudent))
                {
                    courseStudent.Add(new Tuple<string, List<string>>(theStudent, new List<string> { theSelectedCourse }));
                }
                else
                {
                    var listItem = courseStudent.FirstOrDefault(c => c.Item1 == theStudent);
                    listItem.Item2.Add(theSelectedCourse);
                }
            }
        }

        private void btnRemoveCourseStd_Click(object sender, EventArgs e)
        {
            if (lbAddedCoursesStd.SelectedItem != null && cbStudents.SelectedItem != null)
            {
                var theStudent = cbStudents.SelectedItem.ToString();
                var theSelectedCourse = lbAddedCoursesStd.SelectedItem.ToString();
                lbNotAddedCoursesStd.Items.Add(theSelectedCourse);
                lbAddedCoursesStd.Items.Remove(theSelectedCourse);

                if (courseStudent.Any(c => c.Item1 == theStudent))
                {
                    var listItem = courseStudent.FirstOrDefault(c => c.Item1 == theStudent);
                    listItem.Item2.Remove(listItem.Item2.Single(i => i == theSelectedCourse));
                }
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (!lbStudents.Items.Contains(txtStudent.Text) && !String.IsNullOrEmpty(txtStudent.Text))
            {
                lbStudents.Items.Add(txtStudent.Text);
            }
            if (!cbStudents.Items.Contains(txtStudent.Text) && !String.IsNullOrEmpty(txtStudent.Text))
            {
                cbStudents.Items.Add(txtStudent.Text);
            }
        }

        private void cbTeacherCons_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCourseConstraint.Items.Clear();
            cbCourseConstraint.SelectedItem = null;
            cbCourseConstraint.SelectedText = null;
            cbCourseConstraint.SelectedIndex = -1;
            var selectetedTeeach = cbTeacherCons.SelectedItem.ToString();
            var item = courseTeacher.FirstOrDefault(c => c.Item1 == selectetedTeeach);
            if (item != null)
            {
                cbCourseConstraint.Items.AddRange(item.Item2.Cast<object>().ToArray());
            }
        }

        private void btnAddDayConstraint_Click(object sender, EventArgs e)
        {
            if (cbDays.SelectedItem == null)
            {
                MessageBox.Show("Please select a day first");
                return;
            }
            if (cbHour.SelectedItem == null)
            {
                MessageBox.Show("Please select an hour");
                return;
            }
            if (cbTeacherCons.SelectedItem == null)
            {
                MessageBox.Show("Please select a Teacher");
                return;
            }
            if (cbCourseConstraint.SelectedItem == null)
            {
                MessageBox.Show("Please select a Course");
                return;
            }

            var selecteedHour = cbHour.SelectedItem.ToString();
            var selectedTeacher = cbTeacherCons.SelectedItem.ToString();
            var selectedCourse = cbCourseConstraint.SelectedItem.ToString();
            var selectedDay = cbDays.SelectedItem.ToString();

            if (constraints.Any(c => c.Day == selectedDay &&
                                     c.Course == selectedCourse &&
                                     c.Hour == selecteedHour &&
                                     c.Teacher == selectedTeacher))
            {
                MessageBox.Show("This constraint was added");
                return;
            }

            if (String.IsNullOrEmpty(rtbConstraint.Text))
            {
                rtbConstraint.AppendText(String.Format("{0}-{1}-{2}", selecteedHour, selectedTeacher, selectedCourse));

            }
            else
            {
                rtbConstraint.AppendText(Environment.NewLine + String.Format("{0}-{1}-{2}", selecteedHour, selectedTeacher, selectedCourse));

            }

            constraints.Add(new Models.Constraint
            {
                Day = selectedDay,
                Hour = selecteedHour,
                Course = selectedCourse,
                Teacher = selectedTeacher
            });


        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbDaysReport.SelectedItem == null)
                {
                    MessageBox.Show("Please select a day first");
                    return;
                }
                var day = cbDaysReport.SelectedItem.ToString();
                var path = AppDomain.CurrentDomain.BaseDirectory;//System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                path = path.Replace("\\", "/");
                //var days = constraints.Select(o => o.Day).Distinct();
                if (!File.Exists(path + "/sample_schedule_templates/"+ day + ".txt"))
                {
                    File.Create(path + "/sample_schedule_templates/" + day + ".txt").Dispose();

                    using (TextWriter tw = new StreamWriter(path + "/sample_schedule_templates/" + day + ".txt"))
                    {
                        var teachers = cbTeacher.Items;//constraints.Where(d => d.Day == day).Select(o => o.Teacher).Distinct();
                        var header = "Timeslots";
                        foreach (var teacher in teachers)
                        {
                            header += " / " + teacher;
                        }
                        tw.WriteLine(header);
                        var hours = constraints.Where(d => d.Day == day).Select(o => o.Hour).Distinct();
                        foreach (string hour in hourList)
                        {
                            var row = hour;
                            var cons = constraints.Where(c => c.Day == day && c.Hour == hour);
                            foreach (string teacher in teachers)
                            {
                                var theCon = cons.FirstOrDefault(c => c.Teacher == teacher);
                                if (theCon != null)
                                {
                                    row += " / " + theCon.Course;
                                }
                                else
                                {
                                    row += " / -";
                                }


                            }
                            tw.WriteLine(row);
                        }
                    }

                }
                else if (File.Exists(path + "/sample_schedule_templates/" + day + ".txt"))
                {
                    using (TextWriter tw = new StreamWriter(path + "/sample_schedule_templates/" + day + ".txt"))
                    {
                        var teachers = cbTeacher.Items;//constraints.Where(d => d.Day == day).Select(o => o.Teacher).Distinct();
                        var header = "Timeslots";
                        foreach (var teacher in teachers)
                        {
                            header += " / " + teacher;
                        }
                        tw.WriteLine(header);
                        var hours = constraints.Where(d => d.Day == day).Select(o => o.Hour).Distinct();
                        foreach (string hour in hourList)
                        {
                            var row = hour;
                            var cons = constraints.Where(c => c.Day == day && c.Hour == hour);
                            foreach (string teacher in teachers)
                            {
                                var theCon = cons.FirstOrDefault(c => c.Teacher == teacher);
                                if (theCon != null)
                                {
                                    row += " / " + theCon.Course;
                                }
                                else
                                {
                                    row += " / -";
                                }


                            }
                            tw.WriteLine(row);
                        }
                    }
                }
                File.Delete(path + "output.html");
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C python " + path + "/solve_schedule.py -H " + path + "/output.html -p " + path + "/sample_preference_files/Example.txt " + path + "/sample_schedule_templates/" + day+".txt -t 5";
                process.StartInfo = startInfo;
                process.Start();



                MessageBox.Show("Matching has been completed successfully");
                //WebBrowser webBrowser = new WebBrowser();
                //webBrowser.Location = new System.Drawing.Point(4, 80);
                //webBrowser.Size = new System.Drawing.Size(700, 215);
                //webBrowser.Size = new System.Drawing.Size(745, 443);
                //tabPage6.Controls.Add(webBrowser);
                if (File.Exists(path + "/output.html"))
                {
                    var uri = new Uri(path + "output.html");
                    webBrowser.Navigate(uri);
                    webBrowser.Refresh();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("An exception occured");
            }
        }

        private void cbDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDay = cbDays.SelectedItem.ToString();
            var constraint = constraints.Where(c => c.Day == selectedDay);
            rtbConstraint.Clear();
            if (constraint.Any())
            {
                var first = constraint.First();
                foreach (var item in constraint)
                {
                    if (item == first)
                    {
                        rtbConstraint.AppendText(String.Format("{0}-{1}-{2}", item.Hour, item.Teacher, item.Course));

                    }
                    else
                    {
                        rtbConstraint.AppendText(Environment.NewLine + String.Format("{0}-{1}-{2}", item.Hour, item.Teacher, item.Course));
                    }
                }
            }



        }
    }
}
