using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Question2
{
    public partial class MainWindow : Window
    {
        private readonly BookRepository _repository;
        private Book selectedBook;
        private ObservableCollection<Book> books;

        public MainWindow()
        {
            InitializeComponent();
            _repository = new BookRepository();
            books = new ObservableCollection<Book>(_repository.GetAllRoomInformation()); 
            dataGridBooks.ItemsSource = books; 
            LoadBooks();
        }

        private void LoadBooks()
        {
  
            books.Clear();
            foreach (var book in _repository.GetAllRoomInformation())
            {
                books.Add(book);
            }
        }

        private void dataGridBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBook = (Book)dataGridBooks.SelectedItem;
            if (selectedBook != null)
            {
                txtBookID.Text = selectedBook.BookId.ToString();
                txtTitle.Text = selectedBook.Title;
                txtPublisher.Text = selectedBook.Publisher;
                txtPublicationYear.Text = selectedBook.PublicationYear.ToString();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
      
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

           
            if (string.IsNullOrWhiteSpace(txtPublisher.Text))
            {
                MessageBox.Show("Publisher cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

        
            if (string.IsNullOrWhiteSpace(txtPublicationYear.Text))
            {
                MessageBox.Show("Publication Year cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            if (!int.TryParse(txtPublicationYear.Text, out int publicationYear))
            {
                MessageBox.Show("Please enter a valid year for Publication Year.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

      
            if (publicationYear < 1900 || publicationYear > DateTime.Now.Year)
            {
                MessageBox.Show($"Please enter a valid year between 1900 and {DateTime.Now.Year}.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }


            if (selectedBook != null)
            {
                selectedBook.Title = txtTitle.Text;
                selectedBook.Publisher = txtPublisher.Text;
                selectedBook.PublicationYear = publicationYear;

                _repository.UpdateBook(selectedBook);
                LoadBooks();
                MessageBox.Show("Book updated successfully!");
            }
        }


        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            int bookID;
            if (!int.TryParse(txtBookID.Text, out bookID))
            {
                MessageBox.Show("Please enter a valid Book ID.");
                return;
            }

   
            Book newBook = new Book
            {
                BookId = bookID,
                Title = txtTitle.Text,
                Publisher = txtPublisher.Text,
                PublicationYear = int.TryParse(txtPublicationYear.Text, out int year) ? year : 0
            };

          
            books.Add(newBook); 

            txtBookID.Clear();
            txtTitle.Clear();
            txtPublisher.Clear();
            txtPublicationYear.Clear();
        }

    
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
        
            Book selectedBook = dataGridBooks.SelectedItem as Book;
            if (selectedBook != null)
            {
           
                books.Remove(selectedBook); 
            }
            else
            {
                MessageBox.Show("Please select a book to delete.");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string titleQuery = txtSearchTitle.Text.ToLower();
            string publisherQuery = txtSearchPublisher.Text.ToLower();
            string yearQuery = txtSearchYear.Text;

            var filteredBooks = _repository.GetAllRoomInformation().Where(book =>
                (string.IsNullOrEmpty(titleQuery) || book.Title.ToLower().Contains(titleQuery)) &&
                (string.IsNullOrEmpty(publisherQuery) || book.Publisher.ToLower().Contains(publisherQuery)) &&
                (string.IsNullOrEmpty(yearQuery) || book.PublicationYear.ToString() == yearQuery)
            ).ToList();

            dataGridBooks.ItemsSource = filteredBooks;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchButton_Click(sender, e);
        }
    }
}
