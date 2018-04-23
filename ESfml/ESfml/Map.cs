using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PlayWithMac
{
    public class Map
    {
        PartGame _context;

        uint _width;
        uint _heigth;

        Macron _macron;

        public Map(PartGame acontext, uint awith, uint aheigth)
        {
            _context = acontext;
            _width = awith;
            _heigth = aheigth;

            _macron = new Macron(_context);
        }

        public void Draw(RenderWindow window, uint mapWidth, uint mapHeight)
        {
            //_macron.Draw(window, mapWidth, mapHeight);
            
        }
    }
}
