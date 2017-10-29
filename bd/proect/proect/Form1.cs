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

namespace proect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void подключитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //строка подключения для соединения
            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                              +"PASSWORD=PDB_BD;"       //пароль пользователя
                                                              +"USER ID=PDB_BD;"))      //имя пользователя
            {

                /* OracleDataAdapter od = new OracleDataAdapter("select * from CUSTOMERS_2", oc);   //команда на выполнение
                 OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                 DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                 od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                 dataGridView1.DataSource = dt;      //записываем таблицу в датагрид*/

                oc.Open();
                OracleCommand com = new OracleCommand("insert into CUSTOMERS_2 values (222)",oc);
                com.ExecuteNonQuery();
            }
        }

        private void выводToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                             + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                             + "USER ID=PDB_BD;"))      //имя пользователя
            {

                OracleDataAdapter od = new OracleDataAdapter("select * from CUSTOMERS_2", oc);   //команда на выполнение
                OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
            }
            }

        private void калиноваToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                OracleCommand com = new OracleCommand($"begin ttt({d}); end;", oc);
                com.ExecuteNonQuery();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                              + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                              + "USER ID=PDB_BD;"))      //имя пользователя
            {
                
                oc.Open();
                OracleCommand com = new OracleCommand("truncate table CUSTOMERS_2", oc);
                com.ExecuteNonQuery();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //заполняем виртуальную таблицу результатом запроса
            string s = "123456789";
            string first_s= textBox1.Text.ToString();
            int r=3;
            char c = first_s[1];
            string s0 = "";
            for(int i = 0; i < first_s.Length; i++)
            {
                c = first_s[i];
                s0 +=s[s.IndexOf(c) + r];
            }
            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                             + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                             + "USER ID=PDB_BD;"))      //имя пользователя
            {
                oc.Open();
                s0 = "insert into CUSTOMERS_2 values (" + s0.ToString() + ")";
                OracleCommand com = new OracleCommand(s0.ToString(), oc);
                com.ExecuteNonQuery();
            }




        }

        private void ndwqToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
            
        }
    }
}
