using System;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace lms
{
    class authCheck
    {
        private int _failedLoginCounter = 0;

        public void CheckLogin(TextBox email_text, TextBox pass_text)
        {
            string email = email_text.Text;
            string pass = pass_text.Text;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please type your Email","EMPTY FIELD",MessageBoxButtons.RetryCancel,MessageBoxIcon.Exclamation);
                email_text.Focus();
                return;
            }

            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please type your Password","EMPTY FIELD", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                pass_text.Focus();
                return;
            }

            try
            {
                string constring = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 'E:\\W-Folder\\University Work\\OOP\\LMS\\data.mdb'";
                using (OleDbConnection conDataBase = new OleDbConnection(constring))
                {
                    using (OleDbCommand cmdDataBase = conDataBase.CreateCommand())
                    {
                       
                        cmdDataBase.CommandText = "SELECT * FROM users WHERE usr_email = @email AND usr_password = @pass";
                        cmdDataBase.Parameters.AddRange(new OleDbParameter[]
                        {
                            new OleDbParameter("@email", email),
                            new OleDbParameter("@pass", pass)
                        });

                        if (conDataBase.State != ConnectionState.Open) { 
                            conDataBase.Open();
                        }

                        var numberOrResults = 0;

                        using (OleDbDataReader myReader = cmdDataBase.ExecuteReader())
                        {
                            while (myReader != null && myReader.Read())
                            {
                                numberOrResults++;
                            }
                        }
                        if (numberOrResults == 1)
                        {
                            cmdDataBase.Dispose();
                            conDataBase.Close();
                            LMS.ActiveForm.Hide();
                            LMS.LoginedUser.UserEmail = email;
                            home home_page = new home();
                            home_page.ShowDialog();
                        }

                        else if (numberOrResults > 1)
                        {
                            MessageBox.Show("Multiple users found on this Email");
                            _failedLoginCounter++;
                        }
                        else if (numberOrResults == 0)
                        {
                            MessageBox.Show("Please Check Your Email OR Password");
                            _failedLoginCounter++;
                        }
                    }

                }

                if (_failedLoginCounter >= 3) {
                    MessageBox.Show("YOUR LOGIN ATTEMPT LIMIT EXCEEDED");
                    LMS.ActiveForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}