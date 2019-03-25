using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Square
    {
        public double x { get; set; }

        public Square(double x)
        {
            this.x = x;
        }

        public Square() {

        }

        public double Area() {
            return x * x;
        }
    }
}
