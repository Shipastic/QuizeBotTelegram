using BotTelegramDB.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotTelegramDB
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);           
            //using (MainForm mainForm = new MainForm())
            //{
            //    Application.Run(mainForm);
            //}
            Application.Run(new MainForm());
        }
    }
}
