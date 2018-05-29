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
using EducalGame;
namespace PlayWithMac
{
    class Program
    {

        static void Main(string[] args)
        {
            RenderWindow windowGame = new RenderWindow(new VideoMode(1200, 700), "PlayWithMac");
            //Menu menu = new Menu(1200, 700);
            
            Questions questions = new Questions(100, 700);
             RenderWindow windowMenu = new RenderWindow(new VideoMode(1200, 700), "PlayWithMac");
           
            Textures.init();
           // window.Closed += Window_Closed;
            LevelContext level = new LevelContext();

            while (windowMenu.IsOpen)
            {

                if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
                {
                    if (questions.SelectedItemIndex == 0)
                    {
                        windowMenu.Close();

                        while (windowGame.IsOpen)
                        {
                            windowGame.Clear(/*backgroundColor*/);

                            level.Actions();
                            level.PerformActions();
                            level.DrawObjets(windowGame);
                            level.RemoveNotAliveObjets();
                            level.RemoveHeart();
                            level.RemoveMoney();

                            windowGame.DispatchEvents();
                            windowGame.Display();

                            System.Threading.Thread.Sleep(10);
                        }


                        break;
                    }
                    else if (questions.SelectedItemIndex == 1)
                    {
                        break;
                    }
                    else if (questions.SelectedItemIndex == 2)
                    {
                        windowMenu.Close();
                        break;
                    }
                }
                

                questions.Draw(windowMenu);
                windowMenu.Display();
            }
            
        }
    }
}
