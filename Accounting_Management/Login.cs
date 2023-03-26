using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting_Management.projetDBTableAdapters;
using static Accounting_Management.projetDB;

namespace Accounting_Management
{
    
    public partial class Login : Form
    {
        projetDB dataset;
        usersTableAdapter usersTableAd;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i,d=0;
            for (i = 0; i < dataset.users.Count; i++)
            {
                if (txtlog.Text == dataset.users.Rows[i][0].ToString()||txtpas.Text== dataset.users.Rows[i][1].ToString())
                {
                    Home home = new Home();
                    home.ShowDialog();                  
                    d = 1;
                }

            }
            if (d == 0)
            {
                txtlog.Text = "";
                txtpas.Text = "";
                MessageBox.Show("Login or the password are wrong !!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtlog.Text = "";
            txtpas.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {
            dataset = new projetDB();
            usersTableAd = new usersTableAdapter();
            usersTableAd.Fill(dataset.users);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
