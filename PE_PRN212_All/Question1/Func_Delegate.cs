using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    internal class Func_Delegate
    {
        class Program
        {
            static void Main()
            {
                Func<int, int, int> add = (a, b) => a + b;
                int result = add(5, 10); // Returns 15
                Console.WriteLine(result);
            }
        }

    }
}
