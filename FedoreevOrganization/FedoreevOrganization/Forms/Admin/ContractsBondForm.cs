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
    public partial class ContractsBondForm : Form
    {
        public ContractsBondForm()
        {
            InitializeComponent();
            update();
        }
        
        private void update()
        {
            dataGridView1.DataSource = Database.dbGetListContractsBond();
        }
        private void ContractsBondForm_Load(object sender, EventArgs e) { }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0 )
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
            Database.dbInsertContractsBond(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.dbUpdateContractsBond(label2.Text, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database.dbDeleteContractsBond(label2.Text);
            update();
        }
    }
}
