using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Cylinder : Circle
    {
        public Cylinder(double radius, double height) : base (radius)
        {
            y = height;
        }

        public override double Area()
        {
            return base.Area() * 2 + (x * 2 * pi * y);
        }

        public double Volume()
        {
            return base.Area() * y;
        }
    }
}
