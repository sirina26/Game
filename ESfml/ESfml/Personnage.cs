using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PlayWithMac
{
    public interface Personnage
    {
        void GetAction();
        void Move();
        void CheckCollision(Macron Collider);
        void CheckCollision(Enemy Collider);
        void CheckCollision(Map Collider);
        void Draw(RenderWindow windowHandler, int xOffset, int yOffset);
        bool GetIsSituated();
        bool Alive { get; }
    }
}
