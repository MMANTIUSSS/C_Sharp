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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
            //MessageBox.Show("admin".GetHashCode().ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var answer = Database.authorization(login.Text.ToString(), password.Text.ToString());
            if (answer == null)
            {
                MessageBox.Show("Введён неверный пароль");
            }
            else if (answer.ToString() == "admin")
            {
                MainAdmin mainAdmin = new MainAdmin();
                mainAdmin.Show();
            }
        }
    }
}
