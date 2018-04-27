using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Graphics;
using SFML.Window;

namespace PlayWithMac
{
    public class Menu
    {
        public const uint MAX_NUMBER_OF_ITEMS = 3;
        private const string V = @"C:\dev\PlayWithMac\ESfml\ESfml\Ressources\arial.ttf";
        private int selectedItemIndex;
        private Font font = new Font(V);
        private Text[] menu = new Text[MAX_NUMBER_OF_ITEMS];
        static Texture _background = new Texture(@"C:\dev\PlayWithMac\ESfml\ESfml\Ressources\images.jpg");
        static Sprite backgroundSprite;

        public Menu(uint width, uint heigh)
        {
            menu[0] = new Text
            {
                Font = font,
                Color = Color.Red,
                DisplayedString = "Play",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 1))
            };

            menu[1] = new Text
            {
                Font = font,
                Color = Color.White,
                DisplayedString = "Options",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 2))
            };

            menu[2] = new Text
            {
                Font = font,
                Color = Color.White,
                DisplayedString = "Exit",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 3))
            };
            backgroundSprite = new Sprite(_background);
        }

        public void Draw(RenderWindow window)
        {
            backgroundSprite.Draw(window, RenderStates.Default);
            for (int i = 0; i<MAX_NUMBER_OF_ITEMS; i++)
            {
                window.Draw(menu[i]);
            }
        }

        public void MoveUp()
        {
            if(selectedItemIndex - 1 >= 0)
            {
                menu[selectedItemIndex].Color = Color.White;
                selectedItemIndex --;
                menu[selectedItemIndex].Color = Color.Red;
            }
        }

        public void MoveDown() 
        {
            if (selectedItemIndex + 1 < MAX_NUMBER_OF_ITEMS)
            {
                menu[selectedItemIndex].Color = Color.White;
                selectedItemIndex ++;
                menu[selectedItemIndex].Color = Color.Red;
            }
        }

        public void Move(Keyboard.Key key)
        {

            if (key == Keyboard.Key.Up)
            {
                MoveUp();
            }
            else if (key == Keyboard.Key.Down)
            {
                MoveDown();
            }
        }

        public int SelectedItemIndex
        {
            get { return selectedItemIndex; }
            set { selectedItemIndex = value; }

        }

       /* public void PlaySoundMenu()
        {
            //music.Play();
        }

        public void StopSoundMenu()
        {
            //music.Stop();
        }*/

    }
}
