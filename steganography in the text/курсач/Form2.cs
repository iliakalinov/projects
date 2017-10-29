using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсач
{
    public partial class Form2 : Form
    {
        public int n=1;//счетчик , что показывать;
        public Form2()
        {
            InitializeComponent();
        }

        private void two()
        {
            label1.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            pictureBox1.Visible = false;
            pictureBox4.Visible = true;

           pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            label3.Visible = true;
            label5.Visible = true;

            pictureBox5.Visible = false;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (n < 3)
            {
                n++;
                if (n == 2)
                {
                    two();
                }
                 if (n == 3)
                {
                    label1.Visible = false;
                    label2.Visible = false;
                    label4.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox4.Visible = false;

                    pictureBox2.Visible = false;
                    pictureBox3.Visible = true;
                    label3.Visible = false;
                    label5.Visible = false;
                    pictureBox5.Visible = true;    
                 } 
          
               
            }




        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (n > 0)
            {
                n--;
                if (n == 1)
                {
                    label1.Visible = true;
                    label2.Visible = true;
                    label4.Visible = true;
                    pictureBox1.Visible = true;


                   pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    label3.Visible = false;
                    label5.Visible = false;

                    pictureBox5.Visible = false;
                }
                if (n == 2)
                {
                    two();
                }
            }
        }
        ////
    }
}
