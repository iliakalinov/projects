using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 newMDIChild = new Form2();
            newMDIChild.Show();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 newMDIChild = new Form3();
            newMDIChild.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 newMDIChild = new Form4();
            newMDIChild.Show();
        }
    }
}
