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
    public partial class addUserForm : Form
    {
        public addUserForm()
        {
            InitializeComponent();
            List<string> perm = new List<string> {"admin", "moder", "searcher"};
            checkedListBox1.DataSource = perm;
        }

        private void addUserForm_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.dbInsertUsers(textBox1.Text, textBox2.Text, checkedListBox1.CheckedItems.ToString());
        }
    }
}
