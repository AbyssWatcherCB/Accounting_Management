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
    public partial class Employees : Form
    {
        projetDB dataset;
        employeeTableAdapter employeeTableAd;
        int g;
   
        public Employees()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.ShowDialog();
        }
        public int rechercher(string v)
        {
            int i, pos=-1;
            for (i = 0;i < dataset.employee.Rows.Count; i++)
            {
                if (dataset.employee.Rows[i][0].ToString() == v)
                {
                    pos = i;                   
                    break;
                }               
            }
            return pos;
        }
        private void clear()
        {
            txtnom.Text = "";
            cmbgender.SelectedIndex = 0;
            dateTimePickerDOB.Value = DateTime.Now;
            txtPhone.Text = "";
            txtadress.Text = "";
            cmbPos.SelectedIndex = 0;
            dateTimePickerJoin.Value = DateTime.Now;
            cmbQual.SelectedIndex = 0;
            txtBase.Text = "";
        }
        private void btnSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtnom.Text == "" || txtadress.Text == "" || txtBase.Text == "" || txtPhone.Text == "" || cmbgender.SelectedIndex == -1 || cmbPos.SelectedIndex == -1 || cmbQual.SelectedIndex == -1)
                {
                    MessageBox.Show("fill the information");
                }
                else
                {
                    employeeTableAd.InsertQuery(txtnom.Text, cmbgender.Text, dateTimePickerDOB.Value.ToShortDateString(), txtPhone.Text, txtadress.Text, cmbPos.Text, dateTimePickerJoin.Value.ToShortDateString(), cmbQual.Text, int.Parse(txtBase.Text));
                    MessageBox.Show("Employee is Saved");
                    clear();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            dataset = new projetDB();
            employeeTableAd = new employeeTableAdapter();
            employeeTableAd.Fill(dataset.employee);
            dataGridView1.DataSource = dataset.employee;                      
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                dataGridView1.CurrentRow.Selected=true;
                int d = rechercher(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                g = int.Parse(dataset.employee.Rows[d][0].ToString());
                txtnom.Text = dataset.employee.Rows[d][1].ToString();
                cmbgender.Text = dataset.employee[d][2].ToString();
                dateTimePickerDOB.Value = DateTime.Parse(dataset.employee[d][3].ToString());
                txtPhone.Text = dataset.employee.Rows[d][4].ToString();
                txtadress.Text = dataset.employee.Rows[d][5].ToString();
                cmbPos.Text = dataset.employee.Rows[d][6].ToString();
                dateTimePickerJoin.Value = DateTime.Parse(dataset.employee[d][7].ToString());
                cmbQual.Text = dataset.employee.Rows[d][8].ToString();
                txtBase.Text = dataset.employee.Rows[d][9].ToString();           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {

                if (txtnom.Text == "" || txtadress.Text == "" || txtBase.Text == "" || txtPhone.Text == "" || cmbgender.SelectedIndex == -1 || cmbPos.SelectedIndex == -1 || cmbQual.SelectedIndex == -1)
                {
                    MessageBox.Show("fill the information");
                }
                else
                {
                    
                    employeeTableAd.UpdateQuery(txtnom.Text, cmbgender.Text, dateTimePickerDOB.Value.ToShortDateString(), txtPhone.Text, txtadress.Text, cmbPos.Text, dateTimePickerJoin.Value.ToShortDateString(), cmbQual.Text, int.Parse(txtBase.Text), g);
                    MessageBox.Show("Employee is Edited");
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
            if (txtnom.Text == "" || txtadress.Text == "" || txtBase.Text == "" || txtPhone.Text == "" || cmbgender.SelectedIndex == -1 || cmbPos.SelectedIndex == -1 || cmbQual.SelectedIndex == -1)
            {
                MessageBox.Show("fill the information");
            }
            else
            {
             
                employeeTableAd.DeleteQuery(g);
                MessageBox.Show("Employee is Deleted");
                clear();
              
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Bonus bonus = new Bonus();
            bonus.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Salary salary = new Salary();
            salary.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

            Home home = new Home();
            home.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Salary salary = new Salary();
            salary.ShowDialog();
          
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Bonus bonus = new Bonus();
            bonus.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
