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
    public class Options
    {
        ChoiceOption choix;
        RenderWindow window;
        static ContextSettings settings = new ContextSettings();
        static Color backgroundColor = new Color(5, 70, 55, 1);
        uint _width;
        uint _heigth;
       
        public Options(uint width, uint heigth)
        {
            choix = new ChoiceOption(width, heigth);
            window = new RenderWindow(new VideoMode(width, heigth), "PlayWithMac", Styles.Default, settings);
            _width = width;
            _heigth = heigth;
        }
       
        public void Run()
        {

            while (window.IsOpen)
            {
                window.Clear();

                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    choix.Move(Keyboard.Key.Up);
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    choix.Move(Keyboard.Key.Down);
                }

                else if (Keyboard.IsKeyPressed(Keyboard.Key.P))
                {
                    Sounds s = new Sounds();

                    if (choix.SelectedItemIndex == 0)
                    {
                        s.OnOff(true);
                        window.Close();
                    }
                    else if (choix.SelectedItemIndex == 1)
                    {
                        s.OnOff(false);
                        window.Close();
                    }
                }

                choix.Draw(window);
                window.Display();
            }
        }
    }
}
