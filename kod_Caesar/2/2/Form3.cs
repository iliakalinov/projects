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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  try
            // {
            string s0 = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя ";

           // string s0 = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ";
            bool otvet = true;
            int a = -1;
            int b = -1;
            char c;
            string ss = textBox1.Text;
            string sc = "01234567890";
            for (int i = 0; i < ss.Length; i++)//проверка только цифр
            {
                c = ss[i];
                if (sc.IndexOf(c) == -1) { otvet = false; }
            }
            if (ss.Length == 0) { otvet = false; }
            if (otvet == true)
            {
                a = Convert.ToInt32(ss);
              //  a = a % 34;
            }

            ss = textBox2.Text;
            for (int i = 0; i < ss.Length; i++)//проверка только цифр
            {
                c = ss[i];
                if (sc.IndexOf(c) == -1) { otvet = false; }
            }
            if (ss.Length == 0) { otvet = false; }
            if (otvet == true)
            {
                b = Convert.ToInt32(ss);
                //b = b % 34;
            }

            string s = richTextBox1.Text;
            //s = s.ToLower();

            for (int i = 0; i < s.Length; i++)//проверка на ввод символов
            {
                c = s[i];
                if (s0.IndexOf(c) == -1) { otvet = false; }
            }

            //проверка на взаймно простые числа;
            int zam;//для замены ;)
         
            for(int i = 2; i <=a; i++)
            {
                if ((a % i == 0) &&
                    (b % i == 0))
                { otvet = false; }
            }
            if ((a % 2 == 0) || (b % 2 == 0)) { otvet = false; }

            

            if (otvet == false)
            {
                MessageBox.Show("проверьте введенные данные ");

            }
            else//если все данные коректны;
            {
                if (radioButton1.Checked == true)
                {
                    string s2 = "";
                    int k;
                    for (int i = 0; i < s.Length; i++)
                    {
                        c = s[i];
                        k = s0.IndexOf(c);
                        k = (a*k+b)%67;
                        k = k % 67;
                        s2 = s2 + s0[k];
                    }
                    richTextBox2.Text = s2;
                }
                if (radioButton2.Checked == true)
                {
                    s = richTextBox2.Text;
                    string st = "";//для создание таблицы
                    for(int i =0; i < 67; i++)
                    {
                        st += s0[(i * a + b) % 67];
                   }

                    string s2 = "";
                    int k;
                    for (int i = 0; i < s.Length; i++)
                    {
                        c = s[i];
                        k = st.IndexOf(c);
                        s2 += s0[k];
                      
                    }


                    
                  
                    richTextBox3.Text = s2;
                }
            }
            //   }
            //catch { MessageBox.Show("проверьте введенные данные..хз где "); }

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
