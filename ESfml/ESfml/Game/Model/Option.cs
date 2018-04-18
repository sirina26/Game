using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace ESfml
{
    public class Option: GameLoop
    {
        const uint DEFAULT_WINDOW_WIDTH = 1200;
        const uint DEFAULT_WINDOW_HEIGHT = 750;
        const string WINDOW_TITLE = "PlayWithMac";

        static Texture _background = new Texture(@"C:\Users\andor\OneDrive\Documents\INTECH\Game\Game\ESfml\ESfml\Resources\images.jpg");
        static Sprite backgroundSprite;

        public Option() : base(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT, WINDOW_TITLE, Color.Black)
        {
            backgroundSprite = new Sprite(_background);
        }

        public override void Draw(GameTime gameTime)
        {
            backgroundSprite.Draw(Window, RenderStates.Default);
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
    }
}
