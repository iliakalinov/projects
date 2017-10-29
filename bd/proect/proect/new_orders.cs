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
    public partial class new_orders : Form
    {
        public static int id = 7;
        public static string ss;
        public new_orders(string s)
        {
            InitializeComponent();
            ss = s;
            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                           + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                           + "USER ID=PDB_BD;"))      //имя пользователя
            {

                OracleDataAdapter od = new OracleDataAdapter("select * from BOOK ", oc);   //команда на выполнение
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

                id = max + 1;
            }
        }
        

     
        public static int v = 1;

        private void new_orders_Load(object sender, EventArgs e)
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

        private void поИмениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v = 1;
            label1.Visible = true;
            label1.Text = "название";
            textBox1.Visible = true;
            button1.Visible = true;
            button1.Text = "поиск";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (v == 1) {//поиск по имени;
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
            if (v == 2)
            {
                string s = textBox1.Text.ToString();
                using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                           + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                           + "USER ID=PDB_BD;"))      //имя пользователя
                {
                    s = "select * from  BOOK where AUTHOUR='" + s+"'";
                    OracleDataAdapter od = new OracleDataAdapter(s, oc);   //команда на выполнение
                    OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                    DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                    od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                    dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
                }





            }
            if (v == 3)
            {
                
                
                string s1 = textBox1.Text.ToString();
                string s2 = textBox2.Text.ToString();
                string s3 = textBox3.Text.ToString();
                string s4 = textBox4.Text.ToString();
                string s5 = textBox4.Text.ToString();

                DateTime thisDay = DateTime.Today;


                using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                              + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                              + "USER ID=PDB_BD;"))      //имя пользователя
                {

                  

                    oc.Open();
                    int d = 0;
                    id+=5;
                    OracleCommand com = new OracleCommand("BEGIN new_orders('"+id.ToString()+"','"+ s1.ToString() + "' , '" + s2.ToString() + "' ,'" + s3.ToString() + "','" + s4.ToString() + "','" + s5.ToString() + "','" + thisDay.ToString() + "','"+ss.ToString()+"'); END; ", oc);
                    id++;
                    com.ExecuteNonQuery();
                }


            }

            if (v == 4)//по тематике
            {

                string s = textBox1.Text.ToString();
                using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                           + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                           + "USER ID=PDB_BD;"))      //имя пользователя
                {
                    s = "select * from BOOK where Subjects='" + s.ToString() + "'";
                    OracleDataAdapter od = new OracleDataAdapter(s, oc);   //команда на выполнение
                    OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                    DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                    od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                    dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
                }



            }

            if (v == 5)
            {
                string s = textBox1.Text.ToString();
                using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                              + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                              + "USER ID=PDB_BD;"))      //имя пользователя
                {                  
                    oc.Open();
                    OracleCommand com = new OracleCommand("delete from Orders where  ID=" + s.ToString() + " and ID_CLIENT=" + ss.ToString(), oc);
                    com.ExecuteNonQuery();
                }




            }
            if (v == 6)//редактирование 
            {
                label1.Visible = true;
                label1.Text = "количество";
                label3.Visible = true;
                label3.Text = "id_книги";
                label4.Visible = true;
                label4.Text = "адрес";
                label5.Visible = true;
                label5.Text = "телефон";
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;

                button1.Name = "сохранить";
                string st = textBox1.Text.ToString();
                int k = 0;
              /*  if(dataGridView1[1, 0].Value.ToString() == st) { k = 0; }
                if (dataGridView1[1, 1].Value.ToString() == st) { k = 1; }
                if (dataGridView1[1, 2].Value.ToString() == st) { k = 2; }

                if (dataGridView1[1, 3].Value.ToString() == st) { k = 3; }
                if (dataGridView1[1, 4].Value.ToString() == st) { k = 4; }*/
                textBox1.Text = dataGridView1[2, k].Value.ToString();
                textBox2.Text = dataGridView1[1, k].Value.ToString();
                textBox3.Text = dataGridView1[3, k].Value.ToString();
                textBox4.Text = dataGridView1[4, k].Value.ToString();

                int m = 0;
                

                using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                                              + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                                              + "USER ID=PDB_BD;"))      //имя пользователя
                {
                    oc.Open();
                    OracleCommand com = new OracleCommand("UPDATE " + m.ToString() , oc);
                    com.ExecuteNonQuery();
                }

            }


        }

        private void поАвторуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v = 2;
            label1.Visible = true;
            label1.Text = "автор";
            textBox1.Visible = true;
            button1.Visible = true;
            button1.Text = "поиск";
        }

        private void оформитьЗаказToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v = 3;


            label1.Visible = true;
            label1.Text = "количество";
            label3.Visible = true;
            label3.Text = "id_книги";
            label4.Visible = true;
            label4.Text = "адрес";
            label5.Visible = true;
            label5.Text = "телефон";
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;



            button1.Visible = true;
            button1.Text = "оформить";


        }

        private void new_orders_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void поToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v = 4;
            label1.Visible = true;

            label1.Text = "название";
            textBox1.Visible = true;
            button1.Visible = true;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void просмотрВсехМоихЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;

            button1.Visible = false;
            button1.Text = "выбрать";



            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                       + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                       + "USER ID=PDB_BD;"))      //имя пользователя
            {
                string s = "select * from ORDERS where ID_CLIENT='" + ss.ToString() + "'";
                OracleDataAdapter od = new OracleDataAdapter(s, oc);   //команда на выполнение
                OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
            }

        }

        private void азToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;



            label1.Visible = true;
            label1.Text = "удаление \n заказа:";
            textBox1.Visible = true;
            button1.Text = "удалить";
            button1.Visible = true;
            v = 5;

            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                     + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                     + "USER ID=PDB_BD;"))      //имя пользователя
            {
                string s = "select * from ORDERS where  DATA_PERFORMANCES is null and  ID_CLIENT='" + ss.ToString() + "'";
                OracleDataAdapter od = new OracleDataAdapter(s, oc);   //команда на выполнение
                OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
            }



        }

        private void редактироватьЗаказToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;



            label1.Visible = true;
            label1.Text = "изменение \n заказа:";
            textBox1.Visible = true;
            button1.Text = "выбрать ";
            button1.Visible = true;
            v = 6;

            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                     + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                     + "USER ID=PDB_BD;"))      //имя пользователя
            {
                string s = "select * from ORDERS where  DATA_PERFORMANCES is null and  ID_CLIENT='" + ss.ToString() + "'";
                OracleDataAdapter od = new OracleDataAdapter(s, oc);   //команда на выполнение
                OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
