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
    public class EducationGameView
    {
        RenderWindow windowGame2;
        EducationGame educ;

        public EducationGameView(uint width, uint heigth)
        {
            windowGame2 = new RenderWindow(new VideoMode(width, heigth), "PlayWithMac");
            educ = new EducationGame(width, heigth);
        }

        public void Run()
        {
            while (windowGame2.IsOpen)
            {
                /* if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                 {
                     ques.Move(Keyboard.Key.Up);
                 }
                 else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                 {
                     ques.Move(Keyboard.Key.Down);
                 }
                 else */
                if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
                {

                    if (educ.SelectedItemIndex == 0)
                    {
                        //windowHandler.Draw(answer);

                    }
                    else
                    {

                    }
                }

                educ.Draw(windowGame2);
                windowGame2.Display();


            }
        }
    }
}
