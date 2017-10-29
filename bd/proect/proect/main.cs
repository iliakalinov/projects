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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text.ToString() == "admin") && (textBox2.Text.ToString() == "admin"))
                {
                    admin ad = new admin();
                    ad.Show();

                }
                else
                {

                    if ((textBox1.Text.ToString() == "courier") && (textBox2.Text.ToString() == "courier"))
                    {
                        co c = new co();
                        c.Show();

                    }


                    else
                    {
                        string s1 = textBox1.Text.ToString();
                        string s2 = textBox2.Text.ToString();

                        using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                              + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                              + "USER ID=PDB_BD;"))      //имя пользователя
                        {
                            // string s0 = "select * from USERS where login = 'ili' and passwrod = 'ili'";
                            string s0 = "select * from USERS where login= '" + s1.ToString() + "' and passwrod= '" + s2.ToString() + "' ";
                            OracleDataAdapter od = new OracleDataAdapter(s0.ToString(), oc);   //команда на выполнение
                            OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                            DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                            od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                            dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
                            if (dataGridView1[0, 0].Value.ToString() != "")
                            {
                                new_orders n = new new_orders(dataGridView1[0, 0].Value.ToString());
                                n.Show();


                            }
                        }
                    }
                }
            }
            catch { }
        }


            


        

        private void label3_Click(object sender, EventArgs e)
        {
            new_user us = new new_user();
            us.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* new_orders n = new new_orders();
            n.Show();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            new_user us = new new_user();
            us.Show();
        }
    }
}
