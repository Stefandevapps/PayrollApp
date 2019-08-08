using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayroolSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Visible = false;
            label4.Visible = false;
            textBox4.Visible = false;
            label5.Visible = false;
            textBox6.Visible = false;
            label7.Visible = false;
            textBox7.Visible = false;
            label8.Visible = false;
        }


        private void comboEmpType_DropDown(object sender, EventArgs e)
        {
            
        }

        private void comboEmpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEmpType.SelectedItem.Equals("Hourly Employee"))
            {
                textBox3.Visible = true;
                label4.Visible = true;
                textBox4.Visible = false;
                label5.Visible = false;
                textBox6.Visible = false;
                label7.Visible = false;
                textBox7.Visible = true;
                label8.Visible = true;
                textBox2.Visible = false;
                label3.Visible = false;


            }
            if (comboEmpType.SelectedItem.Equals("Salaried Employee"))
            {
                textBox3.Visible = false;
                label4.Visible = false;
                textBox4.Visible = false;
                label5.Visible = false;
                textBox6.Visible = false;
                label7.Visible = false;
                textBox7.Visible = false;
                label8.Visible = false;
                textBox2.Visible = true;
                label3.Visible = true;




            }
            if (comboEmpType.SelectedItem.Equals("Commission Employee"))
            {
                textBox3.Visible = false;
                label4.Visible = false;
                textBox4.Visible = true;
                label5.Visible = true;
                textBox6.Visible = true;
                label7.Visible = true;
                textBox7.Visible = false;
                label8.Visible = false;
                textBox2.Visible = true;
                label3.Visible = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCalPay_Click(object sender, EventArgs e)
        {

            int base_salary = 0;
            int hours_total = 0;
            int working_pay = 0;
            int comission_rate = 0;
            double net_salary = 0;
            int sales_done = 0;
            string op = "";


            if (comboEmpType.SelectedItem == null)
            {
                MessageBox.Show("Please Select Employee Type.");
                textBox3.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
            else
            {
                if (comboEmpType.SelectedItem.Equals("Salaried Employee"))
                {
                    base_salary = GetInt(textBox2.Text);

                    Calculation_of_salary salEmp = new Calculation_of_salary(base_salary);

                    net_salary = salEmp.CalculateSalariedEmployee();

                    op = "\t\t\t  PAYSLIP\r\n\r\n\r\n\r\n" +
                        "\t Name of Employee -  " + textBox1.Text + "\r\n\r\n" +
                        "\t NI No.- " + textBox5.Text + "\r\n\r\n" +
                        "\t Employee Category -  " + comboEmpType.SelectedItem + "\r\n\r\n" +
                        "\t Base Salary - " + textBox2.Text + "\r\n\r\n" +
                        "\t Total Salary(Net Salary)-  " + net_salary;

                }
                if (comboEmpType.SelectedItem.Equals("Hourly Employee"))
                {
                    working_pay = GetInt(textBox7.Text);

                    hours_total = GetInt(textBox3.Text);

                    Calculation_of_salary salEmp = new Calculation_of_salary(hours_total, working_pay);

                    net_salary = salEmp.CalculateHourlyEmployee();

                    int hours_overtime = 0;

                    if (hours_total > 40)
                    {
                        hours_overtime = hours_total - 40;
                    }

                    op = "\t\t\t  PAYSLIP\r\n\r\n\r\n\r\n" +
                        "\t Name of Employee -  " + textBox1.Text + "\r\n\r\n" +
                        "\t NI No.- " + textBox5.Text + "\r\n\r\n" +
                        "\t Employee Category -  " + comboEmpType.SelectedItem + "\r\n\r\n" +
                        "\t Total Work Done(Hours) - " + textBox3.Text + "\r\n\r\n" +
                        "\t Overtime Done (Hours) - " + hours_overtime + "\r\n\r\n" +
                        "\t Working Pay(Per Hours) - " + textBox7.Text + "\r\n\r\n" +
                        "\t Total Salary(Net Salary)-  " + net_salary;

                }



                if (comboEmpType.SelectedItem.Equals("Commission Employee"))
                {
                    sales_done = GetInt(textBox4.Text);

                    comission_rate = GetInt(textBox6.Text);

                    base_salary = GetInt(textBox2.Text);

                    Calculation_of_salary salEmp = new Calculation_of_salary(base_salary, sales_done, comission_rate);

                    net_salary = salEmp.CalculateCommissionEmployee();
                    op = "\t\t\t  PAYSLIP\r\n\r\n\r\n\r\n" +
                        "\t Name of Employee -  " + textBox1.Text + "\r\n\r\n" +
                        "\t NI No.- " + textBox5.Text + "\r\n\r\n" +
                        "\t Employee Category -  " + comboEmpType.SelectedItem + "\r\n\r\n" +
                        "\t Base Salary - " + textBox2.Text + "\r\n\r\n" +
                        "\t Sales Figures- " + textBox4.Text + "\r\n\r\n" +
                        "\t Commission Rate of Employee- " + textBox6.Text + "\r\n\r\n" +
                        "\t Total Salary(Net Salary)-  " + net_salary;


                }

                new Payroll(op).Show();
                this.Visible = false;
            }

            




            
        }


        public int GetInt(String input)
        {
            int value = 0;
            try
            {
                value = Int32.Parse(input);
            }
            catch(Exception e)
            {
                MessageBox.Show("Please enter a int value");
            }

            return value;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
