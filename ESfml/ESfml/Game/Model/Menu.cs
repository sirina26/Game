using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Graphics;

namespace ESfml
{
    public class Menu:GameLoop
    {
        public const uint DEFULT_WINDOW_WIDTH = 700;
        public const uint DEFULT_WINDOW_HEIGHT = 550;
        public const string DEFULT_TITLE = "PLAY WITH MAC";
        public const uint MAX_NUMBER_OF_ITEMS = 3;
        private const string V = @"C:\Users\andor\OneDrive\Documents\INTECH\Game\Game\ESfml\ESfml\arial.ttf";
        private int selectedItemIndex;
        private Font font = new Font(V);
        private Text[] menu = new Text[MAX_NUMBER_OF_ITEMS];

        public Menu() : base(DEFULT_WINDOW_WIDTH, DEFULT_WINDOW_HEIGHT, DEFULT_TITLE, Color.Black)
        {
            menu[0] = new Text
            {
                Font = font,
                Color = Color.Red,
                DisplayedString = "Play",
                Position = new SFML.System.Vector2f(DEFULT_WINDOW_WIDTH / 2, (DEFULT_WINDOW_WIDTH / (MAX_NUMBER_OF_ITEMS + 1) * 1))
            };

            menu[1] = new Text
            {
                Font = font,
                Color = Color.White,
                DisplayedString = "Options",
                Position = new SFML.System.Vector2f(DEFULT_WINDOW_WIDTH / 2, (DEFULT_WINDOW_WIDTH / (MAX_NUMBER_OF_ITEMS + 1) * 2))
            };

            menu[2] = new Text
            {
                Font = font,
                Color = Color.White,
                DisplayedString = "Exit",
                Position = new SFML.System.Vector2f(DEFULT_WINDOW_WIDTH / 2, (DEFULT_WINDOW_WIDTH / (MAX_NUMBER_OF_ITEMS + 1) * 3))
            };


        }

        public override void Draw(GameTime gameTime)
        {
            for(int i = 0; i<MAX_NUMBER_OF_ITEMS; i++)
            {
                Window.Draw(menu[i]);
            }
        }

        public override void Initialize()
        {
            
        }

        public override void LoadContent()
        {
           
        }

        public override void Update(GameTime gameTime)
        {
            
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
    }
}
