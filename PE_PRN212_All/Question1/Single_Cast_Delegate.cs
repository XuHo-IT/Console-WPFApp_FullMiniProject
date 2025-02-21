using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    internal class Single_Cast_Delegate
    {
        delegate void Notify();

        class Program
        {
            static void Main()
            {
                Notify notify = DisplayMessage;
                notify(); // Calls DisplayMessage
            }

            static void DisplayMessage()
            {
                Console.WriteLine("This is a single-cast delegate.");
            }
        }
    }
}
