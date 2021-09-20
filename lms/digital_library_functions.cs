using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace lms
{
    class digital_library_functions
    {
        string constring = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 'E:\\W-Folder\\University Work\\OOP\\LMS\\data.mdb'";

        public void SearchBook(TextBox search_item, DataGridView dataGridView1)
        {
            string bookName = search_item.Text;
            try
            {
                string query = "SELECT * FROM books WHERE title LIKE '%" + bookName.ToString() + "%'";
                using (OleDbConnection conn = new OleDbConnection(constring))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowAllBooks(DataGridView dataGridView1)
        {
            try
            {
                string query = "SELECT * FROM books";
                using (OleDbConnection conn = new OleDbConnection(constring))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
