using ComputerShop.Data;
using ComputerShop.Windows;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class AddEditProductPage : Page
    {

        private Product _Product { get; set; }

        private BitmapImage ChangedPhoto = null;

        public AddEditProductPage()
        {
            InitializeComponent();
            UpdateComboBoxContent();

        }

        public AddEditProductPage(Product product)
        {
            InitializeComponent();
            UpdateComboBoxContent();

            _Product = product;

            CheckProduct();

            tbWindowTitle.Text = "Редактирование товара";
            btnDelete.Visibility = Visibility.Visible;
            btnAddProduct.Content = "Изменить";

            if (_Product.IsDeleted == true)
            {
                btnDelete.Content = "Вернуть в каталог";
            }

            tbName.Text = Convert.ToString(_Product.Title);
            cbProductType.SelectedItem = _Product.ProductType.Title;
            tbQuantity.Text = Convert.ToString(_Product.Quantity);
            cbProducer.SelectedItem = _Product.Producer.Title;
            cbSupplier.SelectedItem = _Product.Supplier.Title;
            tbPrice.Text = Convert.ToString(_Product.Price);

            if (_Product.Photo == null)
            {
                iPhoto.Source = new BitmapImage(new Uri("/Images/null_image.png", UriKind.Relative));
            }
            else
            {
                iPhoto.Source = _Product.Photo;
            }
        }

        private void UpdateComboBoxContent()
        {
            cbProductType.ItemsSource = DatabaseInteraction.GetProductTypes().Select(i => i.Title);
            cbProducer.ItemsSource = DatabaseInteraction.GetProducers().Select(i => i.Title);
            cbSupplier.ItemsSource = DatabaseInteraction.GetSuppliers().Select(i => i.Title);
        }

        private void CheckProduct()
        {
            if (_Product.IsDeleted == true)
            {
                tbName.IsEnabled = false;
                tbPrice.IsEnabled = false;
                tbQuantity.IsEnabled = false;
                cbProducer.IsEnabled = false;
                cbProductType.IsEnabled = false;
                cbSupplier.IsEnabled = false;
                btnChangeImage.IsEnabled = false;
                btnAddProduct.IsEnabled = false;
            }
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            string ErrorMessage = "";

            if (tbName.Text.Equals(string.Empty))
                ErrorMessage += "Не введено имя товара \n";

            if (cbProductType.SelectedIndex.Equals(-1))
                ErrorMessage += "Не выбран тип товара \n";

            if (!int.TryParse(tbQuantity.Text, out _) || Convert.ToInt32(tbQuantity.Text) < 0)
                ErrorMessage += "Недопустимый ввод количества \n";

            if (cbProducer.SelectedIndex.Equals(-1))
                ErrorMessage += "Не выбран производитель \n";

            if (cbSupplier.SelectedIndex.Equals(-1))
                ErrorMessage += "Не выбран поставщик \n";

            if (!decimal.TryParse(tbPrice.Text, out _) || Convert.ToDecimal(tbPrice.Text) < 0)
                ErrorMessage += "Недопустимый ввод цены \n";


            if (ErrorMessage.Length != 0)
            {
                MessageBox.Show("Ошибка: \n" + ErrorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_Product is null)
            {
                AddProduct();
            }
            else
            {
                EditProduct();
            }
        }

        private void EditProduct()
        {
            DatabaseInteraction.SaveEditedProduct(FillProduct(_Product));

            MessageBox.Show("Материал успешно изменён", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService.Navigate(new ProductPage());
        }

        private void AddProduct()
        {
            Product NewMaterial = FillProduct(new Product());

            DatabaseInteraction.AddNewProduct(NewMaterial);

            MessageBox.Show("Материал успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService.Navigate(new ProductPage());
        }

        private Product FillProduct(Product product)
        {
            List<ProductType> productType = DatabaseInteraction.GetProductTypes();
            List<Producer> producers = DatabaseInteraction.GetProducers(); 
            List<Supplier> suppliers = DatabaseInteraction.GetSuppliers();
            product.Title = tbName.Text.Trim();
            product.Price = Convert.ToDecimal(tbPrice.Text);
            product.Quantity = Convert.ToInt32(tbQuantity.Text);
            product.IdProductType = productType.Where(w => w.Title == cbProductType.SelectedItem.ToString()).Select(i => i.IdProductType).FirstOrDefault();
            product.IdProducer = producers.Where(w => w.Title == cbProducer.SelectedItem.ToString()).Select(i => i.IdProducer).FirstOrDefault();
            product.IdSupplier = suppliers.Where(w => w.Title == cbSupplier.SelectedItem.ToString()).Select(i => i.IdSupplier).FirstOrDefault();
            product.IsDeleted = false;

            if (ChangedPhoto != null)
            {
                byte[] data;
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(ChangedPhoto));

                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                }

                product.ProductPhoto = data;
            }
            else if (_Product != null && _Product.ProductPhoto != null)
            {
                product.ProductPhoto = _Product.ProductPhoto;
            }
            else
            {
                product.ProductPhoto = null;
            }

            return product;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_Product.IsDeleted == false)
            {
                _Product.IsDeleted = true;

                MessageBox.Show("Продукт снят с продажи", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _Product.IsDeleted = false;

                MessageBox.Show("Продукт возвращен в каталог", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DatabaseInteraction.SaveEditedProduct(_Product);

            NavigationService.Navigate(new ProductPage());
        }

        private void btnChangeImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image (*.png);(*.jpg);(*.jpeg) | *.png;*.jpg;*.jpeg;";


            if (fileDialog.ShowDialog() == true)
            {
                string path = fileDialog.FileName;
                ChangedPhoto = new BitmapImage(new Uri(path, UriKind.Absolute));

                iPhoto.Source = ChangedPhoto;
            }
        }

        private void btnAddNewType_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddNewTypeProductPage());
        }

        private void btnAddNewProducer_Click(object sender, RoutedEventArgs e)
        {
            Producer producer = new Producer();
            NavigationService.Navigate(new AddNewSupplierOrProducerPage(producer));
        }

        private void btnAddNewSupplier_Click(object sender, RoutedEventArgs e)
        {
            Supplier supplier = new Supplier();
            NavigationService.Navigate(new AddNewSupplierOrProducerPage(supplier));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductPage());
        }
    }
}
