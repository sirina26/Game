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
        LevelContext _contexte;
        RenderWindow _windows;
        uint _width;
        uint _heigth;

        public LevelView(uint width, uint heigth)
        {
            _width = width;
            _heigth = heigth;
            
        }

        public void RunLevel()
        {
            _windows = new RenderWindow(new VideoMode(_width, _heigth), "PlayWithMac");
            Textures.init();
            _contexte = new LevelContext();
            //bool res;

            while (_windows.IsOpen)
            {
                _windows.Clear(/*backgroundColor*/);

                _contexte.Actions();
                _contexte.PerformActions();
                _contexte.DrawObjets(_windows);
                _contexte.RemoveNotAliveObjets();
               // _contexte.DrawGameOver(_windows, res);
                _contexte.RemoveHeart();
                _contexte.RemoveMoney();

                _windows.DispatchEvents();
                _windows.Display();

                System.Threading.Thread.Sleep(15);
            }
        }
    }
}
