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
    public class LevelContext
    {
       
        public Level _level;
        Sprite backgroundSprite;
        public LevelContext(int level)
        {

            if (level == 1)
            {
                _level = new Level(@".\Niveau\" + "Level1.txt");
                Texture _background = new Texture(@".\LEVEL1MAP1.png");
                backgroundSprite = new Sprite(_background);

            }
            else if (level == 2)
            {
                _level = new Level(@".\Niveau\" + "Level2.txt");
                Texture _background = new Texture(@".\LEVEL2MAP.png");
                backgroundSprite = new Sprite(_background);
            }
            else if (level == 3)
            {
                _level = new Level(@".\Niveau\" + "Level3.txt");
                Texture _background = new Texture(@".\LEVEL3MAP.png");
                backgroundSprite = new Sprite(_background);
            }
        }

        public class Level
        {
            public List<IPersonnage> PersonneDraw = null;
            public List<IMap> MapDraw;
            public List<IMap> LiveDraw;
            public List<IMap> MoneyDraw;
            public List<IMap> SeaDraw;
            public Macron MacronObj;

            public Level(string levelPath)
            {
                PersonneDraw = new List<IPersonnage>();
                MapDraw = new List<IMap>();
                LiveDraw = new List<IMap>();
                MoneyDraw = new List<IMap>();
                SeaDraw = new List<IMap>();

                string[] levelDescriptor = File.ReadAllLines(levelPath);

                foreach (string line in levelDescriptor)
                {
                    object product;
                    
                    product = Checkfile.CreateRectangularObject(line);
                    if (product == null) throw new ArgumentException("csvwvxcf");
                    else if (product.GetType().Equals(typeof(Map)))
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
                    else if (product.GetType().Equals(typeof(BigBoss)))
                    {
                        PersonneDraw.Add((BigBoss)product);
                    }
                    else if (product.GetType().Equals(typeof(Live)))
                    {
                        LiveDraw.Add((Live)product);

                    }
                    else if (product.GetType().Equals(typeof(Money)))
                    {
                        MoneyDraw.Add((Money)product);

                    }
                    else if (product.GetType().Equals(typeof(Sea)))
                    {
                        SeaDraw.Add((Sea)product);
                    }
                }

            }
        }

        


        public void Actions()
        {
            foreach (IPersonnage element in _level.PersonneDraw)
            {
                element.GetAction();
            }
        }

        public void PerformActions()
        {
            foreach (IPersonnage element in _level.PersonneDraw)
            {
                foreach (IMap collider in _level.MoneyDraw)
                {
                    if (collider.GetType().Equals(typeof(Money)))
                    {
                        element.CheckCollision((Money)collider);
                    }
                    else throw new Exception();
                }
                foreach (IMap collider in _level.SeaDraw)
                {
                    if (collider.GetType().Equals(typeof(Sea)))
                    {
                        element.CheckCollision((Sea)collider);
                    }
                }
                foreach (IMap collider in _level.LiveDraw)
                {
                    if (collider.GetType().Equals(typeof(Live)))
                    {
                        element.CheckCollision((Live)collider);

                    }
                    else throw new Exception();
                }
                while (element.GetIsSituated() == false)
                {
                    foreach (IMap collider in _level.MapDraw)
                    {
                        if (collider.GetType().Equals(typeof(Map)))
                        {
                            element.CheckCollision((Map)collider);
                        }
                        else throw new Exception();
                    }
                    
                  
                    foreach (IPersonnage collider in _level.PersonneDraw)
                    {
                        if (collider.GetType().Equals(typeof(Enemy)))
                        {
                            element.CheckCollision((Enemy)collider);
                        }
                        else if (collider.GetType().Equals(typeof(Macron)))
                        {
                            element.CheckCollision((Macron)collider);
                        }
                        else if (collider.GetType().Equals(typeof(BigBoss)))
                        {
                            element.CheckCollision((BigBoss)collider);
                        }
                    }

                    element.Move();
                }
            }
        }

        public void RemoveNotAliveObjets()
        {
            foreach (IPersonnage element in _level.PersonneDraw)
            {
                if (element.Alive == false)
                {
                    _level.PersonneDraw.Remove(element);
                    break;
                }
            }
        }

        public void RemoveHeart()
        {
            foreach (IMap element in _level.LiveDraw)
            {
                if (element.HeartAlive == false)
                {
                    _level.LiveDraw.Remove(element);
                    break;
                }
            }
        }
        public void RemoveMoney()
        {
            foreach (IMap element in _level.MoneyDraw)
            {
                if (element.MoneyAlive == false)
                {
                    _level.MoneyDraw.Remove(element);
                    break;
                }
            }
        }
        public void DrawObjets(RenderWindow windowHandler)
        {
           backgroundSprite.Draw(windowHandler, RenderStates.Default);
            int X = -(_level.MacronObj.BodyRect.Left - 600);

            foreach (IMap element in _level.MapDraw)
            {
                element.Draw(windowHandler, X, 0);
            }

            foreach (IPersonnage element in _level.PersonneDraw)
            {
                element.Draw(windowHandler, X, 0);
            }
            foreach(IMap element in _level.LiveDraw)
            {
                element.Draw(windowHandler, X, 0);
            }
            foreach (IMap element in _level.SeaDraw)
            {
                element.Draw(windowHandler, X, 0);
            }
            foreach (IMap element in _level.MoneyDraw)
            {
                element.Draw(windowHandler, X, 0);
            }
        }

    }
}
