using ComputerShop.Data;
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

namespace ComputerShop.Pages
{
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var typeEmployee = DatabaseInteraction.GetEmployeeTypes();
            typeEmployee.Insert(0, new EmployeeType { Title = "Все" });

            cbFiltration.ItemsSource = typeEmployee;
        }

        public void UpdateEmployeeList()
        {
            if (tbSearch is null || cbFiltration is null || cbSort is null || cbFiltration.SelectedItem is null || cbFiltration.SelectedItem is null)
            {
                return;
            }

            tbZeroEmployee.Visibility = Visibility.Hidden;

            var FilteriedEmployeeList = DatabaseInteraction.GetEmployees();

            if (tbSearch.Text.Length != 0)
            {
                FilteriedEmployeeList = FilteriedEmployeeList.Where(m => m.FirstName.Contains(tbSearch.Text) 
                || m.LastName.Contains(tbSearch.Text) 
                || m.MiddleName.Contains(tbSearch.Text)).ToList();
            }

            switch (((ComboBoxItem)cbSort.SelectedItem).Content.ToString())
            {
                case "Фамилия по возрастанию":
                    FilteriedEmployeeList = FilteriedEmployeeList.OrderBy(m => m.LastName).ToList();
                    break;
                case "Фамилия по убыванию":
                    FilteriedEmployeeList = FilteriedEmployeeList.OrderByDescending(m => m.LastName).ToList();
                    break;
                case "Имя по возрастанию":
                    FilteriedEmployeeList = FilteriedEmployeeList.OrderBy(m => m.FirstName).ToList();
                    break;
                case "Имя по убыванию":
                    FilteriedEmployeeList = FilteriedEmployeeList.OrderByDescending(m => m.FirstName).ToList();
                    break;
                case "Отчество по возрастанию":
                    FilteriedEmployeeList = FilteriedEmployeeList.OrderBy(m => m.MiddleName).ToList();
                    break;
                case "Отчество по убыванию":
                    FilteriedEmployeeList = FilteriedEmployeeList.OrderByDescending(m => m.MiddleName).ToList();
                    break;
            }

            if (((EmployeeType)cbFiltration.SelectedItem).Title != "Все")
            {
                FilteriedEmployeeList = FilteriedEmployeeList.Where(m => m.EmployeeType == ((EmployeeType)cbFiltration.SelectedItem)).ToList();
            }

            lwEmployee.ItemsSource = FilteriedEmployeeList;

            if (FilteriedEmployeeList.Count == 0)
            {
                tbZeroEmployee.Visibility = Visibility.Visible;
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateEmployeeList();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateEmployeeList();
        }

        private void cbFiltration_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateEmployeeList();
        }

        private void lwEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AddEditEmployeePage((Employee)lwEmployee.SelectedItem));
        }
    }
}
