using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PlayWithMac.Model
{
    public class Enemy : IPersonnage
    {
        public enum EnemySide
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
         EnemySide _side;

         Dictionary<EnemySide, Sprite> _sprite;
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
                case EnemySide.Left1:
                case EnemySide.Left2:
                    _side = (_binateSprite) ? EnemySide.Left1 : EnemySide.Left2;
                    break;
                case EnemySide.Right1:
                case EnemySide.Right2:
                    _side = (_binateSprite) ? EnemySide.Right1 : EnemySide.Right2;
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
            _side = EnemySide.Right1;

            rect.Height = Textures.EnemyTextures["Right1"].Size.Y;
            rect.Width = Textures.EnemyTextures["Right1"].Size.X;

            _sprite = new Dictionary<EnemySide, Sprite>();
            _sprite.Add(EnemySide.Left1, new Sprite(Textures.EnemyTextures["Left1"]));
            _sprite.Add(EnemySide.Left2, new Sprite(Textures.EnemyTextures["Left2"]));
            _sprite.Add(EnemySide.Right1, new Sprite(Textures.EnemyTextures["Right1"]));
            _sprite.Add(EnemySide.Right2, new Sprite(Textures.EnemyTextures["Right2"]));

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
                    _side = (_side == EnemySide.Left1 || _side == EnemySide.Left2) ? EnemySide.Right1 : EnemySide.Left1;
                }
            }

            _bodyCollides = false;
            _feetCollides = false;
            _groundCollides = false;

            ChooseSprite();

            switch (_side)
            {
                case EnemySide.Left1:
                case EnemySide.Left2:
                    _director = new Vectors(new Vectors.Vector((-_speed), _fallSpeed));
                    break;
                case EnemySide.Right1:
                case EnemySide.Right2:
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

            if ((move == Vectors.Direction.Right) && (_side == EnemySide.Left1))
            {
                _side = EnemySide.Right1;
            }
            else if ((move == Vectors.Direction.Left) && (_side == EnemySide.Right1))
            {
                _side = EnemySide.Left1;
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
    }
}
