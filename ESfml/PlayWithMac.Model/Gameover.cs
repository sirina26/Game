using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PlayWithMac.Model
{
    public class Gameover
    {
        Text _gameover;

        public Gameover()
        {
            _gameover = new Text()
            {
                Font = new Font(@".\Ressources\arial.ttf"),
                Color = Color.Red,
                DisplayedString = "GAME OVER",
                Position = new SFML.System.Vector2f(1200 / 2, 700 / 2)
            };
        }

        public void Draw(RenderWindow windowHandler)
        {
            windowHandler.Draw(_gameover);
        }
    }
}
