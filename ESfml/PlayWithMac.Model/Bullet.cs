using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace PlayWithMac.Model
{
    public class Bullet
    {
        CircleShape shape;
        Vector2f currVelocity;
        float maxSpeed;
               

        public Bullet(float radius = 5f)
        {
            shape = new CircleShape();
            currVelocity = new Vector2f(0f, 0f);
            maxSpeed = 15f;
            shape.Radius = radius;
            shape.FillColor = Color.Red;
        }

        public CircleShape Shape {
            get { return shape; }
            set { shape = value;  }
        }
        public Vector2f CurrVelocity { get; set; }
        public float Maxspeed { get; }
    }
}
