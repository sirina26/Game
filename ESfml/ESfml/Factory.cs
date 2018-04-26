using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithMac
{
    public class Factory
    {
        public static object CreateRectangularObject(string objectDescriptor)
        {
            object product = null;
            Rectangle rect = null;

            int top = 0;
            int left = 0;
            uint height = 0;
            uint width = 0;

            objectDescriptor = objectDescriptor.ToLower();
            objectDescriptor = objectDescriptor.Trim();
            string[] objectParameters = objectDescriptor.Split();
            string firstElement = objectParameters[0];

           /* try
            {*/
                switch (objectParameters.Length)
                {
                    case 3:
                        top = Int32.Parse(objectParameters[1]);
                        left = Int32.Parse(objectParameters[2]);

                        rect = new Rectangle(top, left);
                        break;
                    case 5:
                        top = Int32.Parse(objectParameters[1]);
                        left = Int32.Parse(objectParameters[2]);
                        height = UInt32.Parse(objectParameters[3]);
                        width = UInt32.Parse(objectParameters[4]);

                        rect = new Rectangle(top, left, height, width);
                        break;
                    default:
                        throw new FactoryInvalidArgumentsException();
                }

                switch (firstElement)
                {
                    case "macron":
                        product = new Macron(rect);
                        break;
                    /*case "ghost":
                        product = new Ghost(rect);
                        break;*/
                    case "map":
                        product = new Map(rect);
                        break;
                    default:
                        throw new FactoryInvalidArgumentsException();
                }
           /* }
            catch (FactoryInvalidArgumentsException e)
            {
                Console.WriteLine("Object could not be created: ", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Object could not be created: ", e);
            }*/

            return product;
        }


    }
}
