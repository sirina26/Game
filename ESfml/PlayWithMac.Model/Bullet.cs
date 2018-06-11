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
    public class Bullet 
    {
    
        Vector2f _position;
        Sprite _sprite;
        Text test;
        Rectangle _bodyrect;
        Rectangle _feet;
        bool _bodyCollision;
        bool _feetCollision;
        Vectors _direction;
        const int speed = 10;
        int stopSpeed;
        Rectangle _groundRect;


        public enum MvtBullet
        {
            Rigth,
            Rigth2
        }

        MvtBullet _sideB;
        Dictionary<MvtBullet, Sprite> _spriteB;
        Random _random = new Random();
        int _ax;
        int _ay;

        public Bullet(Rectangle rect)
        {
            _sideB = MvtBullet.Rigth;
            _spriteB = new Dictionary<MvtBullet, Sprite>();
            _spriteB.Add(MvtBullet.Rigth, new Sprite(Textures.BombeTextures["Rigth"]));
            _spriteB.Add(MvtBullet.Rigth2, new Sprite(Textures.BombeTextures["Rigth2"]));

           
            rect.Height = Textures.BombeTextures["Rigth2"].Size.Y;
            rect.Width = Textures.BombeTextures["Rigth2"].Size.X;

            _bodyrect = rect;
            _feet = new Rectangle(rect.Bottom, (rect.Left + 3), 1, (rect.Width - 6));
            _groundRect = new Rectangle(rect.Bottom, (rect.Left), 1, (rect.Width));

        }

        public MvtBullet GetMvtBull
        {
            get { return _sideB; }
            set { _sideB = value; }
        }

        public Dictionary<MvtBullet, Sprite> SpriteB
        {
            get { return _spriteB; }
        }

        public void MoveBullet()
        {
            _sideB = Bullet.MvtBullet.Rigth2;
        }

        public void MoveShoot()
        {
          
            _direction = new Vectors(new Vectors.Vector(-15, 0));
            _direction.MoveSucceed = true;
            Vectors.Direction move = Vectors.Direction.Right;
            
            if (move == Vectors.Direction.Right)
            {
                _bodyrect.Left += 10;
                _feet.Left += 10;
                _groundRect.Left ++;
            }   
        }


    }
}
