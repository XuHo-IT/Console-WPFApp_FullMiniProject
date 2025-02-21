using BussinessObject;
using Service;
using Repository;
using System.Windows;

namespace WPFApp
{
    public partial class LoginWindow : Window
    {
        private readonly ICustomerService customerService;

        public LoginWindow()
        {
            InitializeComponent();
            var connectionString = "your_connection_string"; // Replace with your actual connection string
            var customerRepository = new CustomerRepository(connectionString);
            customerService = new CustomerService(customerRepository);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Get customer details by user ID
            var customer = customerService.GetCustomerById(int.Parse(txtUser.Text)); // Assumes txtUser.Text contains the customer ID
            // Check if customer exists and password is correct
            if (customer != null)
            {
                // Ensure the password is not null and matches the one entered in the password field
                if (!string.IsNullOrEmpty(txtPass.Password) && customer.Password.Equals(txtPass.Password))
                {
                    // Check if the user has the correct role (assuming 1 is the correct role)
                    if (customer.CustomerStatus == 1) // Assuming CustomerStatus is used for role checking
                    {
                        this.Hide();  // Hide the current window
                        Window1 mainWindow = new Window1();
                        mainWindow.Show();  // Show the main window
                    }
                    else
                    {
                        MessageBox.Show("You do not have permission!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid password!");
                }
            }
            else
            {
                MessageBox.Show("Account not found!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
