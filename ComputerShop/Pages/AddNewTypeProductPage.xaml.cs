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
    public partial class AddNewTypeProductPage : Page
    {
        public AddNewTypeProductPage()
        {
            InitializeComponent();

            UpdateComboBox();
        }

        private void UpdateComboBox()
        {
            var typeProductList = DatabaseInteraction.GetProductTypes();
            typeProductList.Insert(0, new ProductType { Title = "Все существующие типы" });

            cbProductType.ItemsSource = typeProductList;
        }

        private void btnAddNewType_Click(object sender, RoutedEventArgs e)
        {
            if (tbNewType.Text.Trim() != "")
            {
                List<ProductType> productTypesList = DatabaseInteraction.GetProductTypes();
                if (productTypesList.Where(i => i.Title == tbNewType.Text.Trim()).ToList().Count() > 0)
                {
                    MessageBox.Show("Такой тип уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    ProductType productType = new ProductType();
                    productType.Title = tbNewType.Text;

                    DatabaseInteraction.AddNewProductType(productType);

                    MessageBox.Show($"Тип проодукта \"{tbNewType.Text}\" успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    UpdateComboBox();
                    btnExit.Content = "Назад";
                }
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProductPage());
        }

        private void cbProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbProductType.SelectedIndex = 0;
        }
    }
}
