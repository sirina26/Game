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
        int _level;

        public LevelView(uint width, uint heigth, int level)
        {
            _windows = new RenderWindow(new VideoMode(width, heigth), "PlayWithMac");
            _level = level;
        }

        public void Run()
        {
            Textures.init(_level);
            _contexte = new LevelContext(_level);

            while (_windows.IsOpen)
            {
                _windows.Clear(/*backgroundColor*/);

                _contexte.Actions();
                _contexte.PerformActions();
                _contexte.DrawObjets(_windows);
                _contexte.RemoveNotAliveObjets();
                _contexte.RemoveHeart();
                _contexte.RemoveMoney();

                _windows.DispatchEvents();
                _windows.Display();

                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                {
                    _windows.Close();
                }
                System.Threading.Thread.Sleep(15);
            }
        }
    }
}
