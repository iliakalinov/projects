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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  try
            // {
            string s0 = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя ";

        //    string s0 = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ";
            bool otvet = true;
            int a = -1;
            int b = -1;
            char c;
            string ss = textBox2.Text;
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
                a = a % 67;
            }
            if (ss.Length == 0) { otvet = false; }


            string s = richTextBox1.Text;
            //s = s.ToLower();

            for (int i = 0; i < s.Length; i++)//проверка на ввод символов
            {
                c = s[i];
                if (s0.IndexOf(c) == -1) { otvet = false; }
            }

            //проверка ключ.слова
            string ns = textBox1.Text;
            for(int i=0;i<ns.Length; i++)
            {
                c = ns[i];
                if (s0.IndexOf(c) == -1) { otvet = false; }
            }
            

            if (otvet == false)
            {
                MessageBox.Show("проверьте введенные данные ");

            }
            else//если все данные коректны;
            {
                if (radioButton1.Checked == true)
                {
                    string s2 = ns;
                    int k;
                    //создание строки
                    for(int i=0;i<67; i++)
                    {
                        c = s0[i];
                        if (s2.IndexOf(c) == -1) { s2 += s0[i];}
                    }
                    string sp;
                    sp =s2.Substring(67 - a, a) + s2.Substring(0, 67 - a);
                    s2 = "";
                    for (int i = 0; i < s.Length; i++)
                    {
                        c = s[i];
                       s2+=sp[s0.IndexOf(c)];
                    }
                    richTextBox2.Text = s2;




                }
                if (radioButton2.Checked == true)
                {
                    s = richTextBox2.Text;
                    string s2 = ns;
                    int k;
                    //создание строки
                    for (int i = 0; i < 67; i++)
                    {
                        c = s0[i];
                        if (s2.IndexOf(c) == -1) { s2 += s0[i]; }
                    }
                    string sp;
                    sp = s2.Substring(67 - a, a) + s2.Substring(0, 67 - a);

                    s2 = "";
                    for (int i = 0; i < s.Length; i++)
                    {
                        c = s[i];
                        s2 += s0[sp.IndexOf(c)];
                    }

                    richTextBox3.Text = s2;

                }



                }
            //   }
            //catch { MessageBox.Show("проверьте введенные данные..хз где "); }

        }
    }
}
