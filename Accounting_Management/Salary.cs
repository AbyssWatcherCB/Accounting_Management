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
    public partial class Salary : Form
    {
        projetDB dataset;
        SalaryTableAdapter salaryTableAd;
        employeeTableAdapter employeeTableAd;
        BonusTableAdapter bonusTableAd;
        AttendanceTableAdapter attendanceTableAd;
        int pres, abs, exc,adv,bon;
        double daily, total, grdtot = 0, tottax = 0;
        double tax = 0;

        public Salary()
        {
            InitializeComponent();
        }
        public int rechercher(string v)
        {
            int i, pos = -1;
            for (i = 0; i < dataset.Salary.Rows.Count; i++)
            {
                if (dataset.Salary.Rows[i][0].ToString() == v)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }
        private void clear()
        {
            cmbID.SelectedIndex=0;
            cmbAtt.SelectedIndex=0; 
            cmbbonus.SelectedIndex=0;
            txtAbs.Text = "";
            txtname.Text = "";
            txtADVANCE.Text = "";
            txtBalance.Text = "";
            txtBase.Text = "";
            txtbonus.Text = "";
            txtExc.Text = "";
            txtPres.Text = "";
            dateTimePickerperiod.Value=DateTime.Now;
            
        }
        private void Salary_Load(object sender, EventArgs e)
        {
            dataset = new projetDB();
            salaryTableAd =new SalaryTableAdapter(); ;
            salaryTableAd.Fill(dataset.Salary);
            employeeTableAd = new employeeTableAdapter();
            employeeTableAd.Fill(dataset.employee);
            bonusTableAd = new BonusTableAdapter();
            bonusTableAd.Fill(dataset.Bonus);
            attendanceTableAd = new AttendanceTableAdapter();
            attendanceTableAd.Fill(dataset.Attendance);
            dataGridView1.DataSource = dataset.Salary;
            cmbID.DataSource = dataset.employee;
            cmbID.DisplayMember = "EmplID";
            cmbbonus.DataSource = dataset.Bonus;
            cmbbonus.DisplayMember = "Bnom";
            cmbbonus.ValueMember = "BAmt";
            cmbAtt.DataSource=dataset.Attendance;
            cmbAtt.DisplayMember = "AttNum";
            



        }
        
        private void btnSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbID.SelectedIndex == -1||cmbAtt.SelectedIndex == -1||cmbbonus.SelectedIndex == -1||txtAbs.Text == ""|| txtname.Text == ""||txtADVANCE.Text == ""||txtBalance.Text == ""||txtBase.Text == ""||txtbonus.Text == ""||txtExc.Text == ""||txtPres.Text == "")
                {
                    MessageBox.Show("fill the information");
                }
                else
                {
                double fb = double.Parse(txtBase.Text);
                int bas = (int)fb;
                salaryTableAd.InsertQuery(int.Parse(cmbID.Text), txtname.Text, bas, int.Parse(cmbbonus.SelectedValue.ToString()), int.Parse(txtADVANCE.Text),int.Parse(tax.ToString()), int.Parse(txtBalance.Text), dateTimePickerperiod.Value.ToShortDateString());
                    MessageBox.Show("Salary is Saved");
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            private void btnEdit_Click(object sender, EventArgs e)
        {
           

                if (cmbID.SelectedIndex == -1 || cmbAtt.SelectedIndex == -1 || cmbbonus.SelectedIndex == -1 || txtAbs.Text == "" || txtname.Text == "" || txtADVANCE.Text == "" || txtBalance.Text == "" || txtBase.Text == "" || txtbonus.Text == "" || txtExc.Text == "" || txtPres.Text == "")
                {
                    MessageBox.Show("fill the information");
                }
                else
                {
                    double fb = double.Parse(txtBase.Text);
                    int bas = (int)fb;
                    int x=int.Parse(salaryTableAd.ScalarQuery(int.Parse(cmbID.Text)).ToString());
                    salaryTableAd.UpdateQuery(int.Parse(cmbID.Text), txtname.Text,bas, int.Parse(cmbbonus.SelectedValue.ToString()), int.Parse(txtADVANCE.Text), (int)tax, int.Parse(txtBalance.Text), dateTimePickerperiod.Value.ToShortDateString(),x);
                    MessageBox.Show("Salary is updated");
                    clear();
                }
        }


      

        private void cmbAtt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string v = cmbAtt.Text;
            int i;
            for(i = 0; i < dataset.Attendance.Count; i++)
            {
                if (dataset.Attendance.Rows[i][0].ToString() == v)
                {
                    txtAbs.Text = dataset.Attendance.Rows[i][4].ToString();
                    txtExc.Text = dataset.Attendance.Rows[i][5].ToString();
                    txtPres.Text = dataset.Attendance.Rows[i][3].ToString();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employees employees = new Employees();
            employees.ShowDialog();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home home = new Home(); 
            home.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Employees employees1 = new Employees();
            employees1.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Bonus bonus1 = new Bonus();
            bonus1.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.ShowDialog(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home home  = new Home();
            home.ShowDialog();
        }

        private void cmbbonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string v = cmbbonus.Text;
            int i;
            for (i = 0; i < dataset.Bonus.Rows.Count; i++)
            {
                if (dataset.Bonus.Rows[i][1].ToString() == v)
                {
                    txtbonus.Text = dataset.Bonus.Rows[i][2].ToString();
                }

            }
        }

        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string v = cmbID.Text;
            int i;
            for (i = 0; i < dataset.employee.Rows.Count; i++)
            {
                if (dataset.employee.Rows[i][0].ToString() == v) 
                {
                    txtname.Text= dataset.employee.Rows[i][1].ToString();
                    txtBase.Text= dataset.employee.Rows[i][9].ToString();
                }
                
            }

        }

        private void btncal_Click(object sender, EventArgs e)
        {
            if (txtBase.Text == "" || txtbonus.Text == "" || txtADVANCE.Text == "")
            {
                MessageBox.Show("fill info");
            }
            else
            {
                pres = int.Parse(txtPres.Text);
                abs = int.Parse(txtAbs.Text);
                exc = int.Parse(txtExc.Text);
                daily=int.Parse(txtBase.Text)/30;
                adv = int.Parse(txtADVANCE.Text);
                bon= int.Parse(txtbonus.Text);

                total = ((daily) * pres) + ((daily / 2) * exc)-((daily)*abs)+bon;
                tax = total * 0.16;
                tottax = total - tax-adv;
                grdtot=tottax+int.Parse(txtBase.Text);
                txtBalance.Text=grdtot.ToString();
              
            }

        } 

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int g;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int h;
            dataGridView1.CurrentRow.Selected = true;
            int d = rechercher(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            g = int.Parse(dataset.Salary.Rows[d][0].ToString());
            cmbID.Text = dataset.Salary.Rows[d][1].ToString();
            txtname.Text = dataset.Salary.Rows[d][2].ToString();
            txtBalance.Text = dataset.Salary.Rows[d][3].ToString();
            for (h = 0; h < dataset.Bonus.Count; h++)
            {
                if (dataset.Bonus[h][0].ToString() == dataset.Salary[d][4].ToString())
                {
                    cmbbonus.Text= dataset.Bonus[h][1].ToString();
                    txtbonus.Text= dataset.Bonus[h][2].ToString();
                }
            }
            txtADVANCE.Text= dataset.Salary.Rows[d][5].ToString();
            tax = int.Parse(dataset.Salary[d][6].ToString());
            txtBalance.Text= dataset.Salary.Rows[d][7].ToString();
            dateTimePickerperiod.Value = DateTime.Parse(dataset.Salary.Rows[d][8].ToString());

        }
    }
}
