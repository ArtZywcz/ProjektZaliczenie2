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
        string[] resData;
        public EditReservation(string[] reservation, int id, DateTime x, UserPanel w)
        {
            loggedUserID = id;
            date = x;
            w2 = w;
            resData = reservation;
            InitializeComponent();
            TextName.Text = reservation[1];
            TextSurname.Text = reservation[2];
            TextPhone.Text = reservation[3];

            for (int i = 1; i <= 16; i++) ComboBoxRoom.Items.Add(i); //Dodaje pokoje do comboBoxa
            

            Database sql = new Database();
            sql.removeReservation(reservation);
        }

        private void ComboBoxRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxSlots.Items.Clear();
            Database sql = new Database();
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


            string[] reservation = new string[7];
            reservation[0] = TextName.Text;
            reservation[1] = TextSurname.Text;
            reservation[2] = ComboBoxRoom.Text;
            reservation[3] = ComboBoxSlots.Text;
            reservation[4] = TextPhone.Text;
            reservation[5] = loggedUserID.ToString();
            reservation[6] = date.Date.ToString("yyyy-MM-dd");

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
    }
}
