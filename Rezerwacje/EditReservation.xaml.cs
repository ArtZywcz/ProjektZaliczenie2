using Rezerwacje.Models;
using System;
using System.Collections.Generic;
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

namespace Rezerwacje
{
    /// <summary>
    /// Interaction logic for EditReservation.xaml
    /// </summary>
    public partial class EditReservation : Window
    {
        DateTime date;
        int loggedUserID;
        UserPanel w2;
        Reservations resData;
        public EditReservation(Reservations reservation, int id, DateTime x, UserPanel w)
        {
            loggedUserID = id;
            date = x;
            w2 = w;
            resData = reservation;
            InitializeComponent();
            TextName.Text = reservation.Name;
            TextSurname.Text = reservation.Surname;
            TextPhone.Text = reservation.PhoneNumber;

            for (int i = 1; i <= 16; i++) ComboBoxRoom.Items.Add(i); //Dodaje pokoje do comboBoxa

            Database sql = new Database();
            
        }

        private void ComboBoxRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Database sql = new Database();
            sql.removeReservation(resData);
            ComboBoxSlots.Items.Clear();
            Rooms room = sql.getRoomData(ComboBoxRoom.SelectedIndex + 1, date);

            for (int i = 1; i <= room.roomNow; i++) ComboBoxSlots.Items.Add(i); //TODO zmienna ilość miejsc w pokojach
            ComboBoxSlots.IsEnabled = true;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            bool allgood = true;
            if (TextSurname.Text == "") { TextSurname.BorderBrush = Brushes.Red; allgood = false; }
            if (TextPhone.Text == "") { TextPhone.BorderBrush = Brushes.Red; allgood = false; }
            if (ComboBoxSlots.SelectedItem == null) { ComboBoxSlots.BorderBrush = Brushes.Red; allgood = false; }
            if (!allgood) return;


            Reservations reservation = new Reservations();
            reservation.Name = TextName.Text;
            reservation.Surname = TextSurname.Text;
            reservation.RoomId = int.Parse(ComboBoxRoom.Text);
            reservation.SlotsQuantity = int.Parse(ComboBoxSlots.Text);
            reservation.PhoneNumber = TextPhone.Text;
            reservation.EmployeeId = loggedUserID;
            reservation.Date = date.Date;



            Database sql = new Database();
            sql.addReservation(reservation);

            w2.getReservations();

            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database sql = new Database();
            sql.removeReservation(resData);

            w2.getReservations();

            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
