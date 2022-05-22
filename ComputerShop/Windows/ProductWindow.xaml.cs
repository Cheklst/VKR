using ComputerShop.Classes;
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
using System.Windows.Shapes;

namespace ComputerShop.Windows
{
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            InitializeComponent();

            if (PassClass.TypeEmployee == 1)
            {
                btnShowHistory.Content += " покупок";
                btnAddProduct.Visibility = Visibility.Hidden;
            }
            else if (PassClass.TypeEmployee == 2)
            {
                btnShowHistory.Content += " поставок";
                btnAddProduct.Visibility = Visibility.Hidden;
            }

            var typeProductList = DatabaseInteraction.GetProductTypes();
            typeProductList.Insert(0, new ProductType { Title = "Все" });

            cbFiltration.ItemsSource = typeProductList;

            UpdateProductList();
            
        }

        public void UpdateProductList()
        {
            if (tbSearch is null || cbFiltration is null || cbSort is null)
            {
                return;
            }
            tbZeroProduct.Visibility = Visibility.Hidden;

            var FilteriedProductList = DatabaseInteraction.GetProducts();

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
                case "Наименование по возрастанию":
                    FilteriedProductList = FilteriedProductList.OrderBy(m => m.Title).ToList();
                    break;
                case "Наименование по убыванию":
                    FilteriedProductList = FilteriedProductList.OrderByDescending(m => m.Title).ToList();
                    break;
                case "Количество по возрастанию":
                    FilteriedProductList = FilteriedProductList.OrderBy(m => m.Quantity).ToList();
                    break;
                case "Количество по убыванию":
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization(); 
            Close();
            autorization.Show();
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            new AccountWindow().ShowDialog();
        }

        private void btnShowHistory_Click(object sender, RoutedEventArgs e)
        {
            new HistoryWindow().ShowDialog();
        }

        private void btnProductOperation_Click(object sender, RoutedEventArgs e)
        {
            List<Product> list = lwProduct.SelectedItems.Cast<Product>().ToList();

            foreach (var i in list)
            {
                new ProductOperationWindow(i).ShowDialog();
            }

            //new ProductOperationWindow(lwProduct.SelectedItems.Cast<Product>().ToList()).ShowDialog();

            UpdateProductList();
        }

        private void lwProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (ListView)sender;

            if (PassClass.TypeEmployee == 1)
            {
                btnProductOperation.Content = "Покупка";

                if (listView.SelectedItems.Count == 0)
                {
                    btnProductOperation.Visibility = Visibility.Hidden;
                    btnEditProduct.Visibility = Visibility.Hidden;
                }
                else
                {
                    btnProductOperation.Visibility = Visibility.Visible; 
                    btnEditProduct.Visibility = Visibility.Hidden;
                }
            }
            else if (PassClass.TypeEmployee == 2)
            {
                btnProductOperation.Content = "Поставка";

                if (listView.SelectedItems.Count == 0)
                {
                    btnProductOperation.Visibility = Visibility.Hidden;
                }
                else
                {
                    btnProductOperation.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (listView.SelectedItems.Count == 0)
                {
                    btnEditProduct.Visibility = Visibility.Hidden;
                }
                else
                {
                    btnEditProduct.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            List<Product> list = lwProduct.SelectedItems.Cast<Product>().ToList();

            foreach (var i in list)
            {
                new AddEditProductWindow(i).ShowDialog();
            }

            UpdateProductList();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            new AddEditProductWindow().ShowDialog();

            UpdateProductList();
        }
    }
}
