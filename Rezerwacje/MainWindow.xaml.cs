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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using Rezerwacje.Models;

namespace Rezerwacje {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            //UserPanel w2 = new UserPanel();
            //w2.Show();

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            BoxLogin.Text = "";
            BoxPassword.Password = "";
            LabelError.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            Database Sql = new Database();
            if (Sql.getUserData(BoxLogin.Text, BoxPassword.Password) == null) LabelError.Visibility = Visibility.Visible;
            else
            {
                Employees loggedUser = Sql.getUserData(BoxLogin.Text, BoxPassword.Password);
                UserPanel w2 = new UserPanel(loggedUser);
                w2.Show();
                this.Close();
            }



        }
    }
}
