using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithMac
{
    public class Rectangle
    {
        public uint heigth;
        public uint width;

        public int Top { get; set; }
        public int Left { get; set; }
        public int Bottom { get { return Top + (int)heigth; } }
        public int Right { get { return Left + (int)width; } }

        public Rectangle(int top, int left)
        {
            this.Top = top;
            this.Left = left;
        }

        public Rectangle(int top, int left, uint height, uint width)
        {
            this.Top = top;
            this.Left = left;
            this.heigth = height;
            this.width = width;
        }

        public uint Height
        {
            get{
                return heigth;
            }

            set
            {
                heigth = value;
            }
        }

        public uint Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }

        }

        private bool CheckIfVerticalBordersAreInside(Rectangle Collider)
        {
            return (((this.Top >= Collider.Top) && (this.Top <= Collider.Bottom)) || ((this.Bottom >= Collider.Top) && (this.Bottom <= Collider.Bottom)))
                ? true : false;
        }

        private bool CheckIfHorizontalBordersAreInside(Rectangle Collider)
        {
            return (((this.Left >= Collider.Left) && (this.Left <= Collider.Right)) || ((this.Right >= Collider.Left) && (this.Right <= Collider.Right)))
                ? true : false;
        }

        public bool CheckCollisions(Rectangle Collider)
        {
            bool retval = false;

            if ((this.CheckIfVerticalBordersAreInside(Collider)) || (Collider.CheckIfVerticalBordersAreInside(this)))
            {
                if ((this.CheckIfHorizontalBordersAreInside(Collider)) || (Collider.CheckIfHorizontalBordersAreInside(this)))
                {
                    retval = true;
                }
            }

            return retval;
        }
    }
}
