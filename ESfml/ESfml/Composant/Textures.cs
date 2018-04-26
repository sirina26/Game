using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PlayWithMac
{
    public static class Textures
    {
        private static bool isInitialized = false;
        public static Dictionary<string, Texture> MainCharacterTextures = new Dictionary<string, Texture>();
        public static Dictionary<string, Texture> GroundTextures = new Dictionary<string, Texture>();
        public static Dictionary<string, Texture> GhostTextures = new Dictionary<string, Texture>();

        //private const string path = @"C:\Users\andor\OneDrive\Documents\INTECH\Game\Game\ESfml\ESfml\Ressources\";
        //private const string path = "../../../ESfml/Ressources/";

        public static bool IsInitialized { get { return isInitialized; } }

        private static void MCInit()
        {
            string MCpath = @"C:\Users\andor\OneDrive\Documents\INTECH\Game2D-master\Game2D-master\Game2D\Game2D\Textures\" + @"Macron\";

            MainCharacterTextures.Add("Left0", new Texture(MCpath + "MCLeft0.png"));
            MainCharacterTextures.Add("Left1", new Texture(MCpath + "MCLeft1.png"));
            MainCharacterTextures.Add("Left2", new Texture(MCpath + "MCLeft2.png"));
            MainCharacterTextures.Add("Left3", new Texture(MCpath + "MCLeft3.png"));

            MainCharacterTextures.Add("Right0", new Texture(MCpath + "MCRight0.png"));
            MainCharacterTextures.Add("Right1", new Texture(MCpath + "MCRight1.png"));
            MainCharacterTextures.Add("Right2", new Texture(MCpath + "MCRight2.png"));
            MainCharacterTextures.Add("Right3", new Texture(MCpath + "MCRight3.png"));
        }

        private static void GDInit()
        {
            //string GDpath = path + "Map/";

            Texture dirt = new Texture(@"C:\Users\andor\OneDrive\Documents\INTECH\Game2D-master\Game2D-master\Game2D\Game2D\Textures\Ground\" + "Ground0.png");
            Texture grass = new Texture(@"C:\Users\andor\OneDrive\Documents\INTECH\Game2D-master\Game2D-master\Game2D\Game2D\Textures\Ground\" + "Ground1.png");

            dirt.Repeated = true;
            grass.Repeated = true;

            GroundTextures.Add("Dirt", dirt);
            GroundTextures.Add("Grass", grass);
        }

       /* private static void GHInit()
        {
            string Gpath = path + "Ghost/";

            GhostTextures.Add("Left1", new Texture(Gpath + "GLeft0.png"));
            GhostTextures.Add("Left2", new Texture(Gpath + "GLeft1.png"));

            GhostTextures.Add("Right1", new Texture(Gpath + "GRight0.png"));
            GhostTextures.Add("Right2", new Texture(Gpath + "GRight1.png"));
        }*/

        public static void init()
        {
            try
            {
                if (isInitialized == false)
                {
                    MCInit();
                    GDInit();
                    //GHInit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot load the textures: ", e);
            }
            finally
            {
                isInitialized = true;
            }
        }
    }

}

