using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Circle : Shape
    {
        public Circle(double radius) : base(radius, 0)
        {

        }

        public override double Area()
        {
            return pi * x * x;
        }

        //public override double Volume()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
