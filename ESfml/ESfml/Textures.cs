using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
namespace PlayWithMac
{
    public class Textures
    {
        static bool _isInitialized = false;
        public static Dictionary<string, Texture> EnemyTextures = new Dictionary<string, Texture>();
        public static Dictionary<string, Texture> GroundTextures = new Dictionary<string, Texture>();

        private const string path = "../../../SFML/Textures/";
        private static void EnemyInit()
        {
            string Epath = path + "Enemy/";

            EnemyTextures.Add("Left1", new Texture(Epath + "ELeft0.png"));
            EnemyTextures.Add("Left2", new Texture(Epath + "ELeft1.png"));

            EnemyTextures.Add("Right1", new Texture(Epath + "ERight0.png"));
            EnemyTextures.Add("Right2", new Texture(Epath + "ERight1.png"));
        }
        private static void GDInit()
        {
            string GDpath = path + "Ground/";

            Texture dirt = new Texture(GDpath + "Ground0.png");
            Texture grass = new Texture(GDpath + "Ground1.png");

            dirt.Repeated = true;
            grass.Repeated = true;

            GroundTextures.Add("Dirt", dirt);
            GroundTextures.Add("Grass", grass);
        }
        public static void init()
        {
            try
            {
                if (_isInitialized == false)
                {
                    MacronInit();
                    EnemyInit();
                    GroundInit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot load the textures: ", e);
            }
            finally
            {
                _isInitialized = true;
            }
        }

        private static void GroundInit()
        {
            throw new NotImplementedException();
        }

        private static void MacronInit()
        {
            throw new NotImplementedException();
        }
    }
}