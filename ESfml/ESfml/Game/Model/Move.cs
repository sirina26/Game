using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESfml.Game.Model
{
    public class Move
    {
        public interface animated
        {
            void GetAction();
            void Move();
            void CheckCollision(Macron Collider);
            /*void CheckCollision(Soldat Collider);
            void CheckCollision(Ground Collider);
            void Draw(RenderWindow windowHandler, int xOffset, int yOffset);*/
            bool GetIsSituated();
            bool Alive { get; }
        }
    }
}
