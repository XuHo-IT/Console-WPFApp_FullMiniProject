using System.Linq;
using System.Windows;
using Question2; // Assuming your context and models are in the Question2 namespace

namespace PRN212_FA24_PE_121844_Q2
{
    public partial class Login : Window
    {
        private readonly PePrn24fallB1Context _context = new PePrn24fallB1Context();

        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string fullName = UsernameTextBox.Text;
            string email = PasswordTextBox.Password;

            // Validate credentials
            var user = _context.Users
                .FirstOrDefault(u => u.FullName == fullName && u.Email == email);

            if (user != null)
            {
                // Login successful, open UserWindow
                UserWindow userWindow = new UserWindow();
                userWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Full Name or Email.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
