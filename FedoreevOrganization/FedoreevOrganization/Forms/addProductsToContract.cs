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
    public partial class addProductsToContract : Form
    {
        int contractID = 0;
        string fileName = "D:/report.xlsx";
        public addProductsToContract(int contractID)
        {
            InitializeComponent();
            this.contractID = contractID;
            update();
        }
        private void update()
        {
            dataGridView2.DataSource = Database.dbGetListProducts();
        }
        private void addProductsToContract_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                label3.Text = dataGridView2[0, e.RowIndex].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.dbInsertContractsBond(contractID, Convert.ToInt32(label3.Text), Convert.ToInt32(textBox1.Text));
            MessageBox.Show("Успешно!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBox1.Text = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            fileName = openFileDialog1.FileName.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Excel.excelReportContract(Database.dbGetReportContract(contractID), fileName);
            MessageBox.Show("Успешно!");
        }
    }
}
