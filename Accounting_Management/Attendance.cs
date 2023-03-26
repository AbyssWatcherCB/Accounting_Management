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
    public partial class Attendance : Form
    {
        projetDB dataset;
        AttendanceTableAdapter AttendanceTableAd;
        employeeTableAdapter EmployeeTableAd;
        int g;
        public Attendance()
        {
            InitializeComponent();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            dataset = new projetDB();
            AttendanceTableAd = new AttendanceTableAdapter();
            AttendanceTableAd.Fill(dataset.Attendance);
            EmployeeTableAd= new employeeTableAdapter();
            EmployeeTableAd.Fill(dataset.employee);
            dataGridView1.DataSource = dataset.Attendance;

            cmbID.DataSource = dataset.employee;
            cmbID.DisplayMember = "EmplID";
        }
        public int rechercher(string v)
        {
            int i, pos = -1;
            for (i = 0; i < dataset.Attendance.Rows.Count; i++)
            {
                if (dataset.Attendance.Rows[i][0].ToString() == v)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }
        private void clear()
        {
            cmbID.SelectedIndex= 0;
            txtnom.Text = "";
            txtAb.Text = "";
            txtEx.Text = "";
            txtpre.Text = "";
            dateTimePickerperiod.Value=DateTime.Now;
        }
        private void btnSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbID.SelectedIndex == -1||txtnom.Text == ""||txtAb.Text == ""||txtEx.Text == ""||txtpre.Text == "")
                {
                    MessageBox.Show("fill the information");
                }
                else
                {
                  AttendanceTableAd.InsertQuery(int.Parse(cmbID.Text), txtnom.Text, int.Parse(txtpre.Text), int.Parse(txtAb.Text), int.Parse(txtEx.Text), dateTimePickerperiod.Value.ToShortDateString());
                  MessageBox.Show("Attendance is Saved");
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
            try
            {
                if (cmbID.SelectedIndex == -1 || txtnom.Text == "" || txtAb.Text == "" || txtEx.Text == "" || txtpre.Text == "")
                {
                    MessageBox.Show("fill the information");
                }
                else
                {
                    AttendanceTableAd.UpdateQuery(int.Parse(cmbID.Text), txtnom.Text, int.Parse(txtpre.Text), int.Parse(txtAb.Text), int.Parse(txtEx.Text), dateTimePickerperiod.Value.ToShortDateString(),g);
                    MessageBox.Show("Attendance is edited");
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
                if (cmbID.SelectedIndex == -1 || txtnom.Text == "" || txtAb.Text == "" || txtEx.Text == "" || txtpre.Text == "")
                {
                    MessageBox.Show("fill the information");
                }
                else
                {
                    AttendanceTableAd.DeleteQuery(g);
                    MessageBox.Show("Attendance is deleted");
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
            int d =rechercher(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            g= int.Parse(dataset.Attendance.Rows[d][0].ToString());
            cmbID.Text = dataset.Attendance.Rows[d][1].ToString();
            txtnom.Text = dataset.Attendance.Rows[d][2].ToString();
            txtpre.Text = dataset.Attendance.Rows[d][3].ToString();
            txtAb.Text = dataset.Attendance.Rows[d][4].ToString();
            txtEx.Text = dataset.Attendance.Rows[d][5].ToString();
            dateTimePickerperiod.Value = DateTime.Parse(dataset.Attendance.Rows[d][6].ToString());

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < dataset.employee.Count; i++)
            {
                if (dataset.employee.Rows[i][0].ToString() == cmbID.Text)
                {
                    txtnom.Text= dataset.employee.Rows[i][1].ToString();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.ShowDialog();  
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Salary salary = new Salary();
            salary.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Bonus bonus = new Bonus();
            bonus.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Employees employees = new Employees();
            employees.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Salary salary = new Salary();
            salary.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
