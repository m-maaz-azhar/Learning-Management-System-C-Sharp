using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace lms
{
    class report_functions
    {
       public void submitReport(TextBox std_id,TextBox std_name, TextBox std_email,TextBox std_phone,TextBox std_complaint)
        {
            try
            {
                string constring = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 'E:\\W-Folder\\University Work\\OOP\\LMS\\data.mdb'";
                OleDbConnection Con = new OleDbConnection(constring);
                string query = $"INSERT INTO reports( std_id,std_name, std_email, std_phone,std_complaint) VALUES('{std_id.Text}','{std_name.Text}','{std_email.Text}' , '{std_phone.Text}', '{std_complaint.Text}'); ";
                OleDbCommand Command = new OleDbCommand(query, Con);
                Con.Open();
                Command.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("Report Submitted Successfuly", "Submitted", MessageBoxButtons.OK);
                std_id.Text = "";
                std_name.Text = "";
                std_email.Text = "";
                std_phone.Text = "";
                std_complaint.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
