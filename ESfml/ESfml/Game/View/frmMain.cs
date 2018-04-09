using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ESfml.Game.View
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            Thread th = new Thread(new ThreadStart(StartForm));
            th.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            th.Abort();
        }
        public void StartForm()
        {
            Application.Run(new frmSplashScreen());
        }
    }
}
