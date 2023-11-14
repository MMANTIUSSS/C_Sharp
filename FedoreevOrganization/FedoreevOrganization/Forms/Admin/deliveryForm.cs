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
    public partial class deliveryForm : Form
    {
        public deliveryForm()
        {
            InitializeComponent();
            update();
        }
        private void update()
        {
            dataGridView1.DataSource = Database.dbGetListDelivery();
        }
        private void deliveryForm_Load(object sender, EventArgs e)
        {

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(textBox2.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ТОЛЬКО ЦИФРЫ!" + ex);
                textBox2.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(textBox3.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ТОЛЬКО ЦИФРЫ!" + ex);
                textBox3.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.dbInsertDelivery(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day);
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.dbUpdateDelivery(label2.Text, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day);
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database.dbDeleteDelivery(label2.Text);
            update();
        }

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
                dateTimePicker1.Value = (DateTime)dataGridView1[4, e.RowIndex].Value;
            }   
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
