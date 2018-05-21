using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithMac.Model
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
            get
            {
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

        private bool CheckIfVerticalBordersAreInside(Rectangle rect)
        {
            return (((this.Top >= rect.Top) && (this.Top <= rect.Bottom)) || ((this.Bottom >= rect.Top) && (this.Bottom <= rect.Bottom)))
                ? true : false;
        }

        private bool CheckIfHorizontalBordersAreInside(Rectangle rect)
        {
            return (((this.Left >= rect.Left) && (this.Left <= rect.Right)) || ((this.Right >= rect.Left) && (this.Right <= rect.Right)))
                ? true : false;
        }

        public bool CheckCollisions(Rectangle rect)
        {
            bool retval = false;

            if ((this.CheckIfVerticalBordersAreInside(rect)) || (rect.CheckIfVerticalBordersAreInside(this)))
            {
                if ((this.CheckIfHorizontalBordersAreInside(rect)) || (rect.CheckIfHorizontalBordersAreInside(this)))
                {
                    retval = true;
                }
            }

            return retval;
        }
    }
}
