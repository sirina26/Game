using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using ESfml.Game.View;

namespace ESfml
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            /* PlayWithMac pwm = new PlayWithMac();
             pwm.Run();*/
            Thread th = new Thread(new ThreadStart(StartForm));
            th.Start();
            Thread.Sleep(5000);
            Application.Run(new frmSplashScreen());
            th.Abort();
        }
        public static void StartForm()
        {
            Application.Run(new frmSplashScreen());
        }
    }
}
