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
    /// Логика взаимодействия для RentPage.xaml
    /// </summary>
    public partial class RentPage : Page
    {
        public RentPage()
        {
            InitializeComponent();
            DGrid.ItemsSource = ProkatEntities.GetContext().Rent.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ProkatEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = ProkatEntities.GetContext().Rent.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RentAddEdit((sender as Button).DataContext as Rent));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RentAddEdit(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = DGrid.SelectedItems.Cast<Rent>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ForRemoving.Count()} элементов?", "Внимание",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ProkatEntities.GetContext().Rent.RemoveRange(ForRemoving);
                    ProkatEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGrid.ItemsSource = ProkatEntities.GetContext().Rent.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
