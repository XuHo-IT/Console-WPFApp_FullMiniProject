
using System.Windows;

namespace ManageProductsApp
{
    public partial class WindowManageProducts : Window
    {
        public WindowManageProducts()
        {
            InitializeComponent();
        }

        ManageProducts products = new ManageProducts();
        private void Window_Loaded(object sender, RoutedEventArgs e) => LoadProducts();

        private void LoadProducts()
        {
            // Get products from ManageProducts class
            var productList = products.GetProducts();

            // Debugging step: log the number of products loaded
            MessageBox.Show($"Loaded {productList.Count} products.");

            // Set the ListView's ItemsSource to the list of products
            lvProducts.ItemsSource = productList;
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Product = new Product
                {
                    ProductID = int.Parse(txtProductID.Text),
                    ProductName = txtProductName.Text
                };
                products.InsertProduct(Product);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Product");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Product = new Product
                {
                    ProductID = int.Parse(txtProductID.Text),
                    ProductName = txtProductName.Text
                };
                products.UpdateProduct(Product);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Product");
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Product = new Product
                {
                    ProductID = int.Parse(txtProductID.Text)
                };
                products.DeleteProduct(Product);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Product");
            }
        }
    }
}
