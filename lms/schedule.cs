using System;
using System.Windows.Forms;

namespace lms
{
    public partial class schedule : Form
    {
        courses_schedule_functions courses_schedule = new courses_schedule_functions();

        public schedule()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void schedule_Load(object sender, EventArgs e)
        {
            courses_schedule.getCurrentUsrCourses();

            course1_btn.Text = LMS.LoginedUser.UserCourses[0].ToUpper();
            course2_btn.Text = LMS.LoginedUser.UserCourses[1].ToUpper();
            course3_btn.Text = LMS.LoginedUser.UserCourses[2].ToUpper();
            course4_btn.Text = LMS.LoginedUser.UserCourses[3].ToUpper();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            home home_page = new home();
            home_page.ShowDialog();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LMS login_page = new LMS();
            login_page.ShowDialog();
        }

        private void course_1_btn_Click(object sender, EventArgs e)
        {
            courses_schedule.showCourse(0,course_details);
        }

        private void course2_btn_Click(object sender, EventArgs e)
        {
            courses_schedule.showCourse(1, course_details);
        }

        private void course3_btn_Click(object sender, EventArgs e)
        {
            courses_schedule.showCourse(2, course_details);
        }

        private void course4_btn_Click(object sender, EventArgs e)
        {
            courses_schedule.showCourse(3, course_details);
        }
    }
}
