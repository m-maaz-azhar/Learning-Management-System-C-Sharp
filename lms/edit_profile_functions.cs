using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace lms
{
    class edit_profile_functions
    {
        public void loadData(TextBox std_id_text,TextBox std_name_txt, TextBox std_program_txt,TextBox std_email_txt, TextBox std_phone_txt,TextBox std_pass_txt)
        {
            try
            {
                string constring = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 'E:\\W-Folder\\University Work\\OOP\\LMS\\data.mdb'";
                OleDbConnection Con = new OleDbConnection(constring);
                string query = $"SELECT ID,usr_name,usr_program,usr_email,usr_phone,usr_password FROM users WHERE usr_email = '{LMS.LoginedUser.UserEmail}'";
                OleDbCommand Command = new OleDbCommand(query, Con);
                Con.Open();
                OleDbDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    std_id_text.Text = Reader[0].ToString();
                    std_name_txt.Text = Reader[1].ToString();
                    std_program_txt.Text = Reader[2].ToString();
                    std_email_txt.Text = Reader[3].ToString();
                    std_phone_txt.Text = Reader[4].ToString();
                    std_pass_txt.Text = Reader[5].ToString();
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
        public void updateDataField(string field_name,TextBox updated_field)
        {
            try
            {
                string constring = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 'F:\\W-Folder\\University Work\\OOP\\LMS\\data.mdb'";
                OleDbConnection Con = new OleDbConnection(constring);
                string query = $"UPDATE users SET {field_name} = '{updated_field.Text}' WHERE usr_email = '{LMS.LoginedUser.UserEmail}'";
                OleDbCommand Command = new OleDbCommand(query, Con);
                Con.Open();
                Command.ExecuteNonQuery();
                if(field_name == "usr_email")
                {
                    LMS.LoginedUser.UserEmail = updated_field.Text;
                }
                MessageBox.Show($"{field_name.ToUpper()} UPDATED SUCCESSFULY", "UPDATED");
                Command.Dispose();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
