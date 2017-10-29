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
    public partial class co : Form
    {
        public co()
        {
            InitializeComponent();
        }

        public static int v;
        private void просотрЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void выбратьЗаказToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s;
            int a =Convert.ToInt32(textBox1.Text.ToString());

            DateTime thisDay = DateTime.Today;
            using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                           + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                           + "USER ID=PDB_BD;"))      //имя пользователя
            {

                s = "update orders set DATA_PERFORMANCES = '" + thisDay.ToString()+"' where id=" + a.ToString()+"";
                 OracleDataAdapter od = new OracleDataAdapter(s.ToString(), oc);   //команда на выполнение
                OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
            }


        }
    }
}
