using System;

namespace ConsoleApp1
{
    internal class Calculate
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select a shape to calculate perimeter and area:");
                Console.WriteLine("1. Rectangle");
                Console.WriteLine("2. Square");
                Console.WriteLine("3. Triangle");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter length: ");
                        double length = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter width: ");
                        double width = Convert.ToDouble(Console.ReadLine());
                        var rectangle = Rectangle(length, width);
                        Console.WriteLine($"Perimeter: {rectangle.peri}, Area: {rectangle.acre}");
                        break;

                    case "2":
                        Console.Write("Enter edge length: ");
                        double edge = Convert.ToDouble(Console.ReadLine());
                        var square = Square(edge);
                        Console.WriteLine($"Perimeter: {square.peri}, Area: {square.acre}");
                        break;

                    case "3":
                        Console.Write("Enter edge 1: ");
                        double edge1 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter edge 2: ");
                        double edge2 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter edge 3: ");
                        double edge3 = Convert.ToDouble(Console.ReadLine());
                        var triangle = Triangle(edge1, edge2, edge3);
                        Console.WriteLine($"Perimeter: {triangle.peri}, Area: {triangle.acre}");
                        break;

                    case "0":
                        Console.WriteLine("Exiting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine(); 
            }
        }

        static (double peri, double acre) Rectangle(double length, double width)
        {
            var r = (peri: 0.0, acre: 0.0);
            r.peri = 2 * (length + width);
            r.acre = length * width;
            return r;
        }

        static (double peri, double acre) Square(double edge)
        {
            var r = (peri: 0.0, acre: 0.0);
            r.peri = 4 * edge;
            r.acre = Math.Pow(edge, 2);
            return r;
        }

        static (double peri, double acre) Triangle(double edge1, double edge2, double edge3)
        {
            var r = (peri: 0.0, acre: 0.0);
            r.peri = edge1 + edge2 + edge3;
            double s = r.peri / 2; 
            r.acre = Math.Sqrt(s * (s - edge1) * (s - edge2) * (s - edge3));
            return r;
        }
    }
}
