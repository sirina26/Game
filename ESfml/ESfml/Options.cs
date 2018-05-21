using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace PlayWithMac
{
    public class Options
    {
        public const uint MAX_NUMBER_OF_ITEMS = 3;
        private const string V = @".\Ressources\arial.ttf";
        private int selectedItemIndex;
        private Font font = new Font(V);
        private Text[] onOffSound = new Text[MAX_NUMBER_OF_ITEMS];
        static Texture _background = new Texture(@".\Ressources\images.jpg");
        static Sprite backgroundSprite;

        public Options(uint width, uint heigh)
        {
            onOffSound[0] = new Text
            {
                Font = font,
                Color = Color.Red,
                DisplayedString = "Sound ON",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 1))
            };

            onOffSound[1] = new Text
            {
                Font = font,
                Color = Color.White,
                DisplayedString = "Sound Off",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 2))
            };

            backgroundSprite = new Sprite(_background);
        }

        public void Draw(RenderWindow window)
        {
            backgroundSprite.Draw(window, RenderStates.Default);
            for (int i = 0; i < MAX_NUMBER_OF_ITEMS; i++)
            {
                window.Draw(onOffSound[i]);
            }
        }

        public void MoveUp()
        {
            if (selectedItemIndex - 1 >= 0)
            {
                onOffSound[selectedItemIndex].Color = Color.White;
                selectedItemIndex--;
                onOffSound[selectedItemIndex].Color = Color.Red;
            }
        }

        public void MoveDown()
        {
            if (selectedItemIndex + 1 < MAX_NUMBER_OF_ITEMS)
            {
                onOffSound[selectedItemIndex].Color = Color.White;
                selectedItemIndex++;
                onOffSound[selectedItemIndex].Color = Color.Red;
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

    }

}
