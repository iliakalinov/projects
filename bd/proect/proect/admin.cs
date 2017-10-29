using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace proect
{
    public partial class admin : Form
    {

        public static int new_id = 0;//новый , для добавления 
        public static int new_book_id = 0;//новый , для добавления 
        public admin()
        {
            InitializeComponent();
            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                            + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                            + "USER ID=PDB_BD;"))      //имя пользователя
            {

                OracleDataAdapter od = new OracleDataAdapter("select * from BOOK", oc);   //команда на выполнение
                OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                dataGridView2.DataSource = dt;      //записываем таблицу в датагрид
                int max = 0;
                int znach = 0;
                try
                {
                    for (int i = 0; i <= 50; i++)
                    {
                        znach = Convert.ToInt32(dataGridView2[0, i].Value.ToString());
                        if (max < znach) max = znach;

                    }
                }
                catch { }

                new_book_id = max + 1;


                using (OracleConnection occ = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                            + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                            + "USER ID=PDB_BD;"))      //имя пользователя
                {

                    OracleDataAdapter odd = new OracleDataAdapter("select * from STOCK ", occ);   //команда на выполнение
                    OracleCommandBuilder obb = new OracleCommandBuilder(od); //выполнение команды
                    DataTable dtt = new DataTable();     //виртуальная таблица для заполнения
                    od.Fill(dtt);                        //заполняем витуальную таблицу результатом запроса
                    dataGridView2.DataSource = dtt;      //записываем таблицу в датагрид
                    max = 0;
                    znach = 0;
                    try
                    {
                        for (int i = 0; i <= 50; i++)
                        {
                            znach = Convert.ToInt32(dataGridView2[0, i].Value.ToString());
                            if (max < znach) max = znach;

                        }
                    }
                    catch { }

                    new_id = max + 1;


                }
            }
        }
        public static int v;//выбор действия;



        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            


        }

        private void просмотрВсехКнигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                           + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                           + "USER ID=PDB_BD;"))      //имя пользователя
            {

                OracleDataAdapter od = new OracleDataAdapter("select * from BOOK", oc);   //команда на выполнение
                OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
            }
        }

        private void поискКнигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            




        }

        private void добавитьКнигиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v = 2;

            


            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = true;

           



            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;


            button1.Visible = true;
            button1.Text = "добавить";

        }

        private void добавитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            v = 3;
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            
            label6.Visible = true;
            label7.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            button1.Visible = true;
            button1.Text = "ввод";
            label9.Visible = false;
            textBox6.Visible = false;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v = 4;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;

            label8.Visible = true;
            label9.Visible = false;
            textBox6.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;



            button1.Visible = true;
            button1.Text = "удалить";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1, s2, s3, s4, s5, s6;
            //
            if (v == 1) { }
            //добавить книгу 
            if (v == 2) {

                s1 = textBox1.Text.ToString();
                s2 = textBox2.Text.ToString();
                s3 = textBox3.Text.ToString();
                s4 = textBox4.Text.ToString();
                s5 = textBox5.Text.ToString();
                s6 = textBox6.Text.ToString();
                using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                              + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                              + "USER ID=PDB_BD;"))      //имя пользователя
                {

                    

                    oc.Open();
                    int d = 0;

                    OracleCommand com = new OracleCommand("BEGIN NEW_BOOK('" + new_book_id.ToString() + "','" + s1.ToString() + "','" + s2.ToString() + "','" + s4.ToString() + "','" + s3.ToString() + "','" + s6.ToString() + "','" +s5.ToString() + "'); END;", oc);

                    com.ExecuteNonQuery();
                    new_book_id++;
                }




            }
            
            //добавить склад
            if (v == 3) {
                s1 = textBox1.Text.ToString();
                s2 = textBox2.Text.ToString();
                s3 = textBox3.Text.ToString();

                //строка подключения для соединения
                using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                              + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                              + "USER ID=PDB_BD;"))      //имя пользователя
                {

                    

                    oc.Open();
                    int d = 0;
                    string s = "  йцукенгшщзхъфывапролджэячсмитьбюёЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮQWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm-1234567890/.,[];";
                    string first_s = s1;
                    string two_s = s2;
                    string tri_s = s3;
                    int r = 3;
                    char c = first_s[1];
                    string s0 = "";
                    for (int i = 0; i < first_s.Length; i++)
                    {
                        c = first_s[i];
                        s0 += s[s.IndexOf(c) + r];
                    }
                    s1 = s0;
                    s0 = "";
                    for (int i = 0; i < two_s.Length; i++)
                    {
                        c = two_s[i];
                        s0 += s[s.IndexOf(c) + r];
                    }
                    s2 = s0;
                    s0 = "";
                    for (int i = 0; i < tri_s.Length; i++)
                    {
                        c = tri_s[i];
                        s0 += s[s.IndexOf(c) + r];
                    }
                    s3 = s0;

                    OracleCommand com = new OracleCommand("BEGIN new_stock('"+new_id.ToString()+"', '"+s1.ToString()+ "' , '" + s2.ToString() + "' ,'" + s3.ToString() + "' ); END; ", oc);
                    new_id ++; 
                    com.ExecuteNonQuery();
                }



            }
            //удалени по id
            if (v == 4) {
              string id_del =textBox1.Text.ToString();
                using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                          + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                          + "USER ID=PDB_BD;"))      //имя пользователя
                {

                    /* OracleDataAdapter od = new OracleDataAdapter("select * from CUSTOMERS_2", oc);   //команда на выполнение
                     OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                     DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                     od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                     dataGridView1.DataSource = dt;      //записываем таблицу в датагрид*/

                    oc.Open();
                    int d = 0;
                    string s = "delete from STOCK where id=" + id_del;
                    OracleCommand com = new OracleCommand( s, oc);
                    com.ExecuteNonQuery();
                }





            }
            if (v == 6)//поиск Книг по названию 
            {
                string s = textBox1.Text.ToString();
                using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                           + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                           + "USER ID=PDB_BD;"))      //имя пользователя
                {
                    s = "select * from BOOK where NAME_BOOK='" + s.ToString()+"'";
                    OracleDataAdapter od = new OracleDataAdapter(s, oc);   //команда на выполнение
                    OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                    DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                    od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                    dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
                }

            }
            if (v == 7)//поиск по автору;
            {

                string qw = textBox3.Text.ToString();
                using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                           + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                           + "USER ID=PDB_BD;"))      //имя пользователя
                {
                    string s = "select * from  BOOK where AUTHOUR='" + qw.ToString()+"'";
                    OracleDataAdapter od = new OracleDataAdapter(s, oc);   //команда на выполнение
                    OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                    DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                    od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                    dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
                    new_id++;
                }

            }
            if (v == 8)
            {
                string id_del = textBox1.Text.ToString();
                using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                          + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                          + "USER ID=PDB_BD;"))      //имя пользователя
                {

                    /* OracleDataAdapter od = new OracleDataAdapter("select * from CUSTOMERS_2", oc);   //команда на выполнение
                     OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                     DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                     od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                     dataGridView1.DataSource = dt;      //записываем таблицу в датагрид*/

                    oc.Open();
                    int d = 0;
                    string s = "delete from BOOK where id=" + id_del;
                    OracleCommand com = new OracleCommand(s, oc);
                    com.ExecuteNonQuery();
                }


            }
        
               


        }

        private void информацияОСкладахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                          + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                          + "USER ID=PDB_BD;"))      //имя пользователя
            {

                OracleDataAdapter od = new OracleDataAdapter("select * from STOCK", oc);   //команда на выполнение
                OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
                string s = "  йцукенгшщзхъфывапролджэячсмитьбюёЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮQWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm-1234567890/.,[];";
                string s2, s3, s4;
                string s0 = "";
                char c;
                try
                {
                    for (int i = 0; i <= 50; i++)
                    {
                        s2 = dataGridView1[1, i].Value.ToString();
                        s3 = dataGridView1[2, i].Value.ToString();
                        s4 = dataGridView1[3, i].Value.ToString();
                        if (s2.Length > 1)
                        {
                            for (int j = 0; j < s2.Length; j++)
                            {
                                c = s2[j];
                                s0 += s[s.IndexOf(c) - 3];

                            }
                            s2 = s0;
                            s0 = "";
                            for (int j = 0; j < s3.Length; j++)
                            {
                                c = s3[j];
                                s0 += s[s.IndexOf(c) - 3];

                            }
                            s3 = s0;
                            s0 = "";
                            for (int j = 0; j < s4.Length; j++)
                            {
                                c = s4[j];
                                s0 += s[s.IndexOf(c) - 3];
                            }
                            s4 = s0;
                            s0 = "";
                            dataGridView1[1, i].Value = s2.ToString();
                            dataGridView1[2, i].Value = s3.ToString();
                            dataGridView1[3, i].Value = s4.ToString();

                        }

                    }
                }
                catch  { }

            }


        }

        private void просмотрВссехToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                          + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                          + "USER ID=PDB_BD;"))      //имя пользователя
            {

                OracleDataAdapter od = new OracleDataAdapter("select * from FIRM", oc);   //команда на выполнение
                OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
            }
        }

        private void поНазваниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v = 6;
            label1.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            button1.Text = "поиск";
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;

            label9.Visible = false;
            textBox6.Visible = false;

        }

        private void поАвторуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v = 7;
            label3.Visible = true;
            textBox3.Visible = true;
            button1.Visible = true;
            button1.Text = "поиск";
            label2.Visible = false;
            label1.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;


            label9.Visible = false;
            textBox6.Visible = false;
        }

        private void сколькоКнигНаСкладахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v = 8;
        }

        private void книгиToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void выполненныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                           + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                           + "USER ID=PDB_BD;"))      //имя пользователя
            {

                OracleDataAdapter od = new OracleDataAdapter("select * from orders where DATA_PERFORMANCES is not null", oc);   //команда на выполнение
                OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
            }




        }

        private void admin_FormClosing(object sender, FormClosingEventArgs e)
        {
        
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void неВыполненныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                           + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                           + "USER ID=PDB_BD;"))      //имя пользователя
            {

                OracleDataAdapter od = new OracleDataAdapter("select * from orders where DATA_PERFORMANCES is NULL", oc);   //команда на выполнение
                OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
            }
        }

        private void просмотрИнформацииToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            v = 8;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;

            label8.Visible = true;
            label9.Visible = false;
            textBox6.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;



            button1.Visible = true;
            button1.Text = "удалить";

        }
    }
}
