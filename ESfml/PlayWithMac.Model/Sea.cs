using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PlayWithMac.Model
{
    public class Sea : IMap
    {
        bool _seaAlive;
        private Rectangle _rect;
        private Sprite _sea;
        public Rectangle Rect => _rect;

        public bool MoneyAlive
        {
            get { return _seaAlive; }
            set { _seaAlive = value; }
        }

        public bool HeartAlive { get; set; }

        public Sea(Rectangle rect)
        {
            _seaAlive = true;

            uint widthBase = Textures.SeaTextures["sea"].Size.X;
            uint heightBase = Textures.SeaTextures["sea"].Size.Y;

            if ((rect.Height % heightBase) != 0)
            {
                rect.Height = rect.Height / heightBase;
                rect.Height = rect.Height * heightBase;
            }

            if ((rect.Width % widthBase) != 0)
            {
                rect.Width = rect.Width / widthBase;
                rect.Width = rect.Width * widthBase;
            }

            _sea = new Sprite(Textures.SeaTextures["sea"], new IntRect(0, 0, (int)rect.Width, (int)(rect.Height)));
            _sea.Position = new Vector2f(rect.Left, rect.Top);

            this._rect = rect;
        }

        public void Draw(RenderWindow windowHandler, int x, int y)
        {
            _sea.Position = new Vector2f(Rect.Left + x, Rect.Top + y);
            windowHandler.Draw(_sea);

        }
    }
}
