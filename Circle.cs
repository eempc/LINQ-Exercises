using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Circle : Shape
    {
        public Circle(double radius) : base(radius, 0, 0)
        {

        }

        public override double Area()
        {
            return pi * x * x;
        }

        public double Diameter()
        {
            return 2 * x;
        }

        public double Circumference()
        {
            return pi * x * 2;
        }

        //public override double Volume()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
