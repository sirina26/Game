using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using PlayWithMac.Model;

namespace PlayWithMac
{
    public class LevelView
    {
        Levelcontexte _contexte;
        RenderWindow _windows;

        public LevelView(uint width, uint heigth)
        {
            _windows = new RenderWindow(new VideoMode(width, heigth), "PlayWithMac");
        }

        public void Run()
        {
            Textures.init();
            _contexte = new Levelcontexte();
            bool res;

            while (_windows.IsOpen)
            {
                _windows.Clear(/*backgroundColor*/);

                _contexte.Actions(_windows);
                _contexte.PerformActions();
                _contexte.DrawObjets(_windows);
                res = _contexte.RemoveNotAliveObjets(_windows);
                _contexte.DrawGameOver(_windows, res);
                _contexte.RemoveHeart();

                _windows.DispatchEvents();
                _windows.Display();

                System.Threading.Thread.Sleep(15);
            }
        }
    }
}
