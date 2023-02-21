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
    /// Логика взаимодействия для CarAddEdit.xaml
    /// </summary>
    public partial class CarAddEdit : Page
    {
        private Car _current = new Car();

        public CarAddEdit(Car selected)
        {
            InitializeComponent();
            if (selected != null)
                _current = selected;

            DataContext = _current;
            ComboBrand.ItemsSource = ProkatEntities.GetContext().Brand.ToList();
            ComboColor.ItemsSource = ProkatEntities.GetContext().Color.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            
            if (string.IsNullOrWhiteSpace(_current.Model))
                errors.AppendLine("Укажите модель авто");
            if (_current.Brand == null)
                errors.AppendLine("Укажите марку");
            if (_current.Year <= 1900)
                errors.AppendLine("Пожалуйста введите корректный год выпуска в формате YYYY");
            if (_current.Color == null)
                errors.AppendLine("Укажите цвет");
            if (string.IsNullOrWhiteSpace(_current.Number))
                errors.AppendLine("Укажите номер автомобиля");
            if (_current.DayPrice <= 0)
                errors.AppendLine("Цена сутки не может быть отрицательной или равна нуля");
            if (_current.Rented ==true)
                errors.AppendLine("При добавлении машина не может быть сразу арендована");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_current.IdCar == 0)
                ProkatEntities.GetContext().Car.Add(_current);

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
    }
}
