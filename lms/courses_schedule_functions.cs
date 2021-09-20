using System;
using System.Windows.Forms;
using System.Data.OleDb;


namespace lms
{
    class courses_schedule_functions
    {
        public void getCurrentUsrCourses()
        {
            try
            {
                string constring = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 'E:\\W-Folder\\University Work\\OOP\\LMS\\data.mdb'";
                OleDbConnection Con = new OleDbConnection(constring);
                string query = $"SELECT course_1,course_2,course_3,course_4 FROM users WHERE usr_email = '{LMS.LoginedUser.UserEmail}'";
                OleDbCommand Command = new OleDbCommand(query, Con);
                Con.Open();
                OleDbDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    for (int i = 0; i < Reader.FieldCount; i++)
                    {
                        LMS.LoginedUser.UserCourses[i] = Reader[i].ToString();
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
        public void showCourse(int courseNo, Label course_details)
        {
            try
            {
                string constring = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 'F:\\W-Folder\\University Work\\OOP\\LMS\\data.mdb'";
                OleDbConnection Con = new OleDbConnection(constring);
                string query = $"SELECT session_days,session_timming,room FROM courses WHERE course_name = '{LMS.LoginedUser.UserCourses[courseNo]}'";
                OleDbCommand Command = new OleDbCommand(query, Con);
                Con.Open();
                OleDbDataReader Reader = Command.ExecuteReader();
                string[] rows = new string[3] { "DAYS: ", "TIMMING: ", "ROOM: " };

                while (Reader.Read())
                {
                    course_details.Text = "";
                    for (int i = 0; i < Reader.FieldCount; i++)
                    {
                        course_details.Text += $"\n {rows[i]} {Reader[i].ToString().ToUpper()} \n";
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
    }
}
