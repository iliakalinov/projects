using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.IO;

namespace курсач
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        
        [STAThread]
        static void Main()
        {


            StreamReader sr = new StreamReader("lang.txt");
            string lang = sr.ReadLine();
            sr.Close();

            switch (lang)
            {
                case "ru":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
                   
                    break;
                case "en":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                   
                    break;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
