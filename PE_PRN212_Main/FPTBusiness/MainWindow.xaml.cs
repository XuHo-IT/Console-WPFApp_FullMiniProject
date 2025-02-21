using FPT.BOs;
using FPT.Repository;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FPT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserRepository userRepository;

        public MainWindow()
        {
            InitializeComponent();
            userRepository = new UserRepository();

        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;


            // Check if the username and password are valid
            var user = userRepository.GetUserByEmailAndPassword(email, password);
            if (user != null)
            {
                SessionManager.UserId = user.AccountID;
                if (user.Role == 1)
                {
                    MessageBox.Show("Welcome Admin!");
                    var adminWindow = new AdminWindow(); // Replace with your admin window
                    adminWindow.Show();
                }
               
                else
                {
                    MessageBox.Show("Invalid role.");
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            EmailTextBox.Clear();
            PasswordBox.Clear();
        }
    }
}