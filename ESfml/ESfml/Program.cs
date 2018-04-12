using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using ESfml.Game.View;

using SFML.System;
using SFML.Window;
using SFML.Audio;
using SFML.Graphics;

namespace ESfml
{
    static class Program
    {
       
        [STAThread]
        static void Main()
        {
            /*
                          PlayWithMac pwm = new PlayWithMac();
                          pwm.Run();
                         Thread th = new Thread(new ThreadStart(StartForm));
                         th.Start();
                         Thread.Sleep(5000);
                         Application.Run(new frmSplashScreen());
                         th.Abort();*/

            Menu menu = new Menu();
            menu.Run();
        }
        /*public static void Main(string[] arg)
        {
            
        }*/
    }
}
