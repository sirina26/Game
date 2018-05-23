using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PlayWithMac.Model
{
    public class Map: IMap
    {
        private Rectangle rect;
        private Sprite sidewalk;
        private Sprite wall;
        bool heartlive;

        public Rectangle Rect { get { return rect; } }

        public bool HeartAlive {
            get { return heartlive; }
            set { heartlive = value; }
        }

        public Map(Rectangle rect)
        {
            heartlive = true;
            uint heightBase = Textures.MapTextures["Sidewalk"].Size.Y;
            uint widthBase = Textures.MapTextures["Wall"].Size.X;

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

            sidewalk = new Sprite(Textures.MapTextures["Sidewalk"], new IntRect(0, 0, (int)rect.Width, (int)(rect.Height)));
            wall = new Sprite(Textures.MapTextures["Wall"], new IntRect(0, 0, (int)(rect.Width), (int)heightBase));

            sidewalk.Position = new Vector2f(rect.Left, rect.Top);
            wall.Position = new Vector2f(rect.Left, rect.Top);

            this.rect = rect;
        }

        public void Draw(RenderWindow windowHandler, int x, int y)
        {
            sidewalk.Position = new Vector2f(Rect.Left + x, Rect.Top + y);
            wall.Position = sidewalk.Position;
            windowHandler.Draw(sidewalk);
            windowHandler.Draw(wall);
        }
    }
}
