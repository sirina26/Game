using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;

namespace PlayWithMac.Model
{
    class GameOver
    {
        public void Draw(RenderWindow windowHandler, int xOffset, int yOffset)
        {
            RenderWindow windowGame2 = new RenderWindow(new VideoMode(1200, 700), "PlayWithMac");
            Texture image = new Texture("GameOver.png");
          
            //while (windowGame2.IsOpen)
            //{
            //    if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            //    {
            //        ques.Move(Keyboard.Key.Up);
            //    }
            //}
            //ques.Draw(windowGame2);
            //windowGame2.Display();
        }
    }
}
