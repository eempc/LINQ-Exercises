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
            z = height;
        }

        public override double Area()
        {
            return base.Area() * 2 + (x * 2 * pi * z);
        }

        public double Volume()
        {
            return base.Area() * z;
        }

        //public Func<double, double> VolumeAlt = z => base.Area() * z;
    }
}
