using SFML.Window;
using SFML.Graphics;
using PlayWithMac.Model;

namespace PlayWithMac
{
    class Program
    {

        static void Main(string[] args)
        {
            const uint width = 1200;
            const uint heigth = 700;

            Menu menu = new Menu(width, heigth);

            RenderWindow windowMenu = new RenderWindow(new VideoMode(1200, 700), "PlayWithMac");
            

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
                        choix.Runchoice();
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
                windowMenu.DispatchEvents();
                windowMenu.Display();
               // System.Threading.Thread.Sleep(50);
            }
        }
    }
}
