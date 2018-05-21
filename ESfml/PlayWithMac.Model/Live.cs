using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PlayWithMac.Model
{
    public class Live : IMap
    {
        private Rectangle rect;
        private Rectangle bodyRect;
        private Sprite heart;
        public Rectangle Rect => rect;
        public Rectangle BodyRect { get { return bodyRect; } }

        public Live(Rectangle rect)
        {
            uint heightBase = Textures.LiveTextures["heart"].Size.Y;
            uint widthBase = Textures.LiveTextures["heart"].Size.X;

            if ((rect.Height % heightBase) != 0)
            {
                rect.Height = rect.Height / heightBase;
                //rect.Height = rect.Height * heightBase;
            }
            if ((rect.Width % widthBase) != 0)
            {
                rect.Width = rect.Width / widthBase;
                //  rect.Width = rect.Width * widthBase;
            }

            heart = new Sprite(Textures.LiveTextures["heart"], new IntRect(0, 0, (int)rect.Width, (int)(rect.Height)));
            heart.Position = new Vector2f(rect.Left, rect.Top);

            this.rect = rect;
        }


        public void Draw(RenderWindow windowHandler, int x, int y)
        {
            heart.Position = new Vector2f(Rect.Left + x, Rect.Top + y);
            windowHandler.Draw(heart);
        }
    }
}
