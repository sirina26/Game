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
        readonly Font livePoint;
        readonly Sounds op;

        public enum MovementMacron
        {
            StaysLeft,
            MovesLeft1,
            MovesLeft2,
            JumpsLeft,
            StaysRight,
            MovesRight1,
            MovesRight2,
            JumpsRight,
            Shoot
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
        //
        int liveNumber = 30;
        int MoneyNumber = 0;
        //
        private const int animation = 5;
        private int animationcollision;
        int health;

        private MovementMacron side;

        private Dictionary<MovementMacron, Sprite> sprite;
        private Rectangle bodyRect;
        private Rectangle feetRect;
        public Vectors direction;

        public bool Alive { get { return alive; } }
        public int LiveNumber { get => liveNumber; }
        public Rectangle BodyRect { get { return bodyRect; } }
        public Rectangle FeetRect { get { return feetRect; } }

        public List<Bullet> bullets;
        RenderWindow window;

        public Macron(Rectangle rect)
        {
            livePoint = new Font(@".\arial.ttf");
            op = new Sounds();

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
            sprite.Add(MovementMacron.Shoot, new Sprite(Textures.PersonnagePle["shoot"]));

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
        public Text NumberMoney()
        {
            Text _moneyNumber = new Text()
            {
                Font = livePoint,
                DisplayedString = "               Money" + MoneyNumber.ToString()
            };
            return _moneyNumber;
        }

        public void Draw(RenderWindow windowHandler, int xOffset, int yOffset)
        {
            window = windowHandler;
            Text live = NumberLive();
            Text money = NumberMoney();
            sprite[side].Position = new Vector2f(bodyRect.Left + xOffset, bodyRect.Top + yOffset);
            windowHandler.Draw(sprite[side]);
            windowHandler.Draw(live);
            windowHandler.Draw(money);
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
            //Gestion de shoot
            else if (Keyboard.IsKeyPressed(Keyboard.Key.B))
            {
                side = MovementMacron.Shoot;
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
            if (this.feetRect.CheckCollisions(Collider.BodyRect))
            {
                feetCollision = true;
                op.CheckCollisionSound();
            }
            if (this.bodyRect.CheckCollisions(Collider.BodyRect))
            {
                bodyCollision = true;
                liveNumber--;
                if (liveNumber <= 0)
                {
                    alive = false;
                }
            }
        }

        public void ShootEnemy()
        {
            shooted = true;
            CircleShape player = new CircleShape(25f);
            player.FillColor = Color.White;
            player.SetPointCount(3);
            player.Position = sprite[side].Position;

            Bullet bl = new Bullet();
            bullets = new List<Bullet>();
            Vector2f playerCenter;
            Vector2f mousePosWindows;
            Vector2f aimDir;
            Vector2f aimDirNorm;

            playerCenter = new Vector2f(player.Position.X, player.Position.Y);
            mousePosWindows = new Vector2f(Mouse.GetPosition().X, Mouse.GetPosition().Y);
            aimDir = mousePosWindows - playerCenter;
            aimDirNorm = aimDir / (float)Math.Sqrt(Math.Pow(aimDir.X, 2) + Math.Pow(aimDir.Y, 2));

            float PI = 3.14159265f;
            float deg = (float)Math.Atan2(aimDirNorm.Y, aimDirNorm.X) * 180 / PI;
            player.Rotation = deg + 90;

            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                bl.Shape.Position = playerCenter;
                bl.CurrVelocity = aimDirNorm * bl.Maxspeed;

                bullets.Add(bl);
            }

            for (int i = 0; i < bullets.Count(); i++)
            {
                if (liveNumber <= 0)
                {
                    // bullets.Remove(bullets.Begin + i);
                }
                else
                {
                }

            }

            window.Draw(player);

            for (int i = 0; i < bullets.Count(); i++)
            {
                bullets[i].Shape.Draw(window, RenderStates.Default);
            }

            window.Display();

        }

        public void CheckCollision(Live Collider)
        {

            if (this.bodyRect.CheckCollisions(Collider.Rect))
            {
                bodyCollision = true;
                liveNumber++;
                Collider.HeartAlive = false;
            }
        }

        public void CheckCollision(Money collider)
        {
            if (this.bodyRect.CheckCollisions(collider.Rect))
            {
                bodyCollision = true;
                MoneyNumber++;
                collider.MoneyAlive = false;
                
            }
        }

        public void CheckCollision(Sea collider)
        {
            if (this.bodyRect.CheckCollisions(collider.Rect))
            {
                alive = false;
            }
        }

        public void CheckCollision(BigBoss Collider)
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
                if (liveNumber <= 0)
                {
                    alive = false;
                }
            }
        }
    }
}
