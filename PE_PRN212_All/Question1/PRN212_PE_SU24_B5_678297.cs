using System;
using System.Collections.Generic;

namespace Question1
{
    internal class PRN212_PE_SU24_B5_678297
    {
        // Define the delegate that takes a Product as input and returns a double (tax amount)
        public delegate double TaxCalculation(Product product);

        public class Product
        {
            // Properties
            public int Id { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public double Price { get; set; }

            // Constructor
            public Product(int id, string name, string type, double price)
            {
                Id = id;
                Name = name;
                Type = type;
                Price = price;
            }

            // Display method for a single product
            public void Display(TaxCalculation taxCalc)
            {
                double tax = taxCalc(this);  // Calculate tax using the delegate
                Console.WriteLine($"Product ID: {Id}, Name: {Name}, Type: {Type}, Price: {Price:C}, Tax: {tax:C}");
            }

            // Static Display method for a list of products
            public static double Display(List<Product> products, TaxCalculation taxCalc)
            {
                double totalTax = 0;
                foreach (var product in products)
                {
                    product.Display(taxCalc);  // Display each product and calculate its tax
                    totalTax += taxCalc(product);  // Accumulate total tax for all products
                }
                Console.WriteLine($"\nTotal Tax for all products: {totalTax:C}");
                return totalTax;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Testcase 1:");
                Product p = new Product(1, "Dell XPS 13 7390", "Computer", 1000);
                p.Display(x => (x.Type.Equals("Computer") ? x.Price * 0.1 : x.Price * 0.05));

                Console.WriteLine("\nTestcase 2:");
                List<Product> products = new List<Product> {
                new Product(2, "Dell Inspiron 15 5505", "Computer", 850),
                new Product(3, "Dell XPS 15 9550", "Computer", 2500),
                new Product(4, "Inspot 5.7L", "Houseware", 200)
            };
                Product.Display(products, x => (x.Type.Equals("Computer") ? x.Price * 0.15 : x.Price * 0.05));
            }
        }
    }

}
