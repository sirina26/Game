using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PlayWithMac.Model
{
    public interface IPersonnage
    {
        void GetAction();
        void Move();
        void CheckCollision(Macron Collider);
        void CheckCollision(Enemy Collider);
        void CheckCollision(Map Collider);
        void CheckCollision(Live Collider);
        void Draw(RenderWindow windowHandler, int x, int y);
        bool GetIsSituated();
        bool IsAlive { get; }
    }
}
