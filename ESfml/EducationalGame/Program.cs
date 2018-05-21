using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Audio;
using SFML.Window;
using SFML.System;

namespace EducationalGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Questions menu = new Questions(1200, 700);
            RenderWindow windowGame2 = new RenderWindow(new VideoMode(1200, 700), "PlayWithMac");

            CircleShape cs = new CircleShape(100.0f);
            cs.FillColor = Color.Green;
            windowGame2.SetActive();
            while (windowGame2.IsOpen())
            {
                windowGame2.Clear();
                windowGame2.DispatchEvents();
                windowGame2.Draw(cs);
                windowGame2.Display();
            }
        }
    }
}
//


