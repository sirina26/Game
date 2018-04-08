using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;
using SFML.Audio;
using SFML.Graphics;

namespace ESfml
{
    public class PlayWithMac : GameLoop
    {
        public const uint DEFULT_WINDOW_WIDTH = 640;
        public const uint DEFULT_WINDOW_HEIGHT = 480;
        public const string DEFULT_TITLE = "PLAY WITH MAC";
        public PlayWithMac() : base(DEFULT_WINDOW_WIDTH, DEFULT_WINDOW_HEIGHT, DEFULT_TITLE, Color.Magenta)
        {}
        public override void Draw(GameTime gameTime)
        {
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
