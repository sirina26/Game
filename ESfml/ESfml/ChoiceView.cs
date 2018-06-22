using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayWithMac.Model;
using SFML.Graphics;
using SFML.Window;

namespace PlayWithMac
{
    public class ChoiceView
    {
        ChoiceLevel choix;
        RenderWindow window;
        static ContextSettings settings = new ContextSettings();
        static Color backgroundColor = new Color(5, 70, 55, 1);
        uint _width;
        uint _heigth;

        public ChoiceView(uint width, uint heigth)
        {
            choix = new ChoiceLevel(width, heigth);
            window = new RenderWindow(new VideoMode(width, heigth), "PlayWithMac", Styles.Default, settings);
            _width = width;
            _heigth = heigth;
        }

        public void Run()
        {
            
            while (window.IsOpen)
            {
                window.Clear(/*backgroundColor*/);

                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                   choix. Move(Keyboard.Key.Up);
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    choix.Move(Keyboard.Key.Down);
                }

                else if (Keyboard.IsKeyPressed(Keyboard.Key.P))
                {
                    if (choix.SelectedItemIndex == 0)
                    {
                        window.Close();
                        LevelView level = new LevelView(_width, _heigth, 1);
                        level.Run();

                    }
                    else if (choix.SelectedItemIndex == 1)
                    {
                        window.Close();
                        LevelView level = new LevelView(_width, _heigth,2);
                        level.Run();
                    }
                    else if (choix.SelectedItemIndex == 2)
                    {
                        window.Close();
                        LevelView level = new LevelView(_width, _heigth, 3);
                        level.Run();
                    }
                }

                choix.Draw(window);
                window.Display();
                //System.Threading.Thread.Sleep(15);
            }
        }
    }
}
