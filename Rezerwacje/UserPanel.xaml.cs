using Rezerwacje.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

namespace Rezerwacje {
    /// <summary>
    /// Interaction logic for UserPanel.xaml
    /// </summary>
    public partial class UserPanel : Window {
        public Employees loggedInUser;
        string myObject;
        public UserPanel(Employees loggedUser) {

            
            InitializeComponent();
            loggedInUser = loggedUser;

            LabelActiveUser.Content = loggedUser.Name + ' ' + loggedUser.Surname; //pokazywanie kto jest zalogowany

            var priviliges = Convert.ToString(loggedInUser.Priviliges, 2).Select(s => s.Equals('1')).ToArray();

            if (priviliges[1] == false)
            {
                ButtonAdd.Visibility = Visibility.Hidden;
                ButtonEdit.Visibility = Visibility.Hidden;

            }

            if (priviliges[0] == false)
            {
                LabelReservationByText.Visibility = Visibility.Hidden;
                LabelReservationByUser.Visibility = Visibility.Hidden;

            }

            getReservations();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e) {
            DateTime? dateOrNull = CalendarDate.SelectedDate;
            if (dateOrNull != null)
            {
                DateTime date = dateOrNull.Value;
                AddReservation w3 = new AddReservation(loggedInUser.EmployeeId, date, this);
                w3.Show();
            }
                
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LabelReservationByUser.Content = "";
            var baseobj = sender as FrameworkElement;
            myObject = baseobj.DataContext as String;
            
            string[] reservationDetail = myObject.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (reservationDetail.Length == 3)
            {
                Array.Resize(ref reservationDetail, reservationDetail.Length + 1);
                reservationDetail[3] = reservationDetail[2];
                reservationDetail[2] = reservationDetail[1];
                reservationDetail[1] = "";
            }
            reservationDetail[0] = reservationDetail[0].Substring(0, reservationDetail[0].Length - 2);
            Database sql = new Database();
            Employees employee = sql.getEmployeeDetails(reservationDetail, CalendarDate.SelectedDate);

            LabelReservationByUser.Content = employee.Name + ' ' + employee.Surname;



        }

        public void getReservations()
        {
            Database sql = new Database();
            DG1.Items.Clear();
            for (int i = 1; i <= 16; i++)
            {


                //CalendarDate.SelectedDate = DateTime.Now.AddDays(-1);
                DateTime? dateOrNull = CalendarDate.SelectedDate;
                if (dateOrNull != null)
                {
                    DateTime date = dateOrNull.Value;


                    var data2 = sql.getRoomData(i, date);
                    DG1.Items.Add(data2);
                }
            } //Tworzenie kalendarza
        }

        private void CalendarDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            getReservations();
            DateTime data;
            data = CalendarDate.SelectedDate ?? DateTime.Now;
            labelDate.Content = data.DayOfWeek.ToString() + " " + data.ToString("dd-MM-yyyy") ;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (myObject == null) return;

            Reservations reservation = new Reservations();
            reservation.Date = CalendarDate.SelectedDate ?? DateTime.Now;

            string[] reservationDetail = myObject.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (reservationDetail.Length == 3)
            {
                Array.Resize(ref reservationDetail, reservationDetail.Length + 1);
                reservationDetail[3] = reservationDetail[2];
                reservationDetail[2] = reservationDetail[1];
                reservationDetail[1] = "";

            }

            reservation.Name = reservationDetail[1];
            reservation.Surname = reservationDetail[2];
            reservation.PhoneNumber = reservationDetail[3];

            reservationDetail[0] = reservationDetail[0].Substring(0, reservationDetail[0].Length - 2);
            reservation.SlotsQuantity = int.Parse(reservationDetail[0]);


            EditReservation w3 = new EditReservation(reservation, loggedInUser.EmployeeId, CalendarDate.SelectedDate ?? DateTime.Now, this);
            w3.Show();
            myObject = null;

        }
    }




}
