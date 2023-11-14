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
    public partial class contractsForm : Form
    {
        public contractsForm()
        {
            InitializeComponent();
            update();
        }

        private void contractsForm_Load(object sender, EventArgs e)
        {

        }
        private void update()
        {
            dataGridView1.DataSource = Database.dbGetListContract();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                label1.Visible = true;
                label2.Visible = true;
                label2.Text = dataGridView1[0, e.RowIndex].Value.ToString();

                button2.Visible = true;
                button3.Visible = true;

                textBox1.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                dateTimePicker1.Value = (DateTime)dataGridView1[2, e.RowIndex].Value;
                checkBox1.Checked = (bool)dataGridView1[3, e.RowIndex].Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.dbInsertContract(Convert.ToInt32(textBox1.Text), dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day, checkBox1.Checked);
            update();
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            Database.dbUpdateContract(label2.Text, Convert.ToInt32(textBox1.Text), dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day, checkBox1.Checked);
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database.dbDeleteContract(label2.Text);
            update();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(textBox1.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ТОЛЬКО ЦИФРЫ!" + ex);
                textBox1.Text = "";
            }
        }
    }
}
