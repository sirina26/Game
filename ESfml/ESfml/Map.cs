using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PlayWithMac
{
    public class Map: Mapinterface
    {
        private Rectangle rect;
        private Sprite dirt;
        private Sprite grass;

        public Rectangle Rect { get { return rect; } }

        public Map(Rectangle rect)
        {
             uint heightBase = Textures.MapTextures["Dirt"].Size.Y;
             uint widthBase = Textures.MapTextures["Dirt"].Size.X;

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

            dirt = new Sprite(Textures.MapTextures["Dirt"], new IntRect(0, 0, (int)rect.Width, (int)(rect.Height)));
            grass = new Sprite(Textures.MapTextures["Grass"], new IntRect(0, 0, (int)(rect.Width), (int)heightBase));

            dirt.Position = new Vector2f(rect.Left, rect.Top);
            grass.Position = new Vector2f(rect.Left, rect.Top);

            this.rect = rect;
        }

        public void Draw(RenderWindow windowHandler, int x, int y)
        {
            dirt.Position = new Vector2f(Rect.Left + x, Rect.Top + y);
            grass.Position = dirt.Position;
            windowHandler.Draw(dirt);
            windowHandler.Draw(grass);
        }
    }
}
