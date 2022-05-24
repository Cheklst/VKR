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
    public partial class ProductPage : Page
    {
        Context Context = new Context();
        public ProductPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var typeProductList = DatabaseInteraction.GetProductTypes();
            typeProductList.Insert(0, new ProductType { Title = "Все" });

            cbFiltration.ItemsSource = typeProductList;

            if (PassClass.TypeEmployee != 3)
            {
                lwProduct.SelectionMode = SelectionMode.Multiple;
            }
        }

        public void UpdateProductList()
        {
            if (tbSearch is null || cbFiltration is null || cbSort is null || cbFiltration.SelectedItem is null || cbFiltration.SelectedItem is null)
            {
                return;
            }
            tbZeroProduct.Visibility = Visibility.Hidden;

            var FilteriedProductList = Context.Product.ToList();

            if (PassClass.TypeEmployee != 3)
            {
                FilteriedProductList = FilteriedProductList.Where(w => w.IsDeleted == false).ToList();
            }

            if (tbSearch.Text.Length != 0)
            {
                FilteriedProductList = FilteriedProductList.Where(m => m.Title.Contains(tbSearch.Text)).ToList();
            }

            switch (((ComboBoxItem)cbSort.SelectedItem).Content.ToString())
            {
                case "Название по возрастанию":
                    FilteriedProductList = FilteriedProductList.OrderBy(m => m.Title).ToList();
                    break;
                case "Название по убыванию":
                    FilteriedProductList = FilteriedProductList.OrderByDescending(m => m.Title).ToList();
                    break;
                case "Кол-во по возрастанию":
                    FilteriedProductList = FilteriedProductList.OrderBy(m => m.Quantity).ToList();
                    break;
                case "Кол-во по убыванию":
                    FilteriedProductList = FilteriedProductList.OrderByDescending(m => m.Quantity).ToList();
                    break;
                case "Стоимость по возрастанию":
                    FilteriedProductList = FilteriedProductList.OrderBy(m => m.Price).ToList();
                    break;
                case "Стоимость по убыванию":
                    FilteriedProductList = FilteriedProductList.OrderByDescending(m => m.Price).ToList();
                    break;
            }

            if (((ProductType)cbFiltration.SelectedItem).Title != "Все")
            {
                FilteriedProductList = FilteriedProductList.Where(m => m.ProductType == ((ProductType)cbFiltration.SelectedItem)).ToList();
            }

            lwProduct.ItemsSource = FilteriedProductList;

            if (FilteriedProductList.Count == 0)
            {
                tbZeroProduct.Visibility = Visibility.Visible;
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProductList();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProductList();
        }

        private void cbFiltration_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProductList();
        }

        private void btnProductOperation_Click(object sender, RoutedEventArgs e)
        {
            //ProductOperationClass productOperationClass = new ProductOperationClass();
            //productOperationClass.Products = lwProduct.SelectedItems.Cast<Product>().ToList();

            //for (int i = 0; i <= productOperationClass.Products.Count; i++)
            //{
            //    productOperationClass.Quantities.Add(1);
            //}

            //List<int> quantities = new List<int> (lwProduct.SelectedItems.Count);

            NavigationService.Navigate(new ProductOperationPage(lwProduct.SelectedItems.Cast<Product>().ToList()));
        }

        private void lwProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (ListView)sender;

            if (PassClass.TypeEmployee == 1)
            {
                btnProductOperation.ToolTip = "Продажа";

                if (listView.SelectedItems.Count == 0)
                {
                    btnProductOperation.Visibility = Visibility.Hidden;
                }
                else
                {
                    btnProductOperation.Visibility = Visibility.Visible;
                }
            }
            else if (PassClass.TypeEmployee == 2)
            {
                btnProductOperation.ToolTip = "Поставка";

                if (listView.SelectedItems.Count == 0)
                {
                    btnProductOperation.Visibility = Visibility.Hidden;
                }
                else
                {
                    btnProductOperation.Visibility = Visibility.Visible;
                }
            }
        }

        private void lwProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (PassClass.TypeEmployee == 3)
            {
                NavigationService.Navigate(new AddEditProductPage((Product)lwProduct.SelectedItem));
            }
        }
    }
}
