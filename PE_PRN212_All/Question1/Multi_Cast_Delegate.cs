using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    internal class Multi_Cast_Delegate
    {
        // Define a multi-cast delegate
        delegate void Notify();

        class Program
        {
            static void Main()
            {
                Notify notify = DisplayMessage1;
                notify += DisplayMessage2; // Adds another method to the invocation list
                notify(); // Calls DisplayMessage1 and then DisplayMessage2
            }

            static void DisplayMessage1()
            {
                Console.WriteLine("First message.");
            }

            static void DisplayMessage2()
            {
                Console.WriteLine("Second message.");
            }
        }

    }
}
