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
    public class Macron : IPersonnage
    {
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


        private bool binateSprite;
        private bool alive;
        private bool bodyCollision;
        private bool feetCollision;
        private bool shooted;
        private bool coollidesWithLadder;
        private bool isSituated;

        private const int speed = 6;
        private int stopSpeed;
        private const int animation = 5;
        private int animationcollision;
        //private int health;

        private MovementMacron side;

        private Dictionary<MovementMacron, Sprite> sprite;
        private Rectangle bodyRect;
        private Rectangle feetRect;
        public Vectors direction;

        public bool Alive { get { return alive; } }
        public Rectangle BodyRect { get { return bodyRect; } }
        public Rectangle FeetRect { get { return feetRect; } }

        Color color;
        float raduis;

        public Macron(Rectangle rect)
        {
            binateSprite = true;
            alive = true;
            bodyCollision = false;
            feetCollision = false;
            shooted = false;
            coollidesWithLadder = false;
            side = MovementMacron.StaysRight;

            //health = 100;
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

        public void Draw(RenderWindow windowHandler, int xOffset, int yOffset)
        {
            sprite[side].Position = new Vector2f(bodyRect.Left + xOffset, bodyRect.Top + yOffset);
            windowHandler.Draw(sprite[side]);
            
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
            //Gestion de shoot
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                ShootEnemy();
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
        }

        public void ShootEnemy()
        {
            shooted = true;
            CircleShape player = new CircleShape(25f);
            player.FillColor = Color.White;
            player.SetPointCount(3);
            //player.Origin = Vector2f(25f, 25f);

            Bullet bl = new Bullet();
            List<Bullet> bullets = new List<Bullet>();
            Vector2f playerCenter;
            Vector2f mousePosWindows;
            Vector2f aimDir;
            Vector2f aimDirNorm;

            playerCenter = new Vector2f();
            mousePosWindows = new Vector2f();
            aimDir = mousePosWindows - playerCenter;
            aimDirNorm = aimDir / (float) Math.Sqrt(Math.Pow(aimDir.X, 2) + Math.Pow(aimDir.Y, 2));

            float PI = 3.14159265f;
            float deg = (float)Math.Atan2(aimDirNorm.Y, aimDirNorm.X) * 180 / PI;
            player.Rotation = deg + 90;

            bl.Mac.Position = playerCenter;
            bl.CurrVelocity = aimDirNorm * bl.Maxspeed;

            bullets.Add(bl);

            

        }

        //Test shoot
       public Color Color { get; set; }
        public float Radius { get; set; }
    }
}
