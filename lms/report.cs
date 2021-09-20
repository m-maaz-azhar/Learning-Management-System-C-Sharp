using System;
using System.Windows.Forms;

namespace lms
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            report_functions newReport = new report_functions();
            newReport.submitReport(std_id, std_name, std_email, std_phone, std_complaint);
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LMS login_page = new LMS();
            login_page.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            home home_page = new home();
            home_page.ShowDialog();
        }
    }
}
