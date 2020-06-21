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
        public string[] loggedInUser;
        string myObject;
        public UserPanel(string[] loggedUser) {

            
            InitializeComponent();
            loggedInUser = loggedUser;

            LabelActiveUser.Content = loggedUser[1] + ' ' + loggedUser[2]; //pokazywanie kto jest zalogowany

            string s = Convert.ToString(Int32.Parse(loggedUser[9]), 2); //Convert to binary in a string

            int[] priviliges = s
                         .Select(c => int.Parse(c.ToString())) // convert each char to int
                         .ToArray(); // Convert IEnumerable from select to Array

            if (priviliges[1] == 0)
            {
                ButtonAdd.Visibility = Visibility.Hidden;
                ButtonEdit.Visibility = Visibility.Hidden;

            }

            if (priviliges[0] == 0)
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
                AddReservation w3 = new AddReservation(int.Parse(loggedInUser[0]), date, this);
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
            string[] employee = sql.getEmployeeDetails(reservationDetail);

            LabelReservationByUser.Content = employee[0] + ' ' + employee[1];



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

            string[] reservationDetail = myObject.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (reservationDetail.Length == 3)
            {
                Array.Resize(ref reservationDetail, reservationDetail.Length + 1);
                reservationDetail[3] = reservationDetail[2];
                reservationDetail[2] = reservationDetail[1];
                reservationDetail[1] = "";
            }
            Array.Resize(ref reservationDetail, reservationDetail.Length + 1);
            reservationDetail[0] = reservationDetail[0].Substring(0, reservationDetail[0].Length - 2);
            DateTime data;
            data = CalendarDate.SelectedDate ?? DateTime.Now;
            labelDate.Content = data.DayOfWeek.ToString() + " " + data.ToString("dd-MM-yyyy");
            reservationDetail[4] = data.Date.ToString("yyyy-MM-dd");

            EditReservation w3 = new EditReservation(reservationDetail, int.Parse(loggedInUser[0]),data, this);
            w3.Show();

        }
    }




}
