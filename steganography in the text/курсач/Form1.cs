using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;
using System.Threading;
using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
//пробелы -1 и 32;


namespace курсач
{
  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.richTextBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.richTextBox1_DragEnter);
            this.richTextBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.richTextBox2_DragEnter);
            this.richTextBox3.DragEnter += new System.Windows.Forms.DragEventHandler(this.richTextBox3_DragEnter);
        }    
        private void richTextBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }
        private void richTextBox2_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {


            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;

        }
        private void richTextBox3_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        } 
        void minys()               //меняет размер окна
        {
            richTextBox1.Height += 100;
            richTextBox1.MaximumSize = new Size(279, 96);          //изменение размера
            richTextBox1.MinimumSize = new Size(50, 50);          //изменение размера
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "спрятать текст")
                {
                    if (radioButton3.Checked == true)
                        {
                            richTextBox3.Text = one.first(richTextBox1.Text, richTextBox2.Text);
                        }     
                        
                   if (radioButton4.Checked == true)
                       {
                           richTextBox3.Text = dva.two(richTextBox1.Text, richTextBox2.Text);
                       }   
                                   
                    if (radioButton5.Checked == true)
                       {

                           richTextBox3.Text = tri.tree(richTextBox1.Text, richTextBox2.Text);
                        }
                        
                    if (radioButton6.Checked == true)
                        {

                            richTextBox3.Text = chet.four(richTextBox1.Text, richTextBox2.Text);
                        }                                      

                    if (radioButton1.Checked == true)
                        {                    
                            richTextBox3.Text = piat.five(richTextBox1.Text, richTextBox2.Text);                
                        }
                   richTextBox4.ForeColor = Color.Green;
                    richTextBox4.Text = "ВЫПОЛНЕНО";
                  }
            }
               catch (Exception ex)
                        {
                            richTextBox4.ForeColor = Color.Red;
                            richTextBox4.Text = "Ошибка: " + ex.Message;
                        }

            if (comboBox1.Text == "получить текст")
            {
                if (radioButton3.Checked == true)
                {
                    richTextBox3.Text = one.firsttwo(richTextBox1.Text);
                }
                if (radioButton4.Checked == true)
                {
                    richTextBox3.Text = dva.twotwo(richTextBox1.Text);
                }    
                if (radioButton5.Checked == true)
                {
                    richTextBox3.Text = tri.treetwo(richTextBox1.Text);
                }
                if (radioButton6.Checked == true)
                {
                    richTextBox3.Text = chet.fourtwo(richTextBox1.Text);
                }
                if (radioButton1.Checked == true)
                {
                    richTextBox3.Text = piat.fivetwo(richTextBox1.Text);
                }

            }                          
        }
        private void button1_Click_1(object sender, EventArgs e)
        {


            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "f:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            var streamR = new StreamReader(openFileDialog1.FileName.ToString(), Encoding.UTF8);
                            string s0 = streamR.ReadToEnd();
                            richTextBox1.AppendText(s0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }



            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "f:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            var streamR = new StreamReader(openFileDialog1.FileName.ToString(), Encoding.UTF8);
                            string s0 = streamR.ReadToEnd();
                            richTextBox2.AppendText(s0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }



            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Text files|*.txt";
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                saveFile1.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(saveFile1.FileName, true))
                {
                    sw.WriteLine(richTextBox3.Text);
                    sw.Close();

                }

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "получить текст")
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                richTextBox3.Text = "";
                button2.Visible = false;                            //убрать кнопки(видемость)
                richTextBox2.Visible = false;
                richTextBox1.MinimumSize = new Size(279, 200);          //изменение размера
                richTextBox1.Height -= 100;
        

            }

            if (comboBox1.Text == "спрятать текст")
            {
                richTextBox3.Text = "";

              

                minys();
                minys();


                button2.Visible = true;                            //вкл 
                richTextBox2.Visible = true;
            




            }
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
    }
    //для 1-го метода
    static class one
    {
        public static string first(string testString, string s)
        {
            //s для чтения;
            string s1 = "";//результат;
            string s0 = "";//для 2-го кода);
            int i;
            byte[] unicodeBytes = Encoding.Unicode.GetBytes(testString); //Получаем байты строки в кодировке UTF-16 (Unicode)
            string ss;//чтоб было 9 символов 
            for (i = 0; i < unicodeBytes.Length; i++) //проходимся по массиву байтов
            {
                ss = Convert.ToString(unicodeBytes[i], 2);
                for (int j = ss.Length; j < 8; j++)
                {
                    ss = "0" + ss;
                }
                s0 += ss;
            }
            int lengths0 = s0.Length;

            int nomer = 0;//номер для 2-го кода(счетчик)


            string schar;
            string sall = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMйцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";


            for (i = 0; i < s.Length; i++)
            {
                schar = Convert.ToString(s[i]);//берем элемент со строки


                if ((sall.IndexOf(schar) != -1) && (nomer < lengths0))            //если элимент != пробелу
                {
                    if (s0[nomer] == '1') { s1 += schar.ToUpperInvariant(); }    //if 1 то верхний регистр , else нижний 
                    else s1 += schar.ToLower();
                    //+ в строку
                    nomer++;

                }
                else s1 += schar.ToLower();
            }
            if (nomer < lengths0) throw new Exception(" НЕОБХОДИМО БОЛЬШЕ ТЕКСТА");
            return s1.ToString();
        }
        public static string firsttwo(string s0)
        {
            //s0 --считывание строки 
            string sall = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMйцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";

            List<byte> lst = new List<byte>();
            string sb = "";         //строка с 8 символами 
            int nomer = 1;          //отсчитывает 8 символов
            string c;             //для проверки регистра )

            for (int i = 0; i < s0.Length; i++)
            {

                c = Convert.ToString(s0[i]);
                if (sall.IndexOf(c) != -1)
                {
                    if (Convert.ToChar(s0[i]) == Convert.ToChar(c.ToUpper()))
                    {
                        sb += '1';
                    }
                    else sb += '0';
                    nomer++;
                }
                if (nomer == 9)
                {
                    lst.Add(Convert.ToByte(sb, 2));
                    sb = "";
                    nomer = 1;

                }
            }

            string r = Encoding.Unicode.GetString(lst.ToArray());//итог           
            return r.ToString();


        }

    }
    //для 2-го метода
    static class dva
    {
        public static string two(string testString ,string s)
        {
            string s0 = "";//строка в 2 предствавлении
            string sexit = "";//результат
            char c0 = Convert.ToChar(32);//равняется 0
            char c1 = Convert.ToChar(1);//равняется 1
            int nomer = 0;//номер элемента для вставки(0 или 1 )
          
            byte[] unicodeBytes = Encoding.Unicode.GetBytes(testString); //Получаем байты строки в кодировке UTF-16 (Unicode)
            string ss;//чтоб было 9 символов 

            for (int i = 0; i < unicodeBytes.Length; i++) //проходимся по массиву байтов
            {
                ss = Convert.ToString(unicodeBytes[i], 2);
                for (int j = ss.Length; j < 8; j++)
                {
                    ss = "0" + ss;
                }
                s0 += ss;
            }
                  
            string schar;
            string otvet="";

            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] == ' ') && (nomer < s0.Length))   //смотрим если пробел в строке, и есть чем его заменить
                {
                    if (s0[nomer] == '1') { sexit += c1; }
                    else sexit += c0;
                    nomer++;

                }
                else
                {
                    sexit += s[i];
                }

            }
            if (nomer < s0.Length) throw new Exception(" НЕОБХОДИМО БОЛЬШЕ ТЕКСТА");
            else
            {

                otvet += sexit.ToString();
            }
           
            return otvet;
        }
        public static string twotwo(string s0){
            

            List<byte> lst = new List<byte>();
            string sb = "";         //строка с 8 символами 
            int nomer = 1;          //отсчитывает 8 символов
            char c0 = Convert.ToChar(32);//равняется 0
            char c1 = Convert.ToChar(1);//равняется 1
            char c;

            for (int i = 0; i < s0.Length; i++)
            {

                c = s0[i];
                if ((c == c0) || (c == c1))
                {
                    if (c == c1)
                    {
                        sb += '1';
                    }
                    else sb += '0';
                    nomer++;
                }
                if (nomer == 9)
                {
                    lst.Add(Convert.ToByte(sb, 2));
                    sb = "";
                    nomer = 1;

                }
            }
            string r = Encoding.Unicode.GetString(lst.ToArray());//итог
            return r.ToString();
        }

    }
    //для 3-го метода
    static class tri
    {
        public static string tree(string s0,string s1 )
        {
                
            string sus = "qwertyuiopasdfghjklzxcvbnm";
            string sru = "йцукенгшщзхфыъапролджэячсмитьбю";
            int ius = 0, iru = 0;
            for (int i = 0; i < s1.Length; i++)            //проверка 1 ли язык используется для написания
            {              
                if (sus.IndexOf(Convert.ToChar(s1[i])) != -1) { ius++; }
                if (sru.IndexOf(Convert.ToChar(s1[i])) != -1) { iru++; }
            }
            if (ius * iru != 0) throw new Exception(" ОПРЕДЕЛИТЕСЬ С ЯЗЫКОМ ВВОДЫ");
          
            string sall = sus + sru;
             string sbit = "";
             byte[] unicodeBytes = Encoding.Unicode.GetBytes(s0); //Получаем байты строки в кодировке UTF-16 (Unicode)
             string ss;//чтоб было 9 символов 

             for (int i =0; i < unicodeBytes.Length; i++) //проходимся по массиву байтов
             {
                 ss = Convert.ToString(unicodeBytes[i], 2);
                 for (int j = ss.Length; j < 8; j++)
                 {
                     ss = "0" + ss;
                 }
                 sbit += ss;
             }

             string s2 = "";
             int nomer = 0;//определяет номер в sus, или sru;
            int posinbit=0;
            //eopaxc
            //еорахс
            sus = "eopaxc";
            sru = "еорахс";
            sall = sus + sru;
            s2 += s1[0];
            s2 += s1[1];
            s2 += s1[2];
            for ( int  i = 3; i < s1.Length; i++)
             {
                 if (sall.IndexOf(Convert.ToChar(s1[i])) != -1)
                 {

                     if (posinbit < sbit.Length)
                     {
                         //добаыить переполнение в bit масиве;
                         if (sbit[posinbit] == '1')
                         {
                             nomer = 0;
                             nomer = sus.IndexOf(Convert.ToChar(s1[i]));
                             if (nomer != -1) { s2 += sru[nomer]; }
                             
                             nomer = sru.IndexOf(Convert.ToChar(s1[i]));
                             if (nomer != -1) { s2 += sus[nomer]; }
                             
                             posinbit++;
                         }
                         else
                         {
                             s2 += s1[i];
                             posinbit++;

                         }

                     }
                 }
             
                 else
                 {
                     s2 += s1[i];
                 }

               
             
             }
             for (int i = s2.Length; i < s1.Length; i++)
             {
                 s2 += s1[i];
             }
            if (posinbit < sbit.Length) { throw new Exception(" НЕОБХОДИМО БОЛЬШЕ ТЕКСТА"); }
          
             return s2.ToString();

        }
        public static string treetwo(string s0)
        {
       
            string sus = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
            string sru = "йцукенгшщзхфыъапролджэячсмитьбюЁЙЦУКЕНГШЩЗХЪЖЖДЭЛОРПАВЫФЯЧСМИТЬБЮ";
            string ssall = sus + sru;
            int lang = 0;//определяте какой язык основной 1-англ 2-рус

            if ((sus.IndexOf(s0[0]) != -1)
                && (sus.IndexOf(s0[1]) != -1))
            { lang = 1; }
            if ((sru.IndexOf(s0[0]) != -1)
                && (sru.IndexOf(s0[1]) != -1))
            { lang = 2; }
            //    sus = "eopaxc";
            //    sru = "еорахс";
            string s01 = "";     //обратные (если бит=1)
            string sall = "еорахсeopaxc";     //все;
            if (lang == 1) { s01 = "еорахс"; }
            if (lang == 2) { s01 = "eopaxc"; }
            int nomer = 1;

            List<byte> lst = new List<byte>();
            string sb = "";         //строка с 8 символами 
            char c;

            for (int i = 3; i < s0.Length; i++)
            {

                c = s0[i];
                if (sall.IndexOf(c) != -1)
                {
                    if (s01.IndexOf(c) != -1)
                    {
                        sb += 1;
                        nomer++;
                    }
                    else
                    {
                        sb += 0;
                        nomer++;
                    }
                    if (nomer == 9)
                    {
                        lst.Add(Convert.ToByte(sb, 2));
                        sb = "";
                        nomer = 1;

                    }
                }
            }
            string r = Encoding.Unicode.GetString(lst.ToArray());//итог

             return r.ToString();     
        }
    }
    //для 4-го метода
    static class chet
    {
        public static string four(string s1,string s2){
            


            string line = System.IO.File.ReadAllText(@"string.txt");
            

            for (int i = 0; i < s1.Length; i++)                     //проверка , все ли элементы находятся в файле
            {
                if (line.IndexOf(s1[i]) == -1)
                {
                    line += s1[i];
                }
            System.IO.File.WriteAllText(@"string.txt", line);
                                
            }

            string sall = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMйцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";

            int nomer = 0;//какой элемент в строке прячем;
            int n = 0;//какой это номер в файле(строке)
            char c;
           int j = 0;//подсчет сколько элементов спрятали
            Random rand = new Random();
            int r;
            string dva="";          //записывается поcледовательность регистров
            int ch = 0;             //сколько элементов поменял регист
            int k = 0; ;
            string s3 = "";
            int nl = 0;
            n = line.IndexOf(s1[nomer]);
            nomer++;
            n++;
            n = n * 2;
          //  char c2;            //для изменения регистра          
            r = rand.Next(3);
            if (r == 0) { dva = "00"; }
            if (r == 1) { dva = "01"; }
            if (r == 2) { dva = "10"; }

            string snew = ""; //для нового регистра
          
           
            int ni = 0;
            for (int i = 0; i < s2.Length;i++){
                c = s2[i];
                if (sall.IndexOf(c) != -1)
                {
                    if (ni != (n - 3))
                    {
                        if (nl != 2)
                        {
                            snew += c;
                            if (dva[nl] == '0')
                            {
                                s3 += snew.ToLower();
                            }
                            else
                            {
                                s3 += snew.ToUpper();

                            }

                            snew = "";
                            nl++;
                        }
                        if (nl == 2)
                        {
                            snew = "";
                            r = rand.Next(3);
                            if (r == 0) { dva = "00"; }
                            if (r == 1) { dva = "01"; }
                            if (r == 2) { dva = "10"; }
                            nl = 0;
                        }

                    }
                    else
                    {
                        if (nl != 2)
                        {
                            snew += c;
                            if (dva[nl] == '0')
                            {
                                s3 += snew.ToLower();
                            }
                            else
                            {
                                s3 += snew.ToUpper();

                            }
                            snew = "";
                            nl = 0;
                        }
                        dva = "11";
                        j++;
                        if (nomer < s1.Length) { n = n + (line.IndexOf(s1[nomer]) * 2); nomer++;  }
                        else n = s2.Length + 2;
                      
                     }


                    ni++;
                }
                else
                {
                    snew += c;
                    s3 += snew.ToLower();
                    snew = "";
                }
            
            }
           
        if ((j<s1.Length)||(s2.Length<4)) throw new Exception(" НЕОБХОДИМО БОЛЬШЕ ТЕКСТА");

        return s3.ToString();
        }
        public static string fourtwo(string s1)
        {
             string sall="qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMйцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
            string s0="";//состоит только из букв
            string s3 = "";
            for (int i = 0; i < s1.Length; i++)
            {
                if (sall.IndexOf(s1[i]) != -1) { s0 += s1[i]; }
            }

            string line = System.IO.File.ReadAllText(@"string.txt");

            char c1, c2;
            int n=0;

            for (int i = 2; i < s0.Length-1; i=i+2)
            {
                c1 = s0[i];
                c2 = s0[i + 1];

                if ((Convert.ToChar(Convert.ToString(c1).ToUpper()) == Convert.ToChar(s0[i])) && 
                        (Convert.ToChar(Convert.ToString(c2).ToUpper()) == Convert.ToChar(s0[i+1])))
                {
                    s3 += line[n + 1];
                    n = 0;
                   
                }
                else
                {
                    n++;
                }
            }

            return  s3.ToString();
            
        }

    }
    //для 5-го метода
    static class piat
    {
        public static string five(string s1,string s2)
        {
            
            string sallru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string sallus = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";


            int iru = 0, ius = 0;

            for (int i = 1; i < s2.Length; i++)         //проверка на ввод 1 языка
            {
                if (sallru.IndexOf(s2[i]) != -1) { iru++; }
                if (sallus.IndexOf(s2[i]) != -1) { ius++; }
            }
            if ((iru != 0) && (ius != 0)) { throw new Exception(" ОПРЕДЕЛИТЕСЬ С ЯЗЫКОМ ВВОДЫ"); }

            sallru = " абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            sallus = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";


            string sus = "eopaxcEOPAXC";
            string sru = "еорахсЕОРАХС";
            string sn = "";          //строка с таким же языком что и ввод
            string sk = "";          //строка с другим языком



            int ch = 0;      //  номер элемента

            int k = 0; ;

            int[] mass = new int[s1.Length * 2 + 1];

            if (iru != 0)
            {          //если язык русския то получяем значения для символ чтоб потом скрывать по 2-ум чиаслам
                sn = sru;
                sk = sus;
                k = 0;
                int m;
                for (int j = 0; j < s1.Length; j++)
                {
                    m = sallru.IndexOf(s1[j]);
                    m++;
                    mass[k] = 1;

                    while (m > 5)
                    {
                        mass[k]++;
                        m -= 5;
                    }
                    mass[k + 1] = m;
                    k = k + 2;
                }

            }
            if (ius != 0)
            {
                sn = sus;
                sk = sru;
                k = 0;
                int m;
                for (int j = 0; j < s1.Length; j++)
                {
                    m = sallus.IndexOf(s1[j]);
                    m++;
                    mass[k] = 1;

                    while (m > 5)
                    {
                        mass[k]++;
                        m -= 5;
                    }
                    mass[k + 1] = m;
                    k = k + 2;
                }

            }


            string s3 = "";
            s3 += s2[0];
            int ik = 1;       //номер в массиве mass
            int chislo = mass[0];     //ik элемент в массиве mass

            for (int i = 1; i < s2.Length; i++)
            {
                if (sn.IndexOf(s2[i]) != -1)
                {
                    if (chislo != 1)
                    {
                        s3 += (sk[sn.IndexOf(s2[i])]);
                        chislo -= 1;
                    }
                    else
                    {
                        s3 += s2[i];
                        if (ik <= k)
                        {
                            chislo = mass[ik];
                            ik++;
                        }
                    }

                }
                else { s3 += s2[i]; }




            }
            int mm = 0;
            if (ik < mass.Length) { throw new Exception(" неоюходимо больше текста"); }
            return s3.ToString();

        }
        public static string fivetwo(string s1)
        {
            string sus = "eopaxcEOPAXC";
            string sru = "еорахсЕОРАХС";
            string sallru = " абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string sallus = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string saalitog = "";

            string sn = "";
            string sk = "";
            if (sallru.IndexOf(s1[0]) != -1)//если 1 элемент русский , то необходимо считать англ символы
            {
                sn = sru;
                sk = sus;
                saalitog = sallru;

            }
            if (sallus.IndexOf(s1[0]) != -1)//если 1 элемент англ , то необходимо считать руские символы
            {
                sn = sus;
                sk = sru;
                saalitog = sallus;

            }


            string s3 = "";       //итоговое 
            int chislo = 0;   //считает сколько было замен

            int n = 1;      //if n=2 значит у нас есть 2 числа и можем вернуть 1 символ
            int nomer = 1;  //номер элемента в строке, который возвращаем;

            for (int i = 1; i < s1.Length; i++)
            {
                if (sn.IndexOf(s1[i]) != -1)
                {
                    if (n == 1)
                    {
                        chislo++;
                        nomer = 5 * (chislo - 1);
                        chislo = 0;
                        n++;
                    }
                    else
                    {
                        nomer += chislo;
                        s3 += saalitog[nomer];
                        chislo = 0;
                        n = 1;
                    }


                }
                if (sk.IndexOf(s1[i]) != -1)
                {
                    chislo++;

                }
            }

            return s3.ToString();


        }
    }
}
