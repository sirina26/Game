using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace PlayWithMac
{
    public class Macron : IPersonnage
    {
        readonly Font livePoint;
        readonly Options op;

        public enum MovementMacron
        {
            StaysLeft,
            MovesLeft1,
            MovesLeft2,
            JumpsLeft,
            StaysRight,
            MovesRight1,
            MovesRight2,
            JumpsRight
        }
       

        bool binateSprite;
         bool alive;
        bool heartsh;
        bool bodyCollision;
         bool feetCollision;
         bool shooted;
         bool coollidesWithLadder;
         bool isSituated;
         int liveNumber = 30;
         const int speed = 6;
         int stopSpeed;
         const int animation = 5;
         int animationcollision;
         int health;

         MovementMacron side;

         Dictionary<MovementMacron, Sprite> sprite;

        Rectangle bodyRect;
         Rectangle feetRect;
        public Vectors direction;

        public bool Alive { get { return alive; } }
        public bool Heartsh { get { return heartsh; } }

        public int LiveNumber { get { return liveNumber; } }
        public Rectangle BodyRect { get { return bodyRect; } }
        public Rectangle FeetRect { get { return feetRect; } }

        public Macron(Rectangle rect)
        {
            livePoint = new Font(@".\Ressources\arial.ttf");
            op = new Options();

            binateSprite = true;
            alive = true;
            bodyCollision = false;
            feetCollision = false;
            shooted = false;
            coollidesWithLadder = false;
            side = MovementMacron.StaysRight;

            health = 100;
            stopSpeed = 0;
            animationcollision = 0;

            
            rect.Height = Textures.PersonnagePle["Right1"].Size.Y;
            rect.Width = Textures.PersonnagePle["Right1"].Size.X;

            sprite = new Dictionary<MovementMacron, Sprite>();

                sprite.Add(MovementMacron.StaysLeft, new Sprite(Textures.PersonnagePle["Left0"]));
                sprite.Add(MovementMacron.StaysRight, new Sprite(Textures.PersonnagePle["Right0"]));
                sprite.Add(MovementMacron.MovesLeft1, new Sprite(Textures.PersonnagePle["Left1"]));
                sprite.Add(MovementMacron.MovesLeft2, new Sprite(Textures.PersonnagePle["Left2"]));
                sprite.Add(MovementMacron.MovesRight1, new Sprite(Textures.PersonnagePle["Right1"]));
                sprite.Add(MovementMacron.MovesRight2, new Sprite(Textures.PersonnagePle["Right2"]));
                sprite.Add(MovementMacron.JumpsLeft, new Sprite(Textures.PersonnagePle["Left3"]));
                sprite.Add(MovementMacron.JumpsRight, new Sprite(Textures.PersonnagePle["Right3"]));
          
            bodyRect = rect;
            feetRect = new Rectangle(rect.Bottom, (rect.Left + 3), 1, (rect.Width - 6));
        }

        public void CheckCollision(Macron Collider)
        {
           
        }
        public Text NumberLive()
        {
            Text _liveNumber = new Text()
            {
                Font = livePoint,
                DisplayedString = liveNumber.ToString() + " Lives"
            };
            return _liveNumber;
        }
        public void Draw(RenderWindow windowHandler, int xOffset, int yOffset)
        {
            sprite[side].Position = new Vector2f(bodyRect.Left + xOffset, bodyRect.Top + yOffset);
            windowHandler.Draw(sprite[side]);
            windowHandler.Draw(NumberLive());
            if (liveNumber == 0) windowHandler.Close();
        }

        public void GetAction()
        {
            bodyCollision = false;
            isSituated = false;

            if (++animationcollision > animation)
            {
                binateSprite = !binateSprite;
                animationcollision = 0;
            }

            if (feetCollision)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    stopSpeed = 4 * (-speed);
                    feetCollision = false;
                    op.GetActionSound();
                }
                else
                {
                    stopSpeed = 0;
                }
            }
            else
            {
                stopSpeed += 2;
            }

            feetCollision = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                direction = new Vectors(new Vectors.Vector(speed, stopSpeed));

                if (stopSpeed == 0)
                {
                    if (binateSprite) side = MovementMacron.MovesRight1;
                    else side = MovementMacron.MovesRight2;
                }
                else
                {
                    side = MovementMacron.JumpsRight;
                }
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                direction = new Vectors(new Vectors.Vector(-speed, stopSpeed));

                if (stopSpeed == 0)
                {
                    if (binateSprite) side = MovementMacron.MovesLeft1;
                    else side = MovementMacron.MovesLeft2;
                }
                else
                {
                    side = MovementMacron.JumpsLeft;
                }
            }
            else
            {
                direction = new Vectors(new Vectors.Vector(0, stopSpeed));

                if (stopSpeed == 0)
                {
                    if (side >= MovementMacron.StaysRight) side = MovementMacron.StaysRight;
                    else side = MovementMacron.StaysLeft;
                }
                else
                {
                    if (side >= MovementMacron.StaysRight) side = MovementMacron.JumpsRight;
                    else side = MovementMacron.JumpsLeft;
                }
            }
        }

        public bool GetIsSituated()
        {
            return isSituated;
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
                    FeetRect.Left--;
                    break;

                case Vectors.Direction.Right:
                    bodyRect.Left++;
                    FeetRect.Left++;
                    break;

                case Vectors.Direction.Up:
                    bodyRect.Top--;
                    FeetRect.Top--;
                    break;

                case Vectors.Direction.Down:
                    bodyRect.Top++;
                    FeetRect.Top++;
                    break;
            }
        }

        public void CheckCollision(Map Collider)
        {
            if (this.feetRect.CheckCollisions(Collider.Rect))
            {
                feetCollision = true;
            }

            if (this.bodyRect.CheckCollisions(Collider.Rect))
            {
                bodyCollision = true;
            }

        }

        public void CheckCollision(Enemy Collider)
        {
            if (this.feetRect.CheckCollisions(Collider.BodyRect))
            {
                feetCollision = true;
                op.CheckCollisionSound();
            }
            if (this.bodyRect.CheckCollisions(Collider.BodyRect))
            {
                bodyCollision = true;
                liveNumber--;
                if (liveNumber<=0)
                {
                    alive = false;
                }
            }
        }

        public void CheckCollision(Live Collider)
        {
            //if ((this.feetRect.CheckCollisions(Collider.BodyRect)) || (this.bodyRect.CheckCollisions(Collider.BodyRect)))
            //{
            //    heartsh = false;
            //}
        }
    }
}
