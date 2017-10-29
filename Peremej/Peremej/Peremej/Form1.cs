using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peremej
{
    
    public partial class Form1 : Form
    {

       
        public Form1()
        {

            InitializeComponent();
    //        textBox2.Enabled = false;
      //      textBox3.Enabled = false;
        }
        int K = 0;
        int R = 0;
        string soob;
        public int osh = 0;
        private void textBox1_Leave(object sender, EventArgs e)
        {
            K = Convert.ToInt32(textBox1.Text);
      

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
           
            if(K%Convert.ToInt32(textBox3.Text)!=0)
            {
                MessageBox.Show("Не делится K/R");
            }
            else
            {
                if( Convert.ToInt32(textBox3.Text) > 3)
                R = Convert.ToInt32(textBox3.Text);
                else MessageBox.Show("R должно быть больше не менее 4");
            }

        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
        }
     
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox2.TextLength > K)
            {
                string s = textBox2.Text.ToString();
                string s0="";
                
                for(int i =0;i<K;i++)
                {
                    s0 += s[i];
                }
                textBox2.Text = s0;
            }
            else
            {
                soob = textBox2.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            int k = R;
            int r = Convert.ToInt32(Math.Round(Math.Log(k) + 2));
            
            R = Convert.ToInt32(textBox3.Text);
            int[] Soobshch = new int[textBox2.TextLength];
            int[,] Matrica = new int[k + r, K/R];
          for(int i=0;i<textBox2.TextLength;i++)
            {
                if(textBox2.Text[i]==48)
                {
                    Soobshch[i] = 0;
                }
                if(textBox2.Text[i]==49)
                {
                    Soobshch[i] = 1;
                }
            }
          int[] inf_soob = new int[k];

          int[,] ProvMatHeming = Metods.HemingKodprMat(r, k, inf_soob);
          richTextBox1.Clear();
          richTextBox1.Text += "Проверочная матрица:\n";
          for (int i = 0; i < r; i++)
          {
              for (int j = 0; j < k + r; j++)
              {
                  richTextBox1.Text += Convert.ToString(ProvMatHeming[j, i]) + " ";
              }
              richTextBox1.Text += Environment.NewLine;
          }
            
          Matrica = Metods.StroimMatr(Soobshch,K, R);
           
            richTextBox1.Text +=  "матрица закодирования:\n";
            for(int i=0;i<K/R;i++)
            {
                for(int j=0;j<r+k;j++)
                {
                    richTextBox1.Text += Convert.ToString(Matrica[j, i]) + " ";
                }
                richTextBox1.Text += "\n";
            }
            int posPer = 0;
            for(int i=0;i<k+r;i++)
            {
                for(int j =0;j<K/R;j++)
                {
                  
                    textBox4.Text += Convert.ToString(Matrica[i, j]) ;
                    posPer++;
      
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //textBox7.Text = "";
            //textBox6.Text = "";
            int k = R;
            int r = Convert.ToInt32(Math.Round(Math.Log(k) + 2));
            int[,] PrishMatr = new int[k + r, K / R];
            int[,] IsprMatrica = new int[k + r, K / R];
            int[] prinsoobshPoKa = new int[r + k];
            
            int position = 0;
            for (int i = 0; i <k+r; i++)
            {
                for (int j = 0; j <K/R; j++)
                {

                    if(textBox4.Text[position]==48)
                    {
                        PrishMatr[i, j] = 0;
                    }
                    else
                    {
                        PrishMatr[i, j] = 1;
                    }
                    position++;
               
                }
            }
            int positionsimb = 0;
            int[] peremejSoobshch = new int[(k + r) * (K / R)];
            for(int i=0;i<K/R;i++)
            {
                for(int j=0;j<r+k;j++)
                {
                    peremejSoobshch[positionsimb] = PrishMatr[j, i];
                    positionsimb++;
                }
            }
            richTextBox2.Clear();
            richTextBox2.Text += "Матрица по принятову кодовому слову:\n";
            for(int i=0;i<K/R;i++)
            {
                for(int j=0;j<k+r;j++)
                {
                    richTextBox2.Text += Convert.ToString(PrishMatr[j, i]) + " ";
               //    textBox6.Text += Convert.ToString(PrishMatr[j, i]) + " ";
                }
             //   textBox6.Text += Environment.NewLine;
              richTextBox2.Text += "\n";
            }
            int[] sindrom = new int[r];
            int[] soobshcenka = new int[k + r];
            int[] inf_soob = new int[k];
            
            int[,] ProvMatHeming = Metods.HemingKodprMat(r, k, inf_soob);
            //textBox9.Text = "";
            int[,] newsindrom = new int[K/R,r];
            richTextBox2.Text += "Новые проверочные символы:\n";
            for (int id = 0; id < K / R; id++)
            {
                for (int i = 0; i < r; i++)
                {
                    int sum = 0;
                    for (int j = 0; j < k; j++)
                    {
                        sum += ProvMatHeming[j, i] * PrishMatr[j, id];
                        //        textBox9.Text += Convert.ToString(ProvMatHeming[j, i]) +" ";
                    }
                  //  newsindrom[id, i] = sum % 2;
                    richTextBox2.Text += sum % 2;
                    //textBox9.Text += Environment.NewLine;
                }
                richTextBox2.Text += "\n";
            }
            newsindrom[0, 0] += 1;
            richTextBox2.Text += "Синдром\n";
            for (int i=0;i<K/R;i++)
            {
                for(int j=0;j<(k+r);j++)
                {
                    soobshcenka[j] = PrishMatr[j, i];
                        }
                sindrom = Metods.sindrom(r, k, soobshcenka);
                for(int j=0;j<r;j++)
                {
                    newsindrom[i, j] = sindrom[j];
                    richTextBox2.Text += Convert.ToString(sindrom[j]);
                }
                richTextBox2.Text += Environment.NewLine;
            }
            int[,] ProvMatHeming1 = Metods.HemingKodprMat(r, k, inf_soob);
            //richTextBox2.Text += "вектор ошибок\n";
            //int [] masiv = new int [K/R];
            //bool ff = true;
            //for(int id = 0; id < K/R; id++)
            //{
            //for (int i = 0; i < k;i++ )
            //{
            //    int a = 0;
            //    for(int n = 0; n < r ; n++)
            //    {
            //        if (newsindrom[id, n] == ProvMatHeming1[i, n]) a++;
            //    }
            //    if(a == 3)
            //    {
            //        ff = false;
            //        masiv[id] = i;
            //        break;
            //    }
            //}
            //}
            //bool fl = true;
            //for (int i = 0; i < K / R; i++) if (masiv[i] != 0) fl = false;
            //if (fl && !ff)
            //{
            //    for (int i = 0; i < K / R; i++)
            //    {
            //        for (int n = 0; n < k; n++)
            //        {
            //            if (masiv[i] == n) richTextBox2.Text += 1;
            //            else richTextBox2.Text += 0;

            //        }
            //        richTextBox2.Text += "\n";
            //    }
            //}
            

                IsprMatrica = Metods.IspravlMatr(peremejSoobshch, R, K);
            richTextBox2.Text += "Исправленная матрица:\n";
            for(int i=0;i<K/R;i++)
            {
                for(int j=0;j<k+r;j++)
                {
                    //textBox7.Text += Convert.ToString(IsprMatrica[j, i]) + " ";
                    richTextBox2.Text += Convert.ToString(IsprMatrica[j, i]) + " ";
                }
                //textBox7.Text += Environment.NewLine;
                richTextBox2.Text += "\n";
            }

            richTextBox2.Text += "Исправленное принятое кодовое сообщение:\n ";
            

            for (int i = 0; i < k + r; i++)
            {
                for (int j = 0; j < K / R; j++)
                {

                    richTextBox2.Text += Convert.ToString(IsprMatrica[i, j]);
                   
                }

            }
            richTextBox2.Text += "\nсообщение:\n";
            for(int i=0;i<K/R;i++)
            {
                for(int j =0;j<k;j++)
                {
                   richTextBox2.Text += IsprMatrica[j, i];
                }
            }
   
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

