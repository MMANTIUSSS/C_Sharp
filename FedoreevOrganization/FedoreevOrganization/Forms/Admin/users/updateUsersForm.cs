using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FedoreevOrganization
{
    public partial class updateUsersForm : Form
    {
        public updateUsersForm()
        {
            InitializeComponent();
            update();
        }
        private void update()
        {
            dataGridView1.DataSource = Database.dbGetListUsers();
        }

        private void updateUsersForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                label2.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                textBox1.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                textBox2.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                textBox3.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.dbUpdateUsers(label2.Text, textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString());
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database.dbDeleteUsers(label2.Text.ToString());
        }
    }
}
