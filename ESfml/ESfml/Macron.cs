using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
namespace PlayWithMac
{
    public class Macron
    {
       Dictionary<Sprite, Macron> _macron = new Dictionary<Sprite, Macron>();
         public enum MacSide
         {
             Left,
             MovesLeft1,
             MovesLeft2,
             Right,
             MovesRight1,
             MovesRight2,
         }
        Texture texture = new Texture(12,15);
        PartGame _contexte;
        Sprite mac = new Sprite();

        float _life;
        //Pour voir la position du joueur 
        float _x;
        float _y;
        
        static Texture _picturepersonnage = new Texture(@"C:\dev\PlayWithMac\ESfml\ESfml\Ressources\personnage.jpg");
        static Sprite personnage;
        public void Draw()
        {
            
        }
        public SFML.System.Vector2f Position { get; private set; }

        public Macron(PartGame acontext)
        {
            personnage = new Sprite(_picturepersonnage);
            _contexte = acontext;
        }
    


        public void Draw(RenderWindow window)
        {
            Position = new SFML.System.Vector2f(1200 / 2, (750 / 4) * 3);
            window.Draw(personnage);

            // _map.Draw(Window, DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT);
        }

    }
}
