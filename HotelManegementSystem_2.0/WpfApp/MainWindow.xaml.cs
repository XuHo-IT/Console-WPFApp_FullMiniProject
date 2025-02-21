using BussinessObject;
using Repository;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly IRoomInformationRepository roomRepository;
        private readonly string connectionString;
        private int currentUserId; 
        private string currentUser; 

        public MainWindow(string username, int userId)
        {
            InitializeComponent();
            currentUser = username;
            currentUserId = userId; 
            roomRepository = new RoomInformationRepository();

            LoadUserInfo();
            LoadAvailableRooms();
        }

        private void LoadUserInfo()
        {
          
            UserInfo.Text = $"Welcome, {currentUser}!";
        }

        private void LoadAvailableRooms()
        {
            
            var rooms = roomRepository.GetAllRoomInformation();
            dataGridRooms.ItemsSource = rooms;
        }


        private void BookRoom_Click(object sender, RoutedEventArgs e)
        {
            var selectedRoom = (RoomInformation)dataGridRooms.SelectedItem;

            if (selectedRoom != null)
            {
            
                BookingReservation bookingReservation = new BookingReservation
                {
                    BookingDate = DateTime.Now,
                    TotalPrice = selectedRoom.RoomPricePerDay,
                    CustomerID = currentUserId,
                    BookingStatus = 0 
                };

                int bookingReservationId = 0;
                try
                {
                    var bookingReservationRepository = new BookingReservationRepository();
                    bookingReservationId = bookingReservationRepository.AddBookingReservation(bookingReservation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving booking reservation: {ex.Message}");
                    return; 
                }

          
                BookingDetail bookingDetail = new BookingDetail
                {
                    BookingReservationID = bookingReservationId,
                    RoomID = selectedRoom.RoomID,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    ActualPrice = selectedRoom.RoomPricePerDay
                };

          
                SaveBookingDetail(bookingDetail);

             
                MessageBox.Show("Thank you for your order! We will notify you in the billing section once your reservation is confirmed.");

           
            }
            else
            {
                MessageBox.Show("Please select a room to book.");
            }
        }
        private void ViewBill_Click(object sender, RoutedEventArgs e)
        {
            LoadUserBills(); 
        }


        private void LoadUserBills()
        {
            var bookingReservationRepository = new BookingReservationRepository();
            var userBills = bookingReservationRepository.GetUserBills(currentUserId);
            dataGridUserBills.ItemsSource = userBills;

            foreach (var bill in userBills)
            {
                var billDetails = bookingReservationRepository.GetUserBillDetails(bill.BookingReservationID);
             
            }
        }
        private void dataGridUserBills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridUserBills.SelectedItem is BookingReservation selectedBill)
            {
                var bookingReservationRepository = new BookingReservationRepository();
                var billDetails = bookingReservationRepository.GetUserBillDetails(selectedBill.BookingReservationID);
                dataGridBillDetails.ItemsSource = billDetails; 
            }
        }

        private void SaveBookingReservation(BookingReservation bookingReservation)
        {
            try
            {
                var bookingReservationRepository = new BookingReservationRepository();
                bookingReservationRepository.AddBookingReservation(bookingReservation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving booking reservation: {ex.Message}");
            }
        }

        private void SaveBookingDetail(BookingDetail bookingDetail)
        {
            try
            {
                var bookingDetailRepository = new BookingDetailRepository();
                bookingDetailRepository.AddBookingDetail(bookingDetail);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving booking detail: {ex.Message}");
            }
        }
    }
}
