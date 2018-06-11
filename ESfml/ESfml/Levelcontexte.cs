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
            //public List<IPersonnage> BulletDraw;
            public Macron MacronObj;

            public LevelContext(string levelPath)
            {
                PersonneDraw = new List<IPersonnage>();
                MapDraw = new List<IMap>();
                LiveDraw = new List<IMap>();
               // BulletDraw = new List<IPersonnage>();

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

                    }/*else if (product.GetType().Equals(typeof(Bullet)))
                    {
                        BulletDraw.Add((Bullet)product);
                    }*/
                }

            }
        }

        public LevelContext context;

        public Levelcontexte()
        {

            context = new LevelContext(@".\Ressources\Niveau\" + "Level1.txt");
        }

        public void Actions(RenderWindow win)
        {
            foreach (IPersonnage element in context.PersonneDraw)
            {
                element.GetAction(win);
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

        public bool RemoveNotAliveObjets(RenderWindow windows)
        {
           bool gover = false;
            foreach (IPersonnage element in context.PersonneDraw)
            {
                if (element.Alive == false )
                {
                    if (element.GetType().Equals(typeof(Macron)))
                    {
                        gover = true;
                    }
                  
                    context.PersonneDraw.Remove(element);
                    break;
                }
            }

            return gover;
        }

        public void DrawGameOver(RenderWindow windows, bool test )
        {
            if(test == true)
            {
                Gameover over = new Gameover();
                over.Draw(windows);
            }
        }

        public void RemoveHeart()
        {
            foreach (IMap element in context.LiveDraw)
            {
                if (element.HeartAlive == false)
                {
                    context.LiveDraw.Remove(element);
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
