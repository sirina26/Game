using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace ESfml
{
    public class Games : GameLoop
    {
        //readonly string path;
        const uint DEFAULT_WINDOW_WIDTH = 1200;
        const uint DEFAULT_WINDOW_HEIGHT = 750;
        const string WINDOW_TITLE = "PlayWithMac";

        static Texture _background = new Texture(@"C:\Users\andor\OneDrive\Documents\INTECH\Game\Game\ESfml\ESfml\Resources\images.jpg");
        static Sprite backgroundSprite;

        Map _map;
        PartGame _partie;

        public Games() : base(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT, WINDOW_TITLE, Color.Black)
        {
            backgroundSprite = new Sprite(_background);
        }

        public override void Draw(GameTime gameTime)
        {
            backgroundSprite.Draw(Window, RenderStates.Default);
            _map.Draw(Window, DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT);

        }

        public override void Initialize()
        {
            _map = new Map(new PartGame(), DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT);
            _partie = new PartGame();
        }

        public override void LoadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            _partie.Update();
        }
    }
}
