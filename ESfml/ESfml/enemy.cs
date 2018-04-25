using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithMac
{
    public class Enemy
    {
        bool _isAlive;
        Rectangle _rectangle;
        bool _bodyCollides;
        const int _speed = 2;
        Rectangle bodyRect;

        Rectangle _bodyRect;
        bool _feetCollides;
        bool _isSituated;
        public MotionDirector _director;
        Rectangle _groundRect;
        Rectangle _feetRect;
        bool _groundCollides;
        int _fallSpeed;
        int _animationIterator;
        public enum EnemySide
        {
            Left,
            MovesLeft1,
           
            Right,
            MovesRight1,
           
        }
        EnemySide side;
        Dictionary<EnemySide, Sprite> sprite;
        public bool IsAlive { get { return _isAlive; } }
        public Rectangle GetRectangle { get { return _rectangle; } }
        bool _binateSprite;
        private void ChoosePosition()
        {
            switch (side)
            {
                case EnemySide.Left:
                case EnemySide.MovesLeft1:
                    side = (_binateSprite) ? EnemySide.Left : EnemySide.MovesLeft1;
                    break;
                case EnemySide.Right:
                case EnemySide.MovesRight1:
                    side = (_binateSprite) ? EnemySide.Right : EnemySide.MovesRight1;
                    break;
            }

        }
        public Enemy(Rectangle rect)
        {
            _binateSprite = true;
            _isAlive = true;
            _bodyCollides = false;
            _feetCollides = true;
            _groundCollides = false;
            _fallSpeed = 0;
            _animationIterator = 0;
            side = EnemySide.Right;

            rect.Height = Textures.EnemyTextures["Right1"].Size.Y;
            rect.Width = Textures.EnemyTextures["Right1"].Size.X;

            sprite = new Dictionary<EnemySide, Sprite>();

            sprite.Add(EnemySide.Left, new Sprite(Textures.EnemyTextures["Left1"]));
            sprite.Add(EnemySide.MovesLeft1, new Sprite(Textures.EnemyTextures["MovesLeft1"]));
            sprite.Add(EnemySide.Right, new Sprite(Textures.EnemyTextures["Right"]));
            sprite.Add(EnemySide.MovesRight1, new Sprite(Textures.EnemyTextures["MovesRight1"]));

            _bodyRect = rect;
            _feetRect = new Rectangle(rect.Bottom, (rect.Left + (int)rect.Width / 2), 1, (rect.Width / 2));
            _groundRect = new Rectangle(rect.Bottom, (rect.Left), 1, (rect.Width));
        }
        public void GetAction()
        {
            _isSituated = false;

            if (_groundCollides == false)
            {
                _fallSpeed += 2;
            }
            else
            {
                _fallSpeed = 0;

                if (_bodyCollides == true)
                {
                    side = (side == EnemySide.Left || side == EnemySide.MovesLeft1) ? EnemySide.Right : EnemySide.MovesRight1;
                }
            }

            _bodyCollides = false;
            _feetCollides = false;
            _groundCollides = false;

            ChoosePosition();

            switch (side)
            {
                case EnemySide.Left:
                case EnemySide.MovesLeft1:
                    _director = new MotionDirector(new MotionDirector.Vector((-_speed), _fallSpeed));
                    break;
                case EnemySide.Right:
                case EnemySide.MovesRight1:
                    _director = new MotionDirector(new MotionDirector.Vector(_speed, _fallSpeed));
                    break;
            }
        }
        public void Draw()
        {

        }
        public void Draw(RenderWindow windowHandler, int xOffset, int yOffset)
        {
            sprite[side].Position = new Vector2f(bodyRect.Left + xOffset, bodyRect.Top + yOffset);
            windowHandler.Draw(sprite[side]);
        }

    }
}
