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
    class Macron
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
    }
}
