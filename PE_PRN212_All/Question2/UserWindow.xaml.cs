using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Reflection.Metadata.BlobBuilder;

namespace Question2
{
    public partial class UserWindow : Window
    {
        private readonly UserRepository _userRepository;
        private User selectedUser;
        private ObservableCollection<User> users;
        public UserWindow()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
            users = new ObservableCollection<User>(_userRepository.GetAllUsers());
            UserDataGrid.ItemsSource = users;
            LoadUsers();
        }
        private void LoadUsers()
        {

            users.Clear();
            foreach (var book in _userRepository.GetAllUsers())
            {
                users.Add(book);
            }
        }
        private void dataGridBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = (User)UserDataGrid.SelectedItem;
            if (selectedUser != null)
            {
         
                FullNameTextBox.Text = selectedUser.FullName;
                EmailTextBox.Text = selectedUser.Email;
                MembershipDatePicker.SelectedDate = selectedUser.MembershipDate.ToDateTime(new TimeOnly(0, 0));
                MaleRadioButton.IsChecked = selectedUser.Gender == "Male";
                FemaleRadioButton.IsChecked = selectedUser.Gender == "Female";

                // Set the ComboBox to the user's position
                PositionComboBox.SelectedItem = PositionComboBox.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(item => item.Content.ToString() == selectedUser.Position);
            }
        }
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
        
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text))
            {
                MessageBox.Show("Full Name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //if (string.IsNullOrWhiteSpace(PhoneTextBox.Text) || !System.Text.RegularExpressions.Regex.IsMatch(PhoneTextBox.Text, @"^\d{10,15}$"))
            //{
            //    MessageBox.Show("Please enter a valid phone number (10-15 digits only).", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}


            string email = EmailTextBox.Text;
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var emailRegex = new System.Text.RegularExpressions.Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!MembershipDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a valid membership date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

    
            string gender = MaleRadioButton.IsChecked == true ? "Male" : FemaleRadioButton.IsChecked == true ? "Female" : null;
            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Please select a gender.");
                return;
            }

   
            var selectedPosition = PositionComboBox.SelectedItem as ComboBoxItem;
            string position = selectedPosition?.Content.ToString();
            if (string.IsNullOrEmpty(position))
            {
                MessageBox.Show("Please select a position.");
                return;
            }

            if (selectedUser != null)
            {
           
                selectedUser.FullName = FullNameTextBox.Text;
                selectedUser.Email = EmailTextBox.Text;
                selectedUser.MembershipDate = DateOnly.FromDateTime(MembershipDatePicker.SelectedDate.Value);
                selectedUser.Gender = gender; 
                selectedUser.Position = position;  

              
                _userRepository.UpdateUser(selectedUser);

                LoadUsers();

                MessageBox.Show("User updated successfully!");
            }
        }



        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string titleQuery = FullNameSearchBox.Text.ToLower();
            string publisherQuery = EmailSearchBox.Text.ToLower();

            var filteredBooks = _userRepository.GetAllUsers().Where(book =>
                (string.IsNullOrEmpty(titleQuery) || book.FullName.ToLower().Contains(titleQuery)) &&
                (string.IsNullOrEmpty(publisherQuery) || book.Email.ToLower().Contains(publisherQuery)) 
     
            ).ToList();

            UserDataGrid.ItemsSource = filteredBooks;
        }
    }
}
