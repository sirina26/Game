using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace PlayWithMac.Model
{
    public class Bullet : IMap
    {
        private Rectangle rect;

        private Sprite Shoot;
        bool heartlive = false;


        public Bullet(Rectangle rect)
        {
            uint heightBase = Textures.BombeTextures["bombe"].Size.Y;
            uint widthBase = Textures.BombeTextures["bombe"].Size.X;
            rect.Height = heightBase;
            rect.Width = widthBase;


            Shoot = new Sprite(Textures.BombeTextures["bombe"], new IntRect(0, 0, (int)rect.Width, (int)(rect.Height)));
            Shoot.Position = new Vector2f(rect.Left, rect.Top);

            this.rect = rect;
        }

        public bool HeartAlive { get => heartlive; set => heartlive = value; }

        public bool MoneyAlive => false;

        public Rectangle Rect => rect;

        public void Draw(RenderWindow windowHandler, int x, int y)
        {
            Shoot.Position = new Vector2f(Rect.Left + x, Rect.Top + y);
            windowHandler.Draw(Shoot);
        }
    }
}
