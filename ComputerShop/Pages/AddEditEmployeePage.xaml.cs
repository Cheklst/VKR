using ComputerShop.Data;
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
    public partial class AddEditEmployeePage : Page
    {
        private Employee _Employee { get; set; }

        private BitmapImage ChangedPhoto = null;
        public AddEditEmployeePage()
        {
            InitializeComponent();
            UpdateComboBoxContent();
        }

        public AddEditEmployeePage(Employee employee)
        {
            InitializeComponent();
            UpdateComboBoxContent();

            _Employee = employee;
            CheckEmployee();

            tbWindowTitle.Text = "Изменение данных сотрудника";
            btnDelete.Visibility = Visibility.Visible;
            btnAddEmployee.Content = "Изменить";

            if (_Employee.EmployeeStatus.Title == "Уволен")
            {
                btnDelete.Content = "Вернуть в штат";
            }

            tbFirstName.Text = Convert.ToString(_Employee.FirstName);
            tbLastName.Text = Convert.ToString(_Employee.LastName);
            tbMiddleName.Text = Convert.ToString(_Employee.MiddleName);
            tbPhone.Text = Convert.ToString(_Employee.Phone);
            tbEmail.Text = Convert.ToString(_Employee.Email);
            tbAdress.Text = Convert.ToString(_Employee.Address); 

            tbLogin.Text = Convert.ToString(_Employee.Login);
            tbPassword.Text = Convert.ToString(_Employee.Password);


            cbGender.SelectedItem = _Employee.Gender.Title;
            cbType.SelectedItem = _Employee.EmployeeType.Title;

            if (_Employee.Photo == null)
            {
                iPhoto.Source = new BitmapImage(new Uri("/Images/null_image.png", UriKind.Relative));
            }
            else
            {
                iPhoto.Source = _Employee.Photo;
            }
        }

        private void UpdateComboBoxContent()
        {
            cbGender.ItemsSource = DatabaseInteraction.GetGenders().Select(i => i.Title);
            cbType.ItemsSource = DatabaseInteraction.GetEmployeeTypes().Select(i => i.Title);
        }

        private void CheckEmployee()
        {
            if (_Employee.EmployeeStatus.Title == "Уволен")
            {
                tbFirstName.IsEnabled = false;
                tbLastName.IsEnabled = false;
                tbMiddleName.IsEnabled = false;
                tbAdress.IsEnabled = false;
                tbEmail.IsEnabled = false;
                tbPhone.IsEnabled = false;
                tbLogin.IsEnabled = false;
                tbPassword.IsEnabled = false;
                cbGender.IsEnabled = false;
                cbType.IsEnabled = false;
                btnChangeImage.IsEnabled = false;
                btnAddEmployee.IsEnabled = false;
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            string ErrorMessage = "";

            if (tbFirstName.Text.Equals(string.Empty))
                ErrorMessage += "Не введено имя работника \n";

            if (tbLastName.Text.Equals(string.Empty))
                ErrorMessage += "Не введена фамилия работника \n";

            if (tbAdress.Text.Equals(string.Empty))
                ErrorMessage += "Не введен адрес работника \n";

            if (tbEmail.Text.Equals(string.Empty))
                ErrorMessage += "Не введен Email работника \n";

            if (tbPhone.Text.Equals(string.Empty) || tbPhone.Text.Length > 11)
                ErrorMessage += "Неверно введен телефон сотрудника \n";

            if (cbGender.SelectedIndex.Equals(-1))
                ErrorMessage += "Не выбран пол сотрудника \n"; 
            
            if (cbType.SelectedIndex.Equals(-1))
                ErrorMessage += "Не выбран тип сотрудника \n";

            if (tbLogin.Text.Equals(string.Empty))
                ErrorMessage += "Не введен логин! \n";

            if (tbPassword.Text.Equals(string.Empty))
                ErrorMessage += "Не введен пароль! \n";

            if (ErrorMessage.Length != 0)
            {
                MessageBox.Show("Ошибка: \n" + ErrorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_Employee is null)
            {
                AddEmployee();
            }
            else
            {
                EditEmployee();
            }
        }

        private void EditEmployee()
        {
            DatabaseInteraction.SaveEditedEmployee(FillEmployee(_Employee));

            MessageBox.Show("Данные работника успешно изменены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService.Navigate(new EmployeePage());
        }

        private void AddEmployee()
        {
            Employee newEmployee = FillEmployee(new Employee());

            DatabaseInteraction.AddNewEmployee(newEmployee);

            MessageBox.Show("Новый работник успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService.Navigate(new EmployeePage());
        }

        private Employee FillEmployee(Employee employee)
        {
            List<Gender> genders = DatabaseInteraction.GetGenders();
            List<EmployeeType> employeeTypes = DatabaseInteraction.GetEmployeeTypes();

            employee.FirstName = tbFirstName.Text.Trim();
            employee.LastName = tbLastName.Text.Trim();
            employee.MiddleName = tbMiddleName.Text.Trim();
            employee.Address = tbAdress.Text.Trim();
            employee.Email = tbEmail.Text.Trim();
            employee.Phone = tbPhone.Text.Trim();
            employee.Login = tbLogin.Text.Trim();
            employee.Password = tbPassword.Text.Trim();
            employee.IdEmployeeType = employeeTypes.Where(w => w.Title == cbType.SelectedItem.ToString()).Select(i => i.IdEmployeeType).FirstOrDefault();
            employee.IdGender = genders.Where(w => w.Title == cbGender.SelectedItem.ToString()).Select(i => i.IdGender).FirstOrDefault();
            employee.IdEmployeeStatus = 1;

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

                employee.EmployeePhoto = data;
            }
            else if (_Employee != null && _Employee.EmployeePhoto != null)
            {
                employee.EmployeePhoto = _Employee.EmployeePhoto;
            }
            else
            {
                employee.EmployeePhoto = null;
            }

            return employee;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_Employee.EmployeeStatus.Title == "Работает")
            {
                _Employee.EmployeeStatus.Title = "Уволен";

                MessageBox.Show("Работник отстранен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _Employee.EmployeeStatus.Title = "Работает";

                MessageBox.Show("Работник возвращен в штат", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DatabaseInteraction.SaveEditedEmployee(_Employee);

            NavigationService.Navigate(new EmployeePage());
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeePage());
        }
    }
}
