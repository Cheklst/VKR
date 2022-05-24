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
    /// <summary>
    /// Логика взаимодействия для AddNewSupplierOrProducerPage.xaml
    /// </summary>
    public partial class AddNewSupplierOrProducerPage : Page
    {
        private byte role;
        public AddNewSupplierOrProducerPage(Producer producer)
        {
            InitializeComponent(); 
            role = 0;

            tbLable.Text += "нового производителя";
        }

        public AddNewSupplierOrProducerPage(Supplier supplier)
        {
            InitializeComponent();
            role = 1;

            tbLable.Text += "нового поставщика";
        }

        private void Check()
        {
            string ErrorMessage = "";

            if (tbTitle.Text.Equals(string.Empty))
                ErrorMessage += "Не введено наименование \n";

            if (tbCountry.Text.Equals(string.Empty))
                ErrorMessage += "Не введена страна \n";

            if (tbAdress.Text.Equals(string.Empty))
                ErrorMessage += "Не введен город \n";

            if (tbEmail.Text.Equals(string.Empty))
                ErrorMessage += "Не введен Email \n";

            if (tbPhone.Text.Equals(string.Empty))
                ErrorMessage += "Не введен телефон \n";

            if (tbPhone.Text.Trim().Length > 11)
                ErrorMessage += "Телефон введен неверно \n";


            if (ErrorMessage.Length != 0)
            {
                MessageBox.Show("Ошибка: \n" + ErrorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (role == 0)
            {
                AddProducer();
            }
            else
            {
                AddSupplier();
            }
        }

        private void AddSupplier()
        {
            Supplier supplier = new Supplier
            {
                Title = tbTitle.Text.Trim(),
                Country = tbCountry.Text.Trim(),
                Address = tbAdress.Text.Trim(),
                Phone = tbPhone.Text,
                Email = tbEmail.Text.Trim()
            };
            DatabaseInteraction.AddNewSupplier(supplier);
            MessageBox.Show($"Новый поставщик \"{tbTitle.Text}\" успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService.Navigate(new AddEditProductPage());
        }

        private void AddProducer()
        {
            Producer producer = new Producer
            {
                Title = tbTitle.Text.Trim(),
                Country = tbCountry.Text.Trim(),
                Address = tbAdress.Text.Trim(),
                Phone = tbPhone.Text,
                Email = tbEmail.Text.Trim()
            };
            DatabaseInteraction.AddNewProducer(producer);
            MessageBox.Show($"Новый производитель \"{tbTitle.Text}\" успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService.Navigate(new AddEditProductPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Check();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProductPage());
        }
    }
}
