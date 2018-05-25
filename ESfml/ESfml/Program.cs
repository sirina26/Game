using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using SFML.System;
using SFML.Window;
using SFML.Audio;
using SFML.Graphics;
using System.Threading;
using PlayWithMac.Model;

namespace PlayWithMac
{
    class Program
    {
        //static RenderWindow windowGame = new RenderWindow(new VideoMode(1200, 700), "PlayWithMac");

        static void Main(string[] args)
        {
            const uint width = 1200;
            const uint heigth = 700;

            Menu menu = new Menu(width, heigth);
            
           // Options op = new Options(1200, 700);

             RenderWindow windowMenu = new RenderWindow(new VideoMode(1200, 700), "PlayWithMac");
           // RenderWindow windowOp = new RenderWindow(new VideoMode(1200, 700), "PlayWithMac");
           // Textures.init();
           // window.Closed += Window_Closed;
           // Levelcontexte level = new Levelcontexte();

            while (windowMenu.IsOpen)
            {
                 if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                 {
                     menu.Move(Keyboard.Key.Up);
                 }
                 else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                 {
                     menu.Move(Keyboard.Key.Down);
                 }

                 else if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
                 {
                     if (menu.SelectedItemIndex == 0)
                     {
                        windowMenu.Close();

                        ChoiceView choix = new ChoiceView(width, heigth);
                        choix.Run();
                                               
                        break;
                    }
                    else if (menu.SelectedItemIndex == 1)
                    {
                        /*while (windowOp.IsOpen)
                        {
                            op.Draw(windowOp);
                            //op.Display();
                        }*/
                        break;
                    }
                    else if (menu.SelectedItemIndex == 2)
                    {
                        windowMenu.Close();
                        break;
                    }
                }

                menu.Draw(windowMenu);
                windowMenu.Display();
            }
        }

      /*  private static void Window_Closed(object sender, EventArgs e)
        {
            windowGame.Close();
        }*/
    }
}
