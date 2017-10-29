using System;
using System.Windows.Forms;

namespace Hemming
{
    public partial class Form1 : Form
    {
        Coder coder;
        Decoder decoder;
        public int aaa;

        public Form1()
        {
            InitializeComponent();
            
            
           
            
        }
        
        private void Transmit_Click(object sender, EventArgs e)
        {
            if (Stat.Text != string.Empty)
            {
                string a = Send.Text;
                string b = Recv.Text;

          //      if (a.Length + (int)Math.Log((b.Length+1),2)  == b.Length)
       //         {
                    decoder = new Decoder(aaa);
                    coder.Code(Converter.ConvertToArray(Send.Text));
                    decoder.Decode(Converter.ConvertToArray(Recv.Text));
                    ErrorText.Text = "";


                    Stat.Text = coder.PrintInformation();
                    Stat2.Text = decoder.PrintInformation();
         //       }
            //    else Stat2.Text = "потеря данных";
            }
            else MessageBox.Show("введите текст для поля \"подсчитать\"");
        }

    
        private void Send_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(e.KeyChar == '1' || e.KeyChar == '0' || e.KeyChar == Convert.ToChar(8));
        }
        private void Recv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(e.KeyChar == '1' || e.KeyChar == '0' || e.KeyChar == Convert.ToChar(8));
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(e.KeyChar == '1' || e.KeyChar == '0' || e.KeyChar == Convert.ToChar(8));
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(e.KeyChar == '1' || e.KeyChar == '0' || e.KeyChar == Convert.ToChar(8));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Send.Text != string.Empty)
            {
                aaa = Convert.ToInt32(Send.Text.Length);
                coder = new Coder(aaa);
                coder.Code(Converter.ConvertToArray(Send.Text));

                Stat.Text = coder.PrintInformation();
                Recv.Text = coder.PrintInformation1();
            }
            else MessageBox.Show("Введите текст");
          


        }

        private void Recv_TextChanged(object sender, EventArgs e)
        {

        }

        private void Stat2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Stat_TextChanged(object sender, EventArgs e)
        {

        }

        private void Send_TextChanged(object sender, EventArgs e)
        {

        }
    }
}