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
    public partial class clientsForm : Form
    {
        public clientsForm()
        {
            InitializeComponent();
            update();
        }
        private void update()
        {
            dataGridView1.DataSource = Database.dbGetListClients();
        }
        private void clientsForm_Load(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                label1.Visible = true;
                label2.Visible = true;
                label2.Text = dataGridView1[0, e.RowIndex].Value.ToString();

                button2.Visible = true;
                button3.Visible = true;

                textBox1.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                textBox2.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                textBox3.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.dbInsertClients(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.dbUpdateClients(label2.Text.ToString(), textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database.dbDeleteClients(label2.Text.ToString());
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {}
    }
}
