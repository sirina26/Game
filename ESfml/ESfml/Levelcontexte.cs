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
            public List<Personnage> PersonneDraw = null;
            public List<Mapinterface> MapDraw;
            public Macron MacronObj;

            

            public LevelContext(string levelPath)
            {
                PersonneDraw = new List<Personnage>();
                MapDraw = new List<Mapinterface>();

                string[] levelDescriptor = File.ReadAllLines(levelPath);

                foreach (string line in levelDescriptor)
                {
                    object product;

                    product = Checkfile.CreateRectangularObject(line);

                    if (product.GetType().Equals(typeof(Map)))
                    {
                        MapDraw.Add((Map)product);
                    }
                    else if (product.GetType().Equals(typeof(Macron)))
                    {
                        PersonneDraw.Add((Macron)product);
                        MacronObj = (Macron)product;
                    }
                    else if (product.GetType().Equals(typeof(Enemy)))
                    {
                        PersonneDraw.Add((Enemy)product);
                    }
                }

            }
        }

        public LevelContext context;

        public Levelcontexte()
        {

            context = new LevelContext(@".\Ressources\Niveau\" + "Level1.txt");
        }

        public void Actions()
        {
            foreach (Personnage element in context.PersonneDraw)
            {
                element.GetAction();
            }
        }

        public void PerformActions()
        {
            foreach (Personnage element in context.PersonneDraw)
            {
                while (element.GetIsSituated() == false)
                {
                    foreach (Mapinterface collider in context.MapDraw)
                    {
                        if (collider.GetType().Equals(typeof(Map)))
                        {
                            element.CheckCollision((Map)collider);
                        }
                        else throw new Exception();
                    }

                    foreach (Personnage collider in context.PersonneDraw)
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

        public void RemoveNotAliveObjets()
        {
            foreach (Personnage element in context.PersonneDraw)
            {
                if (element.Alive == false)
                {
                    context.PersonneDraw.Remove(element);
                    break;
                }
            }
        }

        public void DrawObjets(RenderWindow windowHandler)
        {
            backgroundSprite.Draw(windowHandler, RenderStates.Default);
            int X = -(context.MacronObj.BodyRect.Left - 600);

            foreach (Mapinterface element in context.MapDraw)
            {
                element.Draw(windowHandler, X, 0);
            }

            foreach (Personnage element in context.PersonneDraw)
            {
                element.Draw(windowHandler, X, 0);
            }
        }

    }
}
