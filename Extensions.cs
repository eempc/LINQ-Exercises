using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public static class Extensions
    {
        // Func<0, 2> Compose <0, 1, 2>(this Func<1, 2> functionA, Func<0, 1> functionB)
        public static Func<T, TReturn2> Compose<T, TReturn1, TReturn2>(this Func<TReturn1, TReturn2> func1, Func<T, TReturn1> func2)
        {
            return x => func1(func2(x));
        }
    }
}
