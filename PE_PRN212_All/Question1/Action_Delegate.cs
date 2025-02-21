using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    internal class Action_Delegate
    {
        class Program
        {
            static void Main()
            {
                Action<string> greet = name => Console.WriteLine($"Hello, {name}!");
                greet("Alice"); // Prints "Hello, Alice!"
            }
        }

    }
}
