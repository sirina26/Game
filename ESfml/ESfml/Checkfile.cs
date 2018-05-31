using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayWithMac.Model;

namespace PlayWithMac
{
    public class Checkfile
    {
        public static object CreateRectangularObject(string description)
        {
            object element = null;
            Rectangle rect = null;

            int top = 0;
            int left = 0;
            uint height = 0;
            uint width = 0;

            description = description.ToLower();
            description = description.Trim();
            string[] parametres = description.Split();
            string firstElement = parametres[0];

                switch (parametres.Length)
                {
                    case 3:
                        top = Int32.Parse(parametres[1]);
                        left = Int32.Parse(parametres[2]);

                        rect = new Rectangle(top, left);
                        break;
                    case 5:
                        top = Int32.Parse(parametres[1]);
                        left = Int32.Parse(parametres[2]);
                        height = UInt32.Parse(parametres[3]);
                        width = UInt32.Parse(parametres[4]);

                        rect = new Rectangle(top, left, height, width);
                        break;
                }

            switch (firstElement)
            {
                case "macron":
                    element = new Macron(rect);
                    break;
                case "enemy":
                    element = new Enemy(rect);
                    break;
                case "bigB":
                    element = new BigBoss(rect);
                    break;
                case "heart":
                    element = new Live(rect);
                    break;
                case "map":
                    element = new Map(rect);
                    break;
                case "money":
                    element = new Money(rect);
                    break;
                case "sea":
                    element = new Sea(rect);
                    break;
            }

            return element;
        }


    }
}
