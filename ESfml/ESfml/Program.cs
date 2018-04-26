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
        //static RenderWindow window = new RenderWindow(new VideoMode(1200, 750), "PlayWithMac");
        static ContextSettings settings = new ContextSettings();
        static RenderWindow window = new RenderWindow(new VideoMode(1200, 700), "Game", Styles.Default, settings);
        static Color backgroundColor = new Color(5, 70, 55, 1);

        static void Main(string[] args)
        {
           /* Menu menu = new Menu(1200, 750);*/
            
            Textures.init();
            window.Closed += Window_Closed;
            Levelcontexte level = new Levelcontexte();

            while (window.IsOpen)
            {
                /* if (Keyboard.IsKeyPressed(Keyboard.Key.Z))
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
                         /*Games game = new Games();
                         game.Run();*/

                        window.Clear(/*backgroundColor*/);

                        level.RequestActions();
                        level.PerformActions();
                        level.DrawObjects(window);
                        level.RemoveNotAliveObjects();

                        window.DispatchEvents();
                        window.Display();

                        System.Threading.Thread.Sleep(15);
                       // break;
                   /* }
                    else if (menu.SelectedItemIndex == 1)
                    {
                        //Programme pour envoyer dans l'options
                        /*window.Close();
                        Option option = new Option();
                        option.Run();*/
                        //break;

                  /*  }
                    else if (menu.SelectedItemIndex == 2)
                    {
                        window.Close();
                    }
                }

                menu.Draw(window);
                window.Display();
                Thread.Sleep(85);*/
            }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
