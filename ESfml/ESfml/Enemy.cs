using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace PlayWithMac
{
    public class Enemy : Personnage
    {
        public enum EnemySide
        {
            Left1,
            Left2,
            Right1,
            Right2
        }

         bool binateSprite;
         bool alive;
         bool bodyCollides;
         bool feetCollides;
         bool groundCollides;
         bool isSituated;

         const int speed = 2;
         int fallSpeed;
         const int animationSpeed = 2;
         int animationIterator;
         EnemySide side;

         Dictionary<EnemySide, Sprite> sprite;
         Rectangle bodyRect;
         Rectangle feetRect;
         Rectangle groundRect;
        public Vectors director;

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
                case EnemySide.Left1:
                case EnemySide.Left2:
                    side = (binateSprite) ? EnemySide.Left1 : EnemySide.Left2;
                    break;
                case EnemySide.Right1:
                case EnemySide.Right2:
                    side = (binateSprite) ? EnemySide.Right1 : EnemySide.Right2;
                    break;
            }
        }

        public Enemy(Rectangle rect)
        {
            binateSprite = true;
            alive = true;
            bodyCollides = false;
            feetCollides = true;
            groundCollides = false;
            fallSpeed = 0;
            animationIterator = 0;
            side = EnemySide.Right1;

            rect.Height = Textures.EnemyTextures["Right1"].Size.Y;
            rect.Width = Textures.EnemyTextures["Right1"].Size.X;

            sprite = new Dictionary<EnemySide, Sprite>();
            sprite.Add(EnemySide.Left1, new Sprite(Textures.EnemyTextures["Left1"]));
            sprite.Add(EnemySide.Left2, new Sprite(Textures.EnemyTextures["Left2"]));
            sprite.Add(EnemySide.Right1, new Sprite(Textures.EnemyTextures["Right1"]));
            sprite.Add(EnemySide.Right2, new Sprite(Textures.EnemyTextures["Right2"]));

            bodyRect = rect;
            feetRect = new Rectangle(rect.Bottom, (rect.Left + (int)rect.Width / 2), 1, (rect.Width / 2));
            groundRect = new Rectangle(rect.Bottom, (rect.Left), 1, (rect.Width));
        }

        public void GetAction()
        {
            isSituated = false;

            if (groundCollides == false)
            {
                fallSpeed += 2;
            }
            else
            {
                fallSpeed = 0;

                if (bodyCollides == true)
                {
                    side = (side == EnemySide.Left1 || side == EnemySide.Left2) ? EnemySide.Right1 : EnemySide.Left1;
                }
            }

            bodyCollides = false;
            feetCollides = false;
            groundCollides = false;

            chooseSprite();

            switch (side)
            {
                case EnemySide.Left1:
                case EnemySide.Left2:
                    director = new Vectors(new Vectors.Vector((-speed), fallSpeed));
                    break;
                case EnemySide.Right1:
                case EnemySide.Right2:
                    director = new Vectors(new Vectors.Vector(speed, fallSpeed));
                    break;
            }
        }

        public void Move()
        {
            if (fallSpeed > 0 && feetCollides)
            {
                fallSpeed = 0;
                director.HightReached = true;
            }

            director.MoveSucceed = !bodyCollides;
            Vectors.Direction move = director.NextMove;
            bodyCollides = false;

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

            if ((move == Vectors.Direction.Right) && (side == EnemySide.Left1))
            {
                side = EnemySide.Right1;
            }
            else if ((move == Vectors.Direction.Left) && (side == EnemySide.Right1))
            {
                side = EnemySide.Left1;
            }
        }

        public void CheckCollision(Macron Collider)
        {
            if (groundRect.CheckCollisions(Collider.BodyRect))
            {
                groundCollides = true;
            }

            if (feetRect.CheckCollisions(Collider.BodyRect))
            {
                feetCollides = true;
            }

            if (bodyRect.CheckCollisions(Collider.BodyRect))
            {
                bodyCollides = true;
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
                groundCollides = true;
            }
            else groundCollides = false;

            if (feetRect.CheckCollisions(Collider.Rect))
            {
                feetCollides = true;
            }
            else feetCollides = false;

            if (bodyRect.CheckCollisions(Collider.Rect) || (!feetCollides && groundCollides))
            {
                bodyCollides = true;
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
