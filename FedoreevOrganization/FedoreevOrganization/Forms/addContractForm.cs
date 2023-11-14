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
    public partial class addContractForm : Form
    {
        public int clientID = 0;
        public List<int> productID = new List<int>();
        public addContractForm()
        {
            InitializeComponent();
            update();
        }
        private void update()
        {
            dataGridView1.DataSource = Database.dbGetListClients();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                clientID = Convert.ToInt32(dataGridView1[0,e.RowIndex].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.dbInsertContract(clientID, dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day, checkBox1.Checked);
            addProductsToContract f = new addProductsToContract(Database.dbGetLastContractID());
            f.ShowDialog();
        }
    }
}
