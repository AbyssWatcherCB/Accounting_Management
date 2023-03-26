using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Accounting_Management.projetDB;
using Accounting_Management.projetDBTableAdapters;

namespace Accounting_Management
{
    public partial class Bonus : Form
    {
        projetDB dataset;
        BonusTableAdapter bonusTableAd;
        int g;
        public Bonus()
        {
            InitializeComponent();
        }

        private void Bonus_Load(object sender, EventArgs e)
        {
            dataset = new projetDB();
            bonusTableAd = new BonusTableAdapter();
            bonusTableAd.Fill(dataset.Bonus);
            dataGridView1.DataSource = dataset.Bonus;
        }
        public int rechercher(string v)
        {
            int i, pos = -1;
            for (i = 0; i < dataset.Bonus.Rows.Count; i++)
            {
                if (dataset.Bonus.Rows[i][0].ToString() == v)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }
        private void clear()
        {
            txtamount.Text = "";
            txtname.Text = "";
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtname.Text==""||txtamount.Text=="")
                {
                    MessageBox.Show("fill the information");
                }
                else
                {
                    bonusTableAd.InsertQuery(txtname.Text, int.Parse(txtamount.Text));
                    MessageBox.Show("bonus is Saved");
                    clear();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtname.Text == "" || txtamount.Text == "")
                {
                    MessageBox.Show("fill the information");
                }
                else
                {
                   
                    bonusTableAd.UpdateQuery(txtname.Text, int.Parse(txtamount.Text),g);
                    MessageBox.Show("bonus is Edited");
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtname.Text == "" || txtamount.Text == "")
                {
                    MessageBox.Show("fill the information");
                }
                else
                {
                    
                    bonusTableAd.DeleteQuery(g);
                    MessageBox.Show("bonus is deleted");
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;

            int d = rechercher(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            g = int.Parse(dataset.Bonus.Rows[d][0].ToString());
            txtname.Text= dataset.Bonus.Rows[d][1].ToString();
            txtamount.Text= dataset.Bonus.Rows[d][2].ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.ShowDialog();
        }
    }
}
