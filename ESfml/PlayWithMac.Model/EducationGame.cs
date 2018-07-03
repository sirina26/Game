using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PlayWithMac.Model
{
    public class EducationGame
    {
        public const uint MAX_NUMBER_OF_ITEMS = 2;
        private const string V = @".\game_educatif\police\9SYSTEMA.TTF";
        private int selectedItemIndex;
        private Font font = new Font(V);
        private Text[] _response = new Text[MAX_NUMBER_OF_ITEMS];
        static Texture _background = new Texture(@".\game_educatif\FD_JE.jpg");
        static Sprite backgroundSprite;

        public EducationGame(uint width, uint heigh)
        {
            _response[0] = new Text
            {
                Font = font,
                Color = Color.Red,
                DisplayedString = "START",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 1))
            };
            _response[1] = new Text
            {
                Font = font,
                Color = Color.Black,
                DisplayedString = "",
                Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 1))
            };

            backgroundSprite = new Sprite(_background);
        }

        public void Draw(RenderWindow wind)
        {
            backgroundSprite.Draw(wind, RenderStates.Default);
            for (int i = 0; i < MAX_NUMBER_OF_ITEMS; i++)
            {
                wind.Draw(_response[i]);
            }
        }

        public int SelectedItemIndex
        {
            get { return selectedItemIndex; }
            set { selectedItemIndex = value; }
        }
    }
}
