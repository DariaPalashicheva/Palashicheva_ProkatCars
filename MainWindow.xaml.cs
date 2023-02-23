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

namespace Palashicheva_ProkatCars
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
            Manager.MainFrame = MainFrame;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void BtnCar_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CarPage());
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientPage());
        }

        private void BtnRent_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RentPage());
        }
    }
}
