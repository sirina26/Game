using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Graphics;
using SFML.Window;


namespace EducalGame
{
    public class Questions
    {
        public const uint MAX_NUMBER_OF_ITEMS = 4;
        private const string V = @".\arial.ttf";
        private int selectedItemIndex;
        private Font font = new Font(V);
        private Text[] _response = new Text[MAX_NUMBER_OF_ITEMS];
        static Texture _background = new Texture(@".\images.jpg");
        static Sprite backgroundSprite;
        public Text Qua()
        {
            Text _question = new Text()
            {
                Font = font,
                DisplayedString = "Quelle est la date de l'indépendance de la France ?",
            };
            return _question;
        }

        public Questions(uint width, uint heigh)
        {

            _response[0] = new Text
            {
                Font = font,
                Color = Color.Red,
                DisplayedString = "1880",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 1))
            };

            _response[1] = new Text
            {
                Font = font,
                Color = Color.White,
                DisplayedString = "1960",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 2))
            };

            _response[2] = new Text
            {
                Font = font,
                Color = Color.White,
                DisplayedString = "1821",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 3))
            };
            _response[3] = new Text
            {
                Font = font,
                Color = Color.White,
                DisplayedString = "1955",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 4))
            };
            backgroundSprite = new Sprite(_background);
        }

        public void Draw(RenderWindow window)
        {
            backgroundSprite.Draw(window, RenderStates.Default);
            for (int i = 0; i < MAX_NUMBER_OF_ITEMS; i++)
            {
                window.Draw(_response[i]);
            }
            Text quas = Qua();
            window.Draw(quas);
        }

        public void MoveUp()
        {
            if (selectedItemIndex - 1 >= 0)
            {
                _response[selectedItemIndex].Color = Color.White;
                selectedItemIndex--;
                _response[selectedItemIndex].Color = Color.Red;
            }
        }

        public void MoveDown()
        {
            if (selectedItemIndex + 1 < MAX_NUMBER_OF_ITEMS)
            {
                _response[selectedItemIndex].Color = Color.White;
                selectedItemIndex++;
                _response[selectedItemIndex].Color = Color.Red;
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

