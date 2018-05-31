using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PlayWithMac.Model
{
    public class BigBoss : IPersonnage
    {
        public enum BigBossSide
        {
            Left1,
            Left2,
            Right1,
            Right2
        }

        bool _binateSprite;
        bool _isAlive;
        bool _bodyCollides;
        bool _feetCollides;
        bool _groundCollides;
        bool _isSituated;

        const int _speed = 2;
        int _fallSpeed;
        const int _animationSpeed = 2;
        int _animationIterator;
        BigBossSide _side;

        Dictionary<BigBossSide, Sprite> _sprite;
        Rectangle _bodyRect;
        Rectangle _feetRect;
        Rectangle _groundRect;
        public Vectors _director;

        public bool Alive { get { return _isAlive; } }
        public Rectangle BodyRect { get { return _bodyRect; } }
        public const int Damage = 20;

        private void ChooseSprite()
        {
            if (_animationIterator++ > _animationSpeed)
            {
                _animationIterator = 0;
                _binateSprite = !_binateSprite;
            }

            switch (_side)
            {
                case BigBossSide.Left1:
                case BigBossSide.Left2:
                    _side = (_binateSprite) ? BigBossSide.Left1 : BigBossSide.Left2;
                    break;
                case BigBossSide.Right1:
                case BigBossSide.Right2:
                    _side = (_binateSprite) ? BigBossSide.Right1 : BigBossSide.Right2;
                    break;
            }
        }

        public BigBoss(Rectangle rect)
        {
            _binateSprite = true;
            _isAlive = true;
            _bodyCollides = false;
            _feetCollides = true;
            _groundCollides = false;
            _fallSpeed = 0;
            _animationIterator = 0;
            _side = BigBossSide.Right1;

            rect.Height = Textures.BigBossTextures["R1"].Size.Y;
            rect.Width = Textures.BigBossTextures["R1"].Size.X;

            _sprite = new Dictionary<BigBossSide, Sprite>();
            _sprite.Add(BigBossSide.Left1, new Sprite(Textures.BigBossTextures["L1"]));
            _sprite.Add(BigBossSide.Left2, new Sprite(Textures.BigBossTextures["L2"]));
            _sprite.Add(BigBossSide.Right1, new Sprite(Textures.BigBossTextures["R1"]));
            _sprite.Add(BigBossSide.Right2, new Sprite(Textures.BigBossTextures["R2"]));

            _bodyRect = rect;
            _feetRect = new Rectangle(rect.Bottom, (rect.Left + (int)rect.Width / 2), 1, (rect.Width / 2));
            _groundRect = new Rectangle(rect.Bottom, (rect.Left), 1, (rect.Width));
        }

        //public bool Alive => throw new NotImplementedException();

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
                    _side = (_side == BigBossSide.Left1 || _side == BigBossSide.Left2) ? BigBossSide.Right1 : BigBossSide.Left1;
                }
            }

            _bodyCollides = false;
            _feetCollides = false;
            _groundCollides = false;

            ChooseSprite();

            switch (_side)
            {
                case BigBossSide.Left1:
                case BigBossSide.Left2:
                    _director = new Vectors(new Vectors.Vector((-_speed), _fallSpeed));
                    break;
                case BigBossSide.Right1:
                case BigBossSide.Right2:
                    _director = new Vectors(new Vectors.Vector(_speed, _fallSpeed));
                    break;
            }
        }

        public void Move()
        {
            if (_fallSpeed > 0 && _feetCollides)
            {
                _fallSpeed = 0;
                _director.HightReached = true;
            }

            _director.MoveSucceed = !_bodyCollides;
            Vectors.Direction move = _director.NextMove;
            _bodyCollides = false;

            switch (move)
            {
                case Vectors.Direction.None:
                    _isSituated = true;
                    break;

                case Vectors.Direction.Left:
                    _bodyRect.Left--;
                    _feetRect.Left--;
                    _groundRect.Left--;
                    break;

                case Vectors.Direction.Right:
                    _bodyRect.Left++;
                    _feetRect.Left++;
                    _groundRect.Left++;
                    break;

                case Vectors.Direction.Up:
                    _bodyRect.Top--;
                    _feetRect.Top--;
                    _groundRect.Top--;
                    break;

                case Vectors.Direction.Down:
                    _bodyRect.Top++;
                    _feetRect.Top++;
                    _groundRect.Top++;
                    break;

                default:
                    throw new Exception();
            }

            if ((move == Vectors.Direction.Right) && (_side == BigBossSide.Left1))
            {
                _side = BigBossSide.Right1;
            }
            else if ((move == Vectors.Direction.Left) && (_side == BigBossSide.Right1))
            {
                _side = BigBossSide.Left1;
            }
        }

        public void CheckCollision(Macron Collider)
        {
            if (_groundRect.CheckCollisions(Collider.BodyRect))
            {
                _groundCollides = true;
            }

            if (_feetRect.CheckCollisions(Collider.BodyRect))
            {
                _feetCollides = true;
            }

            if (_bodyRect.CheckCollisions(Collider.BodyRect))
            {
                _bodyCollides = true;
            }

            if (_bodyRect.CheckCollisions(Collider.FeetRect))
            {
                _isAlive = false;
            }
        }

        public void CheckCollision(Enemy Collider)
        {
        }

        public void CheckCollision(Map Collider)
        {
            if (_groundRect.CheckCollisions(Collider.Rect))
            {
                _groundCollides = true;
            }
            else _groundCollides = false;

            if (_feetRect.CheckCollisions(Collider.Rect))
            {
                _feetCollides = true;
            }
            else _feetCollides = false;

            if (_bodyRect.CheckCollisions(Collider.Rect) || (!_feetCollides && _groundCollides))
            {
                _bodyCollides = true;
            }
        }

        public bool GetIsSituated()
        {
            return _isSituated;
        }

        public void Draw(RenderWindow windowHandler, int xOffset, int yOffset)
        {
            _sprite[_side].Position = new Vector2f(_bodyRect.Left + xOffset, _bodyRect.Top + yOffset);
            windowHandler.Draw(_sprite[_side]);
        }

        public void CheckCollision(Live collider)
        {
            //throw new NotImplementedException();
        }
        public void CheckCollision(Money collider)
        {
            //throw new NotImplementedException();
        }

        public void CheckCollision(Sea collider)
        {
            //   throw new NotImplementedException();
        }

        public void CheckCollision(BigBoss collider)
        {
            throw new NotImplementedException();
        }
    }
}
