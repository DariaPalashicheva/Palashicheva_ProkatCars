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
    /// Логика взаимодействия для RentAddEdit.xaml
    /// </summary>
    public partial class RentAddEdit : Page
    {
        private Rent _current = new Rent();

        public RentAddEdit(Rent selected)
        {
            InitializeComponent();
            if (selected != null)
                _current = selected;

            DataContext = _current;
            ComboClient.ItemsSource = ProkatEntities.GetContext().Client.ToList();
            ComboCar.ItemsSource = ProkatEntities.GetContext().Car.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();


            if (_current.Client == null)
                errors.AppendLine("Укажите клиента");
            if (_current.Car == null)
                errors.AppendLine("Укажите машину");
            if (_current.StartDate.Year < 2000 || _current.StartDate.Year >= 2030)
                errors.AppendLine("Введите дату начала аренды");
            if (_current.EndDate.Year < 2000 || _current.EndDate.Year >= 2030)
                errors.AppendLine("Введите дату конца аренды");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_current.IdRent == 0)
                ProkatEntities.GetContext().Rent.Add(_current);

            try
            {
                ProkatEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnSave_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
