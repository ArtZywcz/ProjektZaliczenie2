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

namespace Rezerwacje {
    /// <summary>
    /// Interaction logic for AddReservation.xaml
    /// </summary>
    public partial class AddReservation : Window {

        int loggedUserID;
        DateTime date;
        UserPanel w2;
        public AddReservation(int id, DateTime resDate, UserPanel w) {
            InitializeComponent();
            loggedUserID = id;
            date = resDate;
            w2 = w;
            for(int i = 1; i <=16; i++) ComboBoxRoom.Items.Add(i); //Dodaje pokoje do comboBoxa

        }

        private void ComboBoxRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxSlots.Items.Clear();
            Database sql = new Database();
            Rooms room = sql.getRoomData(ComboBoxRoom.SelectedIndex+1, date);

            for (int i = 1; i <= room.roomNow; i++) ComboBoxSlots.Items.Add(i); //TODO zmienna ilość miejsc w pokojach
            ComboBoxSlots.IsEnabled = true;
        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            //TODO Sprawdź czy dane się zgadzają
            bool allgood = true;
            if (TextSurname.Text == "") { TextSurname.BorderBrush = Brushes.Red; allgood = false; }
            if (TextPhone.Text == "") {TextPhone.BorderBrush = Brushes.Red; allgood = false; }
            if (ComboBoxSlots.SelectedItem == null) {ComboBoxSlots.BorderBrush = Brushes.Red; allgood = false; }
            if (!allgood) return;




            //TODO Dodaj do bazy
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

        private void ComboBoxSlots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxSlots.BorderBrush = TextName.BorderBrush;

            if (ComboBoxRoom.SelectedItem == null) return;
            int room = int.Parse(ComboBoxRoom.SelectedItem.ToString());
            Database sql = new Database();

            var roomPrice = sql.getRoomPrice(room);
            roomPrice = roomPrice * (ComboBoxSlots.SelectedIndex + 1);
            int discount = ComboBoxDiscount.SelectedIndex;
            double x;
            switch (discount)
            {
                case -1:
                    x = 1;
                    break;
                case 2:
                    x = 0.5;
                    break;
                case 4:
                    x = 1;
                    break;
                default:
                    x = 0.8;
                    break;
            }

            LabelPrice.Content = Math.Round(roomPrice * x,2).ToString("N2") + " zł";
            LabelAdvance.Content = Math.Round((roomPrice * x)/ 2,2).ToString("N2") + " zł";


        }

        private void TextPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            TextPhone.BorderBrush = TextName.BorderBrush;
        }

        private void TextPhone_DataContextChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextPhone.BorderBrush = Brushes.Transparent;
        }
    }
}
