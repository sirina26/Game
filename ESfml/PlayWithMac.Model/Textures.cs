using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PlayWithMac.Model
{
    public class Textures
    {
        private static bool isInitialized = false;
        public static Dictionary<string, Texture> PersonnagePle = new Dictionary<string, Texture>();
        public static Dictionary<string, Texture> MapTextures = new Dictionary<string, Texture>();
        public static Dictionary<string, Texture> EnemyTextures = new Dictionary<string, Texture>();
        public static Dictionary<string, Texture> LiveTextures = new Dictionary<string, Texture>();
        public static Dictionary<string, Texture> MoneyTextures = new Dictionary<string, Texture>();

        public static bool IsInitialized { get { return isInitialized; } }

        private static void MCInit()
        {

            string MCpath = @".\" + @"Macron\";

            PersonnagePle.Add("Left0", new Texture(MCpath + "MCLeft0.png"));
            PersonnagePle.Add("Left1", new Texture(MCpath + "MCLeft1.png"));
            PersonnagePle.Add("Left2", new Texture(MCpath + "MCLeft2.png"));
            PersonnagePle.Add("Left3", new Texture(MCpath + "MCLeft3.png"));

            PersonnagePle.Add("Right0", new Texture(MCpath + "MCRight0.png"));
            PersonnagePle.Add("Right1", new Texture(MCpath + "MCRight1.png"));
            PersonnagePle.Add("Right2", new Texture(MCpath + "MCRight2.png"));
            PersonnagePle.Add("Right3", new Texture(MCpath + "MCRight3.png"));

            PersonnagePle.Add("shoot", new Texture(MCpath + "shoot.png"));

        }

        private static void GDInit()
        {

            Texture sidewalk = new Texture(@".\Map\" + "Ground0.png");//trottoire
            Texture wall = new Texture(@".\Map\" + "Ground1.png");//mûr

            sidewalk.Repeated = true;
            wall.Repeated = true;

            MapTextures.Add("Sidewalk", sidewalk);
            MapTextures.Add("Wall", wall);
        }

        private static void LVInit()
        {
            Texture heart = new Texture(@".\heart\" + "Live.png");

            heart.Repeated = true;

            LiveTextures.Add("heart", heart);
        }

        private static void GHInit()
        {
            string Gpath = @".\" + @"Enemy\";

            EnemyTextures.Add("Left1", new Texture(Gpath + "GLeft0.png"));
            EnemyTextures.Add("Left2", new Texture(Gpath + "GLeft1.png"));

            EnemyTextures.Add("Right1", new Texture(Gpath + "GRight0.png"));
            EnemyTextures.Add("Right2", new Texture(Gpath + "GRight1.png"));
        }
        private static void MnInit()
        {
            Texture money = new Texture(@".\Money\" + "lo.png");
            money.Repeated = true;
            MoneyTextures.Add("money", money);
        }
        public static void init()
        {
            try
            {
                if (isInitialized == false)
                {
                    MCInit();
                    GDInit();
                    LVInit();
                    GHInit();
                    MnInit();
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
