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
    public partial class new_user : Form
    {
        public new_user()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string  s2="", s3="", s4="";
            s2 = textBox1.Text.ToString();
            s3 = textBox3.Text.ToString();
            s4 = textBox5.Text.ToString();


            if((s2 == "") || (s3 == "") || (s4 == ""))
            {
                MessageBox.Show("ошибка ввода данных");
                
            }
            
            else
            {
                using (OracleConnection oc = new OracleConnection("DATA SOURCE=DESKTOP-UGCSCSS:1521/PDB_BD;"    //источник данных имя_компа:порт/имя_пдб
                                                            + "PASSWORD=PDB_BD;"       //пароль пользователя
                                                            + "USER ID=PDB_BD;"))      //имя пользователя
                {

                    OracleDataAdapter od = new OracleDataAdapter("select * from users ", oc);   //команда на выполнение
                    OracleCommandBuilder ob = new OracleCommandBuilder(od); //выполнение команды
                    DataTable dt = new DataTable();     //виртуальная таблица для заполнения
                    od.Fill(dt);                        //заполняем витуальную таблицу результатом запроса
                    dataGridView1.DataSource = dt;      //записываем таблицу в датагрид
                    int max = 0;
                    int znach=0;
                    try
                    {
                       for (int i = 0; i <= 50; i++)
                        {
                            znach = Convert.ToInt32(dataGridView1[0, i].Value.ToString());
                            if (max < znach) max = znach;

                        }
                    }
                    catch { }
                    max++;
    
                    oc.Open();
                    int d = 0;
                    OracleCommand com = new OracleCommand("BEGIN new_user('"+max.ToString()+ "' , '" + s2.ToString() + "' ,'" + s3.ToString() + "','" + s4.ToString() +"'); END; ", oc);
                    com.ExecuteNonQuery();
                }
                MessageBox.Show("регистрирование произошло успешно");


            }


        }
    }
}
