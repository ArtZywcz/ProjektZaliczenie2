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
        public AddReservation() {
            InitializeComponent();

            for(int i = 1; i <=16; i++) ComboBoxRoom.Items.Add(i); //Dodaje pokoje do comboBoxa

        }

        private void ComboBoxRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxSlots.Items.Clear();
            for (int i = 1; i <= 16; i++) ComboBoxSlots.Items.Add(i); //TODO zmienna ilość miejsc w pokojach
            ComboBoxSlots.IsEnabled = true;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) 
        {
            LabelNumber.Content = SliderNumber.Value; //TODO XDDD Usuń to i zrób normalne

            //TODO po wybraniu ilości osób w pokoju oblicz cenę i zadatek
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            //TODO Sprawdź czy dane się zgadzają

            //TODO Dodaj do bazy

            //TODO? Wyświetl podsumowanie jak się zgadza

            //TODO Jak się zgadza to zamknij
        }
    }
}
