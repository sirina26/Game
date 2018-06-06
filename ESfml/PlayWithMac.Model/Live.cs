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
        bool heartAlive;
        private Rectangle rect;
       
        private Sprite heart;
        public Rectangle Rect => rect;
       

        public bool HeartAlive
        {
            get { return heartAlive; }
            set { heartAlive = value; }
        }

        public bool MoneyAlive => throw new NotImplementedException();

        public Live(Rectangle rect)
        {
            heartAlive = true;
            uint heightBase = Textures.LiveTextures["heart"].Size.Y;
            uint widthBase = Textures.LiveTextures["heart"].Size.X;
             rect.Height = heightBase;
            rect.Width = widthBase;


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
