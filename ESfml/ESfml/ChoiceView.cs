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
        //ChoiceLevel choix;
        //RenderWindow window;
        LevelView level;
        static ContextSettings settings = new ContextSettings();
        static Color backgroundColor = new Color(5, 70, 55, 1);
        uint _width;
        uint _heigth;
        ChoiceLevel choix;
        RenderWindow window;

        public ChoiceView(uint width, uint heigth)
        {
            
            _width = width;
            _heigth = heigth;
            //Runchoice();
            //window = win;
        }

        public void Runchoice()
        {
            choix = new ChoiceLevel(_width, _heigth);
           RenderWindow window = new RenderWindow(new VideoMode(_width, _heigth), "PlayWithMac", Styles.Default, settings);
            
             //int test = 1;

            while (window.IsOpen)
            {
                window.Clear(/*backgroundColor*/);

                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                   choix.MoveSelect(Keyboard.Key.Up);
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    choix.MoveSelect(Keyboard.Key.Down);
                }

                else if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    if (choix.Selectchoice == 0)
                    {
                       window.Close();
                       level = new LevelView(_width, _heigth);
                       level.RunLevel();
                       break;
                    }
                    else if (choix.Selectchoice == 1)
                    {
                        window.Close();
                        break;
                    }
                    else if (choix.Selectchoice == 2)
                    {
                        window.Close();
                        break;
                    }
                }

               
                choix.Draw(window);
                window.DispatchEvents();
                window.Display();
                //System.Threading.Thread.Sleep(50);

            }
        }
    }
}
