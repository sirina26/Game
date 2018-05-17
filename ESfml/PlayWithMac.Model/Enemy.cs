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
        public enum MovementEnemy
        {
            Left1,
            Left2,
            Right1,
            Right2
        }

        private bool binateSprite;
        private bool alive;
        private bool bodyCollision;
        private bool feetCollision;
        private bool mapCollision;
        private bool isSituated;

        private const int speed = 2;
        private int stopSpeed;
        private const int animationSpeed = 2;
        private int animationIterator;
        private MovementEnemy side;

        private Dictionary<MovementEnemy, Sprite> sprite;
        private Rectangle bodyRect;
        private Rectangle feetRect;
        private Rectangle groundRect;
        public Vectors direction;

        public bool Alive { get { return alive; } }
        public Rectangle BodyRect { get { return bodyRect; } }
        public const int Damage = 20;

        private void chooseSprite()
        {
            if (animationIterator++ > animationSpeed)
            {
                animationIterator = 0;
                binateSprite = !binateSprite;
            }

            switch (side)
            {
                case MovementEnemy.Left1:
                case MovementEnemy.Left2:
                    if (binateSprite) side = MovementEnemy.Left1;
                    else side = MovementEnemy.Left2;
                    break;
                case MovementEnemy.Right1:
                case MovementEnemy.Right2:
                    if (binateSprite) side = MovementEnemy.Right1;
                    else side = MovementEnemy.Right2;
                    break;
            }
        }

        public Enemy(Rectangle rect)
        {
            binateSprite = true;
            alive = true;
            bodyCollision = false;
            feetCollision = true;
            mapCollision = false;
            stopSpeed = 0;
            animationIterator = 0;
            side = MovementEnemy.Right1;

            rect.Height = Textures.EnemyTextures["Right1"].Size.Y;
            rect.Width = Textures.EnemyTextures["Right1"].Size.X;

            sprite = new Dictionary<MovementEnemy, Sprite>();
            sprite.Add(MovementEnemy.Left1, new Sprite(Textures.EnemyTextures["Left1"]));
            sprite.Add(MovementEnemy.Left2, new Sprite(Textures.EnemyTextures["Left2"]));
            sprite.Add(MovementEnemy.Right1, new Sprite(Textures.EnemyTextures["Right1"]));
            sprite.Add(MovementEnemy.Right2, new Sprite(Textures.EnemyTextures["Right2"]));

            bodyRect = rect;
            feetRect = new Rectangle(rect.Bottom, (rect.Left + (int)rect.Width / 2), 1, (rect.Width / 2));
            groundRect = new Rectangle(rect.Bottom, (rect.Left), 1, (rect.Width));
        }

        //public bool Alive => throw new NotImplementedException();

        public void GetAction()
        {
            isSituated = false;

            if (mapCollision == false)
            {
                stopSpeed += 2;
            }
            else
            {
                stopSpeed = 0;

                if (bodyCollision == true)
                {
                    if (side == MovementEnemy.Left1 || side == MovementEnemy.Left2) side = MovementEnemy.Right1;
                    else side = MovementEnemy.Left1;
                }
            }

            bodyCollision = false;
            feetCollision = false;
            mapCollision = false;

            chooseSprite();

            switch (side)
            {
                case MovementEnemy.Left1:
                case MovementEnemy.Left2:
                    direction = new Vectors(new Vectors.Vector((-speed), stopSpeed));
                    break;
                case MovementEnemy.Right1:
                case MovementEnemy.Right2:
                    direction = new Vectors(new Vectors.Vector(speed, stopSpeed));
                    break;
            }
        }

        public void Move()
        {
            if (stopSpeed > 0 && feetCollision)
            {
                stopSpeed = 0;
                direction.HightReached = true;
            }

            direction.MoveSucceed = !bodyCollision;
            Vectors.Direction move = direction.NextMove;
            bodyCollision = false;

            switch (move)
            {
                case Vectors.Direction.None:
                    isSituated = true;
                    break;

                case Vectors.Direction.Left:
                    bodyRect.Left--;
                    feetRect.Left--;
                    groundRect.Left--;
                    break;

                case Vectors.Direction.Right:
                    bodyRect.Left++;
                    feetRect.Left++;
                    groundRect.Left++;
                    break;

                case Vectors.Direction.Up:
                    bodyRect.Top--;
                    feetRect.Top--;
                    groundRect.Top--;
                    break;

                case Vectors.Direction.Down:
                    bodyRect.Top++;
                    feetRect.Top++;
                    groundRect.Top++;
                    break;

                default:
                    throw new Exception();
            }

            if ((move == Vectors.Direction.Right) && (side == MovementEnemy.Left1))
            {
                side = MovementEnemy.Right1;
            }
            else if ((move == Vectors.Direction.Left) && (side == MovementEnemy.Right1))
            {
                side = MovementEnemy.Left1;
            }
        }

        public void CheckCollision(Macron Collider)
        {
            if (groundRect.CheckCollisions(Collider.BodyRect))
            {
                mapCollision = true;
            }

            if (feetRect.CheckCollisions(Collider.BodyRect))
            {
                feetCollision = true;
            }

            if (bodyRect.CheckCollisions(Collider.BodyRect))
            {
                bodyCollision = true;
            }

            if (bodyRect.CheckCollisions(Collider.FeetRect))
            {
                alive = false;
            }
        }

        public void CheckCollision(Enemy Collider)
        {
        }

        public void CheckCollision(Map Collider)
        {
            if (groundRect.CheckCollisions(Collider.Rect))
            {
                mapCollision = true;
            }
            else mapCollision = false;

            if (feetRect.CheckCollisions(Collider.Rect))
            {
                feetCollision = true;
            }
            else feetCollision = false;

            if (bodyRect.CheckCollisions(Collider.Rect) || (!feetCollision && mapCollision))
            {
                bodyCollision = true;
            }
        }

        public bool GetIsSituated()
        {
            return isSituated;
        }

        public void Draw(RenderWindow windowHandler, int xOffset, int yOffset)
        {
            sprite[side].Position = new Vector2f(bodyRect.Left + xOffset, bodyRect.Top + yOffset);
            windowHandler.Draw(sprite[side]);
        }
    }
}
