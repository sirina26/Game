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
    class ChoiceOption
    {
        public const uint MAX_NUMBER_OF_ITEMS = 2;
        private const string V = @".\Resources\arial.ttf";
        private int selectedItemIndex;
        private Font font = new Font(V);
        private Text[] level = new Text[MAX_NUMBER_OF_ITEMS];

        public ChoiceOption(uint width, uint heigh)
        {
            level[0] = new Text
            {
                Font = font,
                Color = Color.Red,
                DisplayedString = "Sound On",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 1))
            };

            level[1] = new Text
            {
                Font = font,
                Color = Color.White,
                DisplayedString = "Sound Off",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 2))
            };

        }

        public void Draw(RenderWindow window)
        {
            for (int i = 0; i < MAX_NUMBER_OF_ITEMS; i++)
            {
                window.Draw(level[i]);
            }
        }

        public void MoveUp()
        {
            if (selectedItemIndex - 1 >= 0)
            {
                level[selectedItemIndex].Color = Color.White;
                selectedItemIndex--;
                level[selectedItemIndex].Color = Color.Red;
            }
        }

        public void MoveDown()
        {
            if (selectedItemIndex + 1 < MAX_NUMBER_OF_ITEMS)
            {
                level[selectedItemIndex].Color = Color.White;
                selectedItemIndex++;
                level[selectedItemIndex].Color = Color.Red;
            }
        }

        public void Move(Keyboard.Key key)
        {

            if (key == Keyboard.Key.Up)
            {
                MoveUp();
                System.Threading.Thread.Sleep(100);
            }
            else if (key == Keyboard.Key.Down)
            {
                MoveDown();
                System.Threading.Thread.Sleep(100);
            }
        }

        public int SelectedItemIndex
        {
            get { return selectedItemIndex; }
            set { selectedItemIndex = value; }

        }
    }
}
