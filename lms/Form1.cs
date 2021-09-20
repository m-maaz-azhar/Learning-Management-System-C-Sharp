using System;
using System.Windows.Forms;

namespace lms
{
    public partial class LMS : Form
    {
        public LMS()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            authCheck Login_Authentication = new authCheck();
            Login_Authentication.CheckLogin(email_text,pass_text);
        }

        public static class LoginedUser
        {
            public static string UserEmail { get; set;}
            public static string[] UserCourses = new string[4];
        }
    }
}