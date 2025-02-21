using System.DirectoryServices.ActiveDirectory;
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

namespace WpfApp1
{
    public partial  class MainWindow : Window
    {
        public MainWindow()
        {
            
        }
        private void btnToPage3_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new Page3();
        }

        private void btnToPage4_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new Page4();
        }
    }
}