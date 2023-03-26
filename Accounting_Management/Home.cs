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
    public partial class Home : Form
    {
        projetDB dataset;
        employeeTableAdapter employeeTableAd;
        SalaryTableAdapter salaryTableAd;

        int i;
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Employees em = new Employees();
            em.ShowDialog();   
            this.Close();
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
        int a=0,b=0,c=0;

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Bonus bonus = new Bonus();
            bonus.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            Salary salary = new Salary();
            salary.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            per = 0;
            for (w = 0; w < dataset.employee.Count; w++)
            {
                if (dataset.employee[w][6].ToString() == "Senior")
                {
                    for (h = 0; h < dataset.Salary.Count; h++)
                    {
                        if (dataset.employee[w][0].ToString() == dataset.Salary[h][1].ToString())
                        {
                            per = per + int.Parse(dataset.Salary[h][7].ToString());
                        }
                    }
                }
            }
            labelsolo.Text = per.ToString();
           
        }

        private void label13_Click(object sender, EventArgs e)
        {
            per = 0;
            for (w = 0; w < dataset.employee.Count; w++)
            {
                if (dataset.employee[w][6].ToString() == "Manager")
                {
                    for (h = 0; h < dataset.Salary.Count; h++)
                    {
                        if (dataset.employee[w][0].ToString() == dataset.Salary[h][1].ToString())
                        {
                            per = per + int.Parse(dataset.Salary[h][7].ToString());
                        }
                    }
                }
            }
            labelsolo.Text = per.ToString();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            per = 0;
            for (w = 0; w < dataset.employee.Count; w++)
            {
                if (dataset.employee[w][6].ToString() == "Junior")
                {
                    for (h = 0; h < dataset.Salary.Count; h++)
                    {
                        if (dataset.employee[w][0].ToString() == dataset.Salary[h][1].ToString())
                        {
                            per = per + int.Parse(dataset.Salary[h][7].ToString());
                        }
                    }
                }
            }
            labelsolo.Text = per.ToString();
        }

        int g,sal=0,h,w,per=0;
        private void Home_Load(object sender, EventArgs e)
        {
            
            dataset = new projetDB();
            employeeTableAd = new employeeTableAdapter();
            employeeTableAd.Fill(dataset.employee);
            salaryTableAd = new SalaryTableAdapter();
            salaryTableAd.Fill(dataset.Salary);
            for (g = 0; g < dataset.Salary.Count; g++)
            {
                sal =sal+int.Parse(dataset.Salary[g][7].ToString());   
            }
            labelsaltotal.Text = sal.ToString();

            for (i= 0; i < dataset.employee.Count; i++)
            {
                if(dataset.employee[i][6].ToString()== "Manager")
                {                  
                    a++;
                }
                if (dataset.employee[i][6].ToString() == "Senior")
                {                
                    b++;
                }
                if (dataset.employee[i][6].ToString() == "Junior")
                {
                    c++;
                }
            }
            labelempNum.Text = b.ToString();
            labelmanNum.Text = a.ToString();
            LabelQuaNum.Text = c.ToString();
            
        }
    }
}
