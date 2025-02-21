using System.IO;
using System.Text.Json;
using System.Windows;
namespace ManageProductsApp
{
    public record Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
    public class ManageProducts
    {
        string fileName = "ProductList.json";
        List<Product> products = new List<Product>();
        public List<Product> GetProducts()
        {
            GetDataFromFile();
            return products;
        }
        public void StoreToFile()
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(products,
                    new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileName, jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GetDataFromFile()
        {
            try
            {
                string fileName = "ProductList.json";
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);


                if (File.Exists(fullPath))
                {
                    string jsonData = File.ReadAllText(fullPath);
                    products = JsonSerializer.Deserialize<List<Product>>(jsonData);
                }
                else
                {
  
                    MessageBox.Show($"File not found at {fullPath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
            }
        }
        public void InsertProduct(Product Product)
        {
            try
            {
                Product p = products.SingleOrDefault(p => p.ProductID == Product.ProductID);
                if (p != null)
                {
                    throw new Exception("This product already exists.");
                }
                products.Add(Product);
                StoreToFile();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Product Product)
        {
            try
            {
                Product p = products.SingleOrDefault(p => p.ProductID == Product.ProductID);
                if (p == null)
                {
                    throw new Exception("This product did not exist.");
                }
                else
                {
                    p.ProductName = Product.ProductName;
                    StoreToFile();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteProduct(Product Product)
        {
            try
            {
                Product p = products.SingleOrDefault(p => p.ProductID == Product.ProductID);
                if (p == null)
                {
                    throw new Exception("This product did not exist.");
                }
                else
                {
                    products.Remove(p);
                    StoreToFile();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}