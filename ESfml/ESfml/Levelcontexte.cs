using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using PlayWithMac.Model;

namespace PlayWithMac
{
    public class Levelcontexte
    {
        static Texture _background = new Texture(@".\Ressources\LEVEL1MAP1.png");
        static Sprite backgroundSprite = new Sprite(_background);

        public class LevelContext
        {
            public List<IPersonnage> PersonneDraw = null;
            public List<IMap> MapDraw;
            public List<IMap> LiveDraw;
            public Macron MacronObj;

            public LevelContext(string levelPath)
            {
                PersonneDraw = new List<IPersonnage>();
                MapDraw = new List<IMap>();
                LiveDraw = new List<IMap>();

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
                    else if (product.GetType().Equals(typeof(Live)))
                    {
                        LiveDraw.Add((Live)product);

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
            foreach (IPersonnage element in context.PersonneDraw)
            {
                element.GetAction();
            }
        }

        public void PerformActions()
        {
            foreach (IPersonnage element in context.PersonneDraw)
            {
                while (element.GetIsSituated() == false)
                {
                    foreach (IMap collider in context.MapDraw)
                    {
                        if (collider.GetType().Equals(typeof(Map)))
                        {
                            element.CheckCollision((Map)collider);
                        }
                        else throw new Exception();
                    }
                    foreach (IMap collider in context.LiveDraw)
                    {
                        if (collider.GetType().Equals(typeof(Live)))
                        {
                            element.CheckCollision((Live)collider);
                        }
                        else throw new Exception();
                    }

                    foreach (IPersonnage collider in context.PersonneDraw)
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
            foreach (IPersonnage element in context.PersonneDraw)
            {
                if (element.IsAlive == false)
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

            foreach (IMap element in context.MapDraw)
            {
                element.Draw(windowHandler, X, 0);
            }

            foreach (IPersonnage element in context.PersonneDraw)
            {
                element.Draw(windowHandler, X, 0);
            }
            foreach(IMap element in context.LiveDraw)
            {
                element.Draw(windowHandler, X, 0);
            }
        }

    }
}
