using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace lms
{
    public partial class results : Form
    {

        public results()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void results_Load(object sender, EventArgs e)
        {
            try
            {
                string constring = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 'F:\\W-Folder\\University Work\\OOP\\LMS\\data.mdb'";
                OleDbConnection Con = new OleDbConnection(constring);
                string query = $"SELECT attendance_percentage,[Current Semester],[Last Semester],usr_cgpa FROM users WHERE usr_email = '{LMS.LoginedUser.UserEmail}'";
                OleDbCommand Command = new OleDbCommand(query, Con);
                Con.Open();
                OleDbDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    result_data.Text = "";
                    for (int i = 0; i < Reader.FieldCount; i++)
                    {
                        result_data.Text += Reader[i].ToString() + "\n\n";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}
