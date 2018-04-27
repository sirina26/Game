using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PlayWithMac
{
    public class Levelcontexte
    {
        static Texture _background = new Texture(@".\Ressources\LEVEL1MAP1.png");
        static Sprite backgroundSprite = new Sprite(_background);

        public class LevelContext
        {
            public List<Personnage> Movables = null;
            public List<Mapinterface> Motionless;
            public Macron MainCharacterHandler;

            

            public LevelContext(string levelPath)
            {
                Movables = new List<Personnage>();
                Motionless = new List<Mapinterface>();

                string[] levelDescriptor = File.ReadAllLines(levelPath);

                foreach (string line in levelDescriptor)
                {
                    object product;

                    product = Factory.CreateRectangularObject(line);

                    if (product.GetType().Equals(typeof(Map)))
                    {
                        Motionless.Add((Map)product);
                    }
                    else if (product.GetType().Equals(typeof(Macron)))
                    {
                        Movables.Add((Macron)product);
                        MainCharacterHandler = (Macron)product;
                    }
                    else if (product.GetType().Equals(typeof(Enemy)))
                    {
                        Movables.Add((Enemy)product);
                    }
                    //else throw new NotImplementedException();
                }

            }
        }

        public LevelContext context;

        public Levelcontexte()
        {
            //string levelPath = @"C:\Users\andor\OneDrive\Documents\INTECH\Game\Game\ESfml\ESfml\Ressources\Niveau\";

            context = new LevelContext(@".\Ressources\Niveau\" + "Level1.txt");
        }

        public void RequestActions()
        {
            foreach (Personnage element in context.Movables)
            {
                element.GetAction();
            }
        }

        public void PerformActions()
        {
            foreach (Personnage element in context.Movables)
            {
                while (element.GetIsSituated() == false)
                {
                    foreach (Mapinterface collider in context.Motionless)
                    {
                        if (collider.GetType().Equals(typeof(Map)))
                        {
                            element.CheckCollision((Map)collider);
                        }
                        else throw new Exception();
                    }

                    foreach (Personnage collider in context.Movables)
                    {
                        if (collider.GetType().Equals(typeof(Enemy)))
                        {
                            element.CheckCollision((Enemy)collider);
                        }
                       else if (collider.GetType().Equals(typeof(Macron)))
                        {
                            element.CheckCollision((Macron)collider);
                        }
                        else throw new Exception();
                    }

                    element.Move();
                }
            }
        }

        public void RemoveNotAliveObjects()
        {
            foreach (Personnage element in context.Movables)
            {
                if (element.Alive == false)
                {
                    context.Movables.Remove(element);
                    break;
                }
            }
        }

        public void DrawObjects(RenderWindow windowHandler)
        {
            backgroundSprite.Draw(windowHandler, RenderStates.Default);
            int XOffset = -(context.MainCharacterHandler.BodyRect.Left - 600);

            foreach (Mapinterface element in context.Motionless)
            {
                element.Draw(windowHandler, XOffset, 0);
            }

            foreach (Personnage element in context.Movables)
            {
                element.Draw(windowHandler, XOffset, 0);
            }
        }

        public void Delay(uint miliseconds)
        {

        }
    }
}
