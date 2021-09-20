using System;
using System.Windows.Forms;

namespace lms
{
    public partial class edit_profile : Form
    {
        edit_profile_functions editProfile = new edit_profile_functions();
        public edit_profile()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void edit_profile_Load(object sender, EventArgs e)
        {
            editProfile.loadData(std_id_text, std_name_txt, std_program_txt, std_email_txt, std_phone_txt, std_pass_txt);
        }

        private void update_email_btn_Click(object sender, EventArgs e)
        {
            editProfile.updateDataField("usr_email", std_email_txt);
        }
        private void update_num_btn_Click(object sender, EventArgs e)
        {
            editProfile.updateDataField("usr_phone", std_phone_txt);
        }

        private void update_pass_btn_Click(object sender, EventArgs e)
        {
            editProfile.updateDataField("usr_password", std_pass_txt);
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
