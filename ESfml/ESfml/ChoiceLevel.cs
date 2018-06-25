using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;

namespace PlayWithMac
{
    public class ChoiceLevel
    {
        public const uint MAX_NUMBER_OF_ITEMS = 3;
        private const string V = @".\Ressources\arial.ttf";
        private int selectchoice;
        private Font font = new Font(V);
        private Text[] level = new Text[MAX_NUMBER_OF_ITEMS];

        public ChoiceLevel(uint width, uint heigh)
        {
            level[0] = new Text
            {
                Font = font,
                Color = Color.Red,
                DisplayedString = "Level 1",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 1))
            };

            level[1] = new Text
            {
                Font = font,
                Color = Color.White,
                DisplayedString = "Level 2",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 2))
            };

            level[2] = new Text
            {
                Font = font,
                Color = Color.White,
                DisplayedString = "Level 3",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 3))
            };
        }

        public void Draw(RenderWindow window)
        {
            for (int i = 0; i < MAX_NUMBER_OF_ITEMS; i++)
            {
                window.Draw(level[i]);
            }
        }

        public void MoveUpChoice()
        {
            if (selectchoice - 1 >= 0)
            {
                level[selectchoice].Color = Color.White;
                selectchoice--;
                level[selectchoice].Color = Color.Red;
            }
        }

        public void MoveDownChoice()
        {
            if (selectchoice + 1 < MAX_NUMBER_OF_ITEMS)
            {
                level[selectchoice].Color = Color.White;
                selectchoice++;
                level[selectchoice].Color = Color.Red;
            }
        }

        public void MoveSelect(Keyboard.Key key)
        {

            if (key == Keyboard.Key.Up)
            {
                MoveUpChoice();
                System.Threading.Thread.Sleep(100);
            }
            else if (key == Keyboard.Key.Down)
            {
                MoveDownChoice();
                System.Threading.Thread.Sleep(100);
            }
        }

        public int Selectchoice
        {
            get { return selectchoice; }
            set { selectchoice = value; }

        }
    }
}
