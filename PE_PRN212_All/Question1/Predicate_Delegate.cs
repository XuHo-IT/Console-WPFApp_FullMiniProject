using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    internal class Predicate_Delegate
    {
        class Program
        {
            static void Main()
            {
                Predicate<int> isPositive = number => number > 0;
                bool result = isPositive(5); // Returns true
                Console.WriteLine(result);
            }
        }

    }
}
