using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PlayWithMac.Model
{
    public interface IMap
    {
        void Draw(RenderWindow windowHandler, int x, int y);
    }
}
