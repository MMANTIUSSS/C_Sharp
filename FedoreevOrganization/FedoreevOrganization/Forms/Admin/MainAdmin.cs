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
    public partial class MainAdmin : Form
    {
        List<string> productsID = new List<string>();
        List<string> clientsID = new List<string>();
        public string fileNameProducts = "D:/report.xlsx";
        public string fileNameClients = "D:/report.xlsx";
        public MainAdmin()
        {
            InitializeComponent();
            update();
        }
        private void update()
        {
            dataGridView1.DataSource = Database.dbGetListProducts();
            dataGridView2.DataSource = Database.dbGetListClients();
        }

        private void MainAdmin_Load(object sender, EventArgs e) { }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1[0, e.RowIndex].Value == "⌦︎")
                {
                    productsID.Remove(dataGridView1[1, e.RowIndex].Value.ToString());
                    dataGridView1[0, e.RowIndex].Value = "";
                }
                else
                {
                    productsID.Add(dataGridView1[1, e.RowIndex].Value.ToString());
                    dataGridView1[0, e.RowIndex].Value = "⌦︎";
                }
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView2[0, e.RowIndex].Value == "⌦︎")
                {
                    clientsID.Remove(dataGridView2[1, e.RowIndex].Value.ToString());
                    dataGridView2[0, e.RowIndex].Value = "";
                }
                else
                {
                    clientsID.Add(dataGridView2[1, e.RowIndex].Value.ToString());
                    dataGridView2[0, e.RowIndex].Value = "⌦︎";
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productsForm f = new productsForm();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clientsForm f = new clientsForm();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            contractsForm f = new contractsForm();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ContractsBondForm f = new ContractsBondForm();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            deliveryForm f = new deliveryForm();
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            fileNameProducts = openFileDialog1.FileName.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            fileNameClients = openFileDialog1.FileName.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Excel.excelReportProducts(Database.dbGetReportProducts(productsID, dateTimePicker1.Value, dateTimePicker2.Value), fileNameProducts);
            MessageBox.Show("КОНЕЦ!");
        }
        private void label8_Click(object sender, EventArgs e) { }

        private void button10_Click(object sender, EventArgs e)
        {
            Excel.excelReportClients(Database.dbGetReportClients(clientsID, dateTimePicker4.Value, dateTimePicker3.Value), fileNameClients);
            MessageBox.Show("КОНЕЦ!");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            addUserForm f = new addUserForm();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            updateUsersForm f = new updateUsersForm();
            f.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            addContractForm f = new addContractForm();
            f.ShowDialog();
        }
    }
}