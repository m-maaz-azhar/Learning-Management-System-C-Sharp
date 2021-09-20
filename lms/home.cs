using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace lms
{
    public partial class home : Form
    { 
        public home()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void home_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LMS.ActiveForm.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            digital_library library_page = new digital_library();
            library_page.ShowDialog();
        }

        private void home_Load(object sender, EventArgs e)
        {
            try
            {
                string constring = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 'F:\\W-Folder\\University Work\\OOP\\LMS\\data.mdb'";
                OleDbConnection Con = new OleDbConnection(constring);
                string query = $"SELECT ID,usr_name,usr_program FROM users WHERE usr_email = '{LMS.LoginedUser.UserEmail}'";
                OleDbCommand Command = new OleDbCommand(query, Con);
                Con.Open();
                OleDbDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    for (int i = 0; i < Reader.FieldCount; i++)
                    {
                        lbl_1.Text += Reader[i].ToString() + "\n";
                    }
                }
                Reader.Close();
                Command.Dispose();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            LMS login_page = new LMS();
            login_page.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            results result_page = new results();
            result_page.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            report report_page = new report();
            report_page.ShowDialog();
        }

        private void edit_profile_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            edit_profile edit_profile_page = new edit_profile();
            edit_profile_page.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            schedule schedule_page = new schedule();
            schedule_page.ShowDialog();
        }
    }
}