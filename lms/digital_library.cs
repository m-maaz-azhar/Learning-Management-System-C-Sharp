using System;
using System.Windows.Forms;

namespace lms
{
    public partial class digital_library : Form
    {
        digital_library_functions Search = new digital_library_functions();

        public digital_library()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }



        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LMS login_page = new LMS();
            login_page.ShowDialog();
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            Search.SearchBook(search_item, dataGridView1);
        }

        private void showAll_Click(object sender, EventArgs e)
        {
            Search.ShowAllBooks(dataGridView1);
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            home home_page = new home();
            home_page.ShowDialog();
        }
    }
}