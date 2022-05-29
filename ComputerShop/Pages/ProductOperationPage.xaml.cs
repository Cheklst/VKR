using ComputerShop.Classes;
using ComputerShop.Data;
using ComputerShop.Windows;
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
    public partial class ProductOperationPage : Page
    {
        List<Product> _Products;

        public ProductOperationPage(List<Product> products)
        {
            InitializeComponent();
            _Products = products;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _Products.Count; i++)
            {
                _Products[i].Quantity = 1;
            }

            lwProduct.ItemsSource = _Products;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductPage());
        }

        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            List<Product> products = DatabaseInteraction.GetProducts();

            List<Product> ChangedProducts = new List<Product> { };

            for (int i = 0; i < products.Count; i++)
            {
                for (int j = 0; j < _Products.Count; j++)
                {
                    if (products[i].IdProduct == _Products[j].IdProduct)
                    {
                        ChangedProducts.Add(products[i]);
                    }
                }
            }
            ChangedProducts = ChangedProducts.OrderBy(m => m.Title).ToList();
            _Products = _Products.OrderBy(m => m.Title).ToList();


            if (PassClass.TypeEmployee == 1)
            {
                for (int i = 0; i < _Products.Count; i++)
                {
                    int newQuantity = ChangedProducts[i].Quantity - _Products[i].Quantity;
                    if (newQuantity >= 0)
                    {
                        ChangedProducts[i].Quantity = newQuantity;
                        DatabaseInteraction.SaveEditedProduct(ChangedProducts[i]);

                        History history = new History {
                            Date = DateTime.Now,
                            Quantity = _Products[i].Quantity,
                            IdEmployee = PassClass.IdEmployee,
                            IdProduct = ChangedProducts[i].IdProduct
                        };
                        DatabaseInteraction.AddNewHistory(history);
                    }
                    else
                    {
                        MessageBox.Show($"На складе нет такого количества товара \"{products[i].Title}\"", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
                MessageBox.Show("Покупка оформлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new ProductPage());
            }
            else
            {
                for (int i = 0; i < _Products.Count; i++)
                {
                    ChangedProducts[i].Quantity = ChangedProducts[i].Quantity + _Products[i].Quantity;
                    DatabaseInteraction.SaveEditedProduct(ChangedProducts[i]); 
                    
                    History history = new History
                    {
                        Date = DateTime.Now,
                        Quantity = _Products[i].Quantity,
                        IdEmployee = PassClass.IdEmployee,
                        IdProduct = ChangedProducts[i].IdProduct
                    };
                    DatabaseInteraction.AddNewHistory(history);

                }
                MessageBox.Show("Поставка оформлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new ProductPage());
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            foreach(var i in _Products)
            {
                if (int.TryParse((sender as TextBox).Text, out _))
                {
                    if (i.IdProduct == (int)(sender as TextBox).Tag)
                    {
                        i.Quantity = int.Parse((sender as TextBox).Text);
                    }
                }
                else
                {
                    MessageBox.Show("Неверно введено количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
