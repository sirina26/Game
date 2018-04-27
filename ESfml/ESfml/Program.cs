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
    class Program
    {
        static ContextSettings settings = new ContextSettings();
        static RenderWindow window = new RenderWindow(new VideoMode(1200, 700), "PlayWithMac", Styles.Default, settings);

        static void Main(string[] args)
        {
            Menu menu = new Menu(1200, 700);
             RenderWindow windowMenu = new RenderWindow(new VideoMode(1200, 700), "PlayWithMac");

            Textures.init();
            window.Closed += Window_Closed;
            Levelcontexte level = new Levelcontexte();

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
                        
                        while (window.IsOpen)
                        {
                            window.Clear(/*backgroundColor*/);

                            level.Actions();
                            level.PerformActions();
                            level.DrawObjets(window);
                            level.RemoveNotAliveObjets();

                            window.DispatchEvents();
                            window.Display();

                            System.Threading.Thread.Sleep(15);
                        }

                       
                        break;
                    }
                    else if (menu.SelectedItemIndex == 1)
                    {
                        
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

        private static void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
