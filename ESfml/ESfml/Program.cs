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

namespace PlayWithMac
{
    static class Program
    {
        public static void Main(string[] arg)
        {
            Menu menu = new Menu(1200, 750);
            RenderWindow window = new RenderWindow(new VideoMode(1200, 750), "PlayWithMac");

            while (window.IsOpen)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Z))
                {
                    menu.Move(Keyboard.Key.Z);
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    menu.Move(Keyboard.Key.S);
                }

                else if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
                {
                    if (menu.SelectedItemIndex == 0)
                    {
                        window.Close();
                        Games game = new Games();
                        game.Run();
                        break;
                    }
                    else if (menu.SelectedItemIndex == 1)
                    {
                        //Programme pour envoyer dans l'options
                        /*window.Close();
                        Option option = new Option();
                        option.Run();*/
                        break;

                    }
                    else if (menu.SelectedItemIndex == 2)
                    {
                        window.Close();
                    }
                }

                menu.Draw(window);
                window.Display();
                Thread.Sleep(85);
            }
        }
    }
}
