using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{

    internal class AnotherClass
    {
        public int Number { get; set; }

        public AnotherClass(int number) {
            this.Number = number;
        }

        public static AnotherClass operator +(AnotherClass list1, AnotherClass list2)
        {
            AnotherClass result = new AnotherClass(list1.Number + list2.Number);                       

            return result;
        }
    }

    internal class Operators<T>: List<T>
    {
        public static Operators<T> operator + (Operators<T> list1, Operators<T> list2)
        {
            Operators<T> result = new Operators<T>();

            result.AddRange(list1);
            result.AddRange(list2);

            return result;
        }
    }
}
