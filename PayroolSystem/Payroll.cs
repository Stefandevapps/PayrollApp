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
    public partial class Payroll : Form
    {
        private string output;
        public Payroll(string output)
        {
            this.output = output;
            InitializeComponent();
        }

        private void Payroll_Load(object sender, EventArgs e)
        {
            textBox1.Text = output;
        }
    }
}
