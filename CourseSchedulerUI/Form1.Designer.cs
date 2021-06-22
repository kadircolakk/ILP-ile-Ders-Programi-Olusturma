namespace CourseSchedulerUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.lstCourses = new System.Windows.Forms.ListBox();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.lstTeacher = new System.Windows.Forms.ListBox();
            this.txtTeacherName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lbStudents = new System.Windows.Forms.ListBox();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.txtStudent = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnRemoveCourseStd = new System.Windows.Forms.Button();
            this.btnAddCourseStd = new System.Windows.Forms.Button();
            this.lbNotAddedCoursesStd = new System.Windows.Forms.ListBox();
            this.lbAddedCoursesStd = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbStudents = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnMatch = new System.Windows.Forms.Button();
            this.btnRemoveCourseFromTeacher = new System.Windows.Forms.Button();
            this.btnAddCourseTeacher = new System.Windows.Forms.Button();
            this.lbNotAddedCourses = new System.Windows.Forms.ListBox();
            this.lbAddedCourses = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTeacher = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.rtbConstraint = new System.Windows.Forms.RichTextBox();
            this.cbCourseConstraint = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbTeacherCons = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbHour = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAddDayConstraint = new System.Windows.Forms.Button();
            this.cbDays = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnGetReport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbDaysReport = new System.Windows.Forms.ComboBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(22, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 5;
            this.tabControl1.Size = new System.Drawing.Size(753, 471);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAddCourse);
            this.tabPage1.Controls.Add(this.lstCourses);
            this.tabPage1.Controls.Add(this.txtCourseName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(745, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Courses";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.Location = new System.Drawing.Point(19, 82);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(75, 23);
            this.btnAddCourse.TabIndex = 3;
            this.btnAddCourse.Text = "Add";
            this.btnAddCourse.UseVisualStyleBackColor = true;
            this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);
            // 
            // lstCourses
            // 
            this.lstCourses.FormattingEnabled = true;
            this.lstCourses.ItemHeight = 15;
            this.lstCourses.Location = new System.Drawing.Point(522, 23);
            this.lstCourses.Name = "lstCourses";
            this.lstCourses.Size = new System.Drawing.Size(199, 259);
            this.lstCourses.TabIndex = 2;
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(107, 23);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(145, 23);
            this.txtCourseName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddTeacher);
            this.tabPage2.Controls.Add(this.lstTeacher);
            this.tabPage2.Controls.Add(this.txtTeacherName);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(745, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Teachers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Location = new System.Drawing.Point(21, 99);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(75, 23);
            this.btnAddTeacher.TabIndex = 3;
            this.btnAddTeacher.Text = "Add";
            this.btnAddTeacher.UseVisualStyleBackColor = true;
            this.btnAddTeacher.Click += new System.EventHandler(this.btnAddTeacher_Click);
            // 
            // lstTeacher
            // 
            this.lstTeacher.FormattingEnabled = true;
            this.lstTeacher.ItemHeight = 15;
            this.lstTeacher.Location = new System.Drawing.Point(518, 21);
            this.lstTeacher.Name = "lstTeacher";
            this.lstTeacher.Size = new System.Drawing.Size(202, 259);
            this.lstTeacher.TabIndex = 2;
            // 
            // txtTeacherName
            // 
            this.txtTeacherName.Location = new System.Drawing.Point(112, 21);
            this.txtTeacherName.Name = "txtTeacherName";
            this.txtTeacherName.Size = new System.Drawing.Size(137, 23);
            this.txtTeacherName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Teacher Name:";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.lbStudents);
            this.tabPage4.Controls.Add(this.btnAddStudent);
            this.tabPage4.Controls.Add(this.txtStudent);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(745, 443);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Students";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lbStudents
            // 
            this.lbStudents.FormattingEnabled = true;
            this.lbStudents.ItemHeight = 15;
            this.lbStudents.Location = new System.Drawing.Point(510, 29);
            this.lbStudents.Name = "lbStudents";
            this.lbStudents.Size = new System.Drawing.Size(194, 229);
            this.lbStudents.TabIndex = 3;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(32, 118);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(75, 23);
            this.btnAddStudent.TabIndex = 2;
            this.btnAddStudent.Text = "Add";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // txtStudent
            // 
            this.txtStudent.Location = new System.Drawing.Point(116, 29);
            this.txtStudent.Name = "txtStudent";
            this.txtStudent.Size = new System.Drawing.Size(100, 23);
            this.txtStudent.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Student:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.btnRemoveCourseStd);
            this.tabPage3.Controls.Add(this.btnAddCourseStd);
            this.tabPage3.Controls.Add(this.lbNotAddedCoursesStd);
            this.tabPage3.Controls.Add(this.lbAddedCoursesStd);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.cbStudents);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.btnMatch);
            this.tabPage3.Controls.Add(this.btnRemoveCourseFromTeacher);
            this.tabPage3.Controls.Add(this.btnAddCourseTeacher);
            this.tabPage3.Controls.Add(this.lbNotAddedCourses);
            this.tabPage3.Controls.Add(this.lbAddedCourses);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.cbTeacher);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(745, 443);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ass Courses";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnRemoveCourseStd
            // 
            this.btnRemoveCourseStd.Location = new System.Drawing.Point(490, 288);
            this.btnRemoveCourseStd.Name = "btnRemoveCourseStd";
            this.btnRemoveCourseStd.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCourseStd.TabIndex = 16;
            this.btnRemoveCourseStd.Text = "->";
            this.btnRemoveCourseStd.UseVisualStyleBackColor = true;
            this.btnRemoveCourseStd.Click += new System.EventHandler(this.btnRemoveCourseStd_Click);
            // 
            // btnAddCourseStd
            // 
            this.btnAddCourseStd.Location = new System.Drawing.Point(490, 258);
            this.btnAddCourseStd.Name = "btnAddCourseStd";
            this.btnAddCourseStd.Size = new System.Drawing.Size(75, 23);
            this.btnAddCourseStd.TabIndex = 15;
            this.btnAddCourseStd.Text = "<-";
            this.btnAddCourseStd.UseVisualStyleBackColor = true;
            this.btnAddCourseStd.Click += new System.EventHandler(this.btnAddCourseStd_Click);
            // 
            // lbNotAddedCoursesStd
            // 
            this.lbNotAddedCoursesStd.FormattingEnabled = true;
            this.lbNotAddedCoursesStd.ItemHeight = 15;
            this.lbNotAddedCoursesStd.Location = new System.Drawing.Point(592, 242);
            this.lbNotAddedCoursesStd.Name = "lbNotAddedCoursesStd";
            this.lbNotAddedCoursesStd.Size = new System.Drawing.Size(120, 94);
            this.lbNotAddedCoursesStd.TabIndex = 14;
            // 
            // lbAddedCoursesStd
            // 
            this.lbAddedCoursesStd.FormattingEnabled = true;
            this.lbAddedCoursesStd.ItemHeight = 15;
            this.lbAddedCoursesStd.Location = new System.Drawing.Point(337, 242);
            this.lbAddedCoursesStd.Name = "lbAddedCoursesStd";
            this.lbAddedCoursesStd.Size = new System.Drawing.Size(120, 94);
            this.lbAddedCoursesStd.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(592, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Not Added Courses";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(337, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "Added Courses";
            // 
            // cbStudents
            // 
            this.cbStudents.FormattingEnabled = true;
            this.cbStudents.Location = new System.Drawing.Point(120, 205);
            this.cbStudents.Name = "cbStudents";
            this.cbStudents.Size = new System.Drawing.Size(121, 23);
            this.cbStudents.TabIndex = 10;
            this.cbStudents.SelectedIndexChanged += new System.EventHandler(this.cbStudents_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Students";
            // 
            // btnMatch
            // 
            this.btnMatch.Location = new System.Drawing.Point(310, 390);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(75, 23);
            this.btnMatch.TabIndex = 8;
            this.btnMatch.Text = "Match";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // btnRemoveCourseFromTeacher
            // 
            this.btnRemoveCourseFromTeacher.Location = new System.Drawing.Point(490, 133);
            this.btnRemoveCourseFromTeacher.Name = "btnRemoveCourseFromTeacher";
            this.btnRemoveCourseFromTeacher.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCourseFromTeacher.TabIndex = 7;
            this.btnRemoveCourseFromTeacher.Text = "->";
            this.btnRemoveCourseFromTeacher.UseVisualStyleBackColor = true;
            this.btnRemoveCourseFromTeacher.Click += new System.EventHandler(this.btnRemoveCourseFromTeacher_Click);
            // 
            // btnAddCourseTeacher
            // 
            this.btnAddCourseTeacher.Location = new System.Drawing.Point(490, 103);
            this.btnAddCourseTeacher.Name = "btnAddCourseTeacher";
            this.btnAddCourseTeacher.Size = new System.Drawing.Size(75, 23);
            this.btnAddCourseTeacher.TabIndex = 6;
            this.btnAddCourseTeacher.Text = "<-";
            this.btnAddCourseTeacher.UseVisualStyleBackColor = true;
            this.btnAddCourseTeacher.Click += new System.EventHandler(this.btnAddCourseTeacher_Click);
            // 
            // lbNotAddedCourses
            // 
            this.lbNotAddedCourses.FormattingEnabled = true;
            this.lbNotAddedCourses.ItemHeight = 15;
            this.lbNotAddedCourses.Location = new System.Drawing.Point(592, 73);
            this.lbNotAddedCourses.Name = "lbNotAddedCourses";
            this.lbNotAddedCourses.Size = new System.Drawing.Size(120, 94);
            this.lbNotAddedCourses.TabIndex = 5;
            // 
            // lbAddedCourses
            // 
            this.lbAddedCourses.FormattingEnabled = true;
            this.lbAddedCourses.ItemHeight = 15;
            this.lbAddedCourses.Location = new System.Drawing.Point(337, 73);
            this.lbAddedCourses.Name = "lbAddedCourses";
            this.lbAddedCourses.Size = new System.Drawing.Size(120, 94);
            this.lbAddedCourses.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(592, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Not Added Courses";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Added Courses";
            // 
            // cbTeacher
            // 
            this.cbTeacher.FormattingEnabled = true;
            this.cbTeacher.Location = new System.Drawing.Point(120, 29);
            this.cbTeacher.Name = "cbTeacher";
            this.cbTeacher.Size = new System.Drawing.Size(121, 23);
            this.cbTeacher.TabIndex = 1;
            this.cbTeacher.SelectedIndexChanged += new System.EventHandler(this.cbTeacher_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Teachers:";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Transparent;
            this.tabPage5.Controls.Add(this.rtbConstraint);
            this.tabPage5.Controls.Add(this.cbCourseConstraint);
            this.tabPage5.Controls.Add(this.label14);
            this.tabPage5.Controls.Add(this.cbTeacherCons);
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Controls.Add(this.cbHour);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.btnAddDayConstraint);
            this.tabPage5.Controls.Add(this.cbDays);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(745, 443);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Day Constraints";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // rtbConstraint
            // 
            this.rtbConstraint.Location = new System.Drawing.Point(23, 193);
            this.rtbConstraint.Name = "rtbConstraint";
            this.rtbConstraint.ReadOnly = true;
            this.rtbConstraint.Size = new System.Drawing.Size(700, 200);
            this.rtbConstraint.TabIndex = 9;
            this.rtbConstraint.Text = "";
            // 
            // cbCourseConstraint
            // 
            this.cbCourseConstraint.FormattingEnabled = true;
            this.cbCourseConstraint.Location = new System.Drawing.Point(616, 84);
            this.cbCourseConstraint.Name = "cbCourseConstraint";
            this.cbCourseConstraint.Size = new System.Drawing.Size(121, 23);
            this.cbCourseConstraint.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(531, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 15);
            this.label14.TabIndex = 7;
            this.label14.Text = "Course:";
            // 
            // cbTeacherCons
            // 
            this.cbTeacherCons.FormattingEnabled = true;
            this.cbTeacherCons.Location = new System.Drawing.Point(350, 84);
            this.cbTeacherCons.Name = "cbTeacherCons";
            this.cbTeacherCons.Size = new System.Drawing.Size(121, 23);
            this.cbTeacherCons.TabIndex = 6;
            this.cbTeacherCons.SelectedIndexChanged += new System.EventHandler(this.cbTeacherCons_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(251, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 15);
            this.label13.TabIndex = 5;
            this.label13.Text = "Teacher:";
            // 
            // cbHour
            // 
            this.cbHour.FormattingEnabled = true;
            this.cbHour.Location = new System.Drawing.Point(86, 84);
            this.cbHour.Name = "cbHour";
            this.cbHour.Size = new System.Drawing.Size(121, 23);
            this.cbHour.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Hour:";
            // 
            // btnAddDayConstraint
            // 
            this.btnAddDayConstraint.Location = new System.Drawing.Point(295, 136);
            this.btnAddDayConstraint.Name = "btnAddDayConstraint";
            this.btnAddDayConstraint.Size = new System.Drawing.Size(133, 23);
            this.btnAddDayConstraint.TabIndex = 2;
            this.btnAddDayConstraint.Text = "Add Day Constraint";
            this.btnAddDayConstraint.UseVisualStyleBackColor = true;
            this.btnAddDayConstraint.Click += new System.EventHandler(this.btnAddDayConstraint_Click);
            // 
            // cbDays
            // 
            this.cbDays.FormattingEnabled = true;
            this.cbDays.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wendesday",
            "Thursday",
            "Friday"});
            this.cbDays.Location = new System.Drawing.Point(86, 29);
            this.cbDays.Name = "cbDays";
            this.cbDays.Size = new System.Drawing.Size(121, 23);
            this.cbDays.TabIndex = 1;
            this.cbDays.SelectedIndexChanged += new System.EventHandler(this.cbDays_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Days:";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.cbDaysReport);
            this.tabPage6.Controls.Add(this.btnGetReport);
            this.tabPage6.Controls.Add(this.webBrowser);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(745, 443);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Report";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(319, 68);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(75, 23);
            this.btnGetReport.TabIndex = 0;
            this.btnGetReport.Text = "Get Report";
            this.btnGetReport.UseVisualStyleBackColor = true;
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(522, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(199, 259);
            this.listBox1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 23);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Course Name:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cbDaysReport
            // 
            this.cbDaysReport.FormattingEnabled = true;
            this.cbDaysReport.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wendesday",
            "Thursday",
            "Friday"});
            this.cbDaysReport.Location = new System.Drawing.Point(319, 18);
            this.cbDaysReport.Name = "cbDaysReport";
            this.cbDaysReport.Size = new System.Drawing.Size(121, 23);
            this.cbDaysReport.TabIndex = 1;
            // 
            // cbDaysReport
            // 
            this.webBrowser.Location = new System.Drawing.Point(4, 80);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(700, 215);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.ListBox lstCourses;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstTeacher;
        private System.Windows.Forms.TextBox txtTeacherName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAddTeacher;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cbTeacher;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbNotAddedCourses;
        private System.Windows.Forms.ListBox lbAddedCourses;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddCourseTeacher;
        private System.Windows.Forms.Button btnRemoveCourseFromTeacher;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.Button btnRemoveCourseStd;
        private System.Windows.Forms.Button btnAddCourseStd;
        private System.Windows.Forms.ListBox lbNotAddedCoursesStd;
        private System.Windows.Forms.ListBox lbAddedCoursesStd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbStudents;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox lbStudents;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.TextBox txtStudent;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ComboBox cbDays;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAddDayConstraint;
        private System.Windows.Forms.RichTextBox rtbConstraint;
        private System.Windows.Forms.ComboBox cbCourseConstraint;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbTeacherCons;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbHour;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnGetReport;
        private System.Windows.Forms.ComboBox cbDaysReport;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}

