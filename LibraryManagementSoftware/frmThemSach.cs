using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
    public partial class frmThemSach : Form
    {
        private DBConnection db = new DBConnection();
        public frmThemSach()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmThemSach_Load(object sender, EventArgs e)
        {
            DataTable dt = db.ExecuteSelect("SELECT * FROM TACGIA");

            cbbTacGia.DataSource = dt;
            cbbTacGia.DisplayMember = "TenTacGia";
            cbbTacGia.ValueMember = "MaTacGia";
        }

        private void btnSelectAuthors_Click(object sender, EventArgs e)
        {
            DataTable dt = db.ExecuteSelect("SELECT * FROM TACGIA");
            MultiSelectForm multiSelectForm = new MultiSelectForm(dt);

            if (multiSelectForm.ShowDialog() == DialogResult.OK)
            {
                List<string> selectedAuthors = multiSelectForm.SelectedAuthors;
                string authors = string.Join(", ", selectedAuthors);
                MessageBox.Show("Selected Authors: " + authors);
            }
        }
    }
}
