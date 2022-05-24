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
    public partial class FrameWindow : Window
    {
        public FrameWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnProductPage.Visibility = Visibility.Hidden;

            fMain.Navigate(new Uri("Pages/ProductPage.xaml", UriKind.Relative));

            if (PassClass.TypeEmployee == 1)
            {
                btnShowHistory.ToolTip += " продаж";
                btnAddProduct.Visibility = Visibility.Hidden;
                btnEmployee.Visibility = Visibility.Hidden;
                btnAddEmployee.Visibility = Visibility.Hidden;
            }
            else if (PassClass.TypeEmployee == 2)
            {
                btnShowHistory.ToolTip += " поставок";
                btnAddProduct.Visibility = Visibility.Hidden;
                btnEmployee.Visibility = Visibility.Hidden;
                btnAddEmployee.Visibility = Visibility.Hidden;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization(); 
            Close();
            autorization.Show();
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            fMain.Navigate(new Uri("Pages/AccountPage.xaml", UriKind.Relative));
            btnProductPage.Visibility = Visibility.Visible;
        }

        private void btnShowHistory_Click(object sender, RoutedEventArgs e)
        {
            fMain.Navigate(new Uri("Pages/HistoryPage.xaml", UriKind.Relative));
            btnProductPage.Visibility = Visibility.Visible;
        }


        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            fMain.Navigate(new Uri("Pages/AddEditProductPage.xaml", UriKind.Relative));
            btnProductPage.Visibility = Visibility.Hidden;
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            fMain.Navigate(new Uri("Pages/EmployeePage.xaml", UriKind.Relative));
            btnProductPage.Visibility = Visibility.Hidden;
            btnEmployee.Visibility = Visibility.Hidden;
            btnProducts.Visibility = Visibility.Visible;
        }
        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            fMain.Navigate(new Uri("Pages/ProductPage.xaml", UriKind.Relative));
            btnProductPage.Visibility = Visibility.Hidden;
            btnEmployee.Visibility = Visibility.Visible;
            btnProducts.Visibility = Visibility.Hidden;
        }

        private void btnProductPage_Click(object sender, RoutedEventArgs e)
        {
            fMain.Navigate(new Uri("Pages/ProductPage.xaml", UriKind.Relative));
            btnProductPage.Visibility = Visibility.Hidden;
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            fMain.Navigate(new Uri("Pages/AddEditEmployeePage.xaml", UriKind.Relative));
            btnProductPage.Visibility = Visibility.Hidden;
        }
    }
}
