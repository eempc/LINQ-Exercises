using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    abstract class Shape
    {
        public const double pi = Math.PI;
        protected double x, y, z;

        public Shape(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public abstract double Area();
        //public abstract double Volume();

    }
}
