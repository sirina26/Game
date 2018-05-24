using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PlayWithMac.Model
{
    public class Money:IMap
    {
        bool moneyAlive;
        private Rectangle rect;
        private Rectangle bodyRect;
        private Sprite _money;
        public Rectangle Rect => rect;
        public Rectangle BodyRect { get { return bodyRect; } }

        public bool MoneyAlive
        {
            get { return moneyAlive; }
            set { moneyAlive = value; }
        }

        public bool HeartAlive { get ; set; }

        public Money(Rectangle rect)
        {
            moneyAlive = true;
            
            uint widthBase = Textures.MoneyTextures["money"].Size.X;
            uint heightBase = Textures.MoneyTextures["money"].Size.Y;

            rect.Height = heightBase;
            rect.Width = widthBase;

            _money = new Sprite(Textures.MoneyTextures["money"], new IntRect(0, 0, (int)rect.Width, (int)(rect.Height)));
            _money.Position = new Vector2f(rect.Left, rect.Top);

            this.rect = rect;
        }


        public void Draw(RenderWindow windowHandler, int x, int y)
        {
            _money.Position = new Vector2f(Rect.Left + x, Rect.Top + y);
            windowHandler.Draw(_money);

        }
    }

}

