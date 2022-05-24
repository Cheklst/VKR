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
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void btnPass_Click(object sender, RoutedEventArgs e)
        {
            List <Employee> employees = DatabaseInteraction.GetEmployees();
            var employee = employees.Where(w => w.Login == tbLogin.Text && w.Password == pbPassword.Password).FirstOrDefault();

            if (employee != null)
            {
                if (employee.EmployeeStatus.Title == "Работает")
                {
                    PassClass.TypeEmployee = employee.IdEmployeeType;
                    PassClass.IdEmployee = employee.IdEmployee;
                    FrameWindow productWindow = new FrameWindow();
                    Close();
                    productWindow.Show();
                }
                else
                {
                    MessageBox.Show("Пользователь заблокирован.\nОбратитесь к администратору.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует.\nПроверьте правильность логина и пароля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == "Логин")
            {
                tbLogin.Text = "";
                tbLogin.Foreground = Brushes.Black;
            }
        }

        private void tbLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            var login = tbLogin.Text.Trim();
            if (login == "")
            {
                tbLogin.Text = "Логин";
                tbLogin.Foreground = Brushes.Gray;
            }
        }
        private void pbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (pbPassword.Password == "*****")
            {
                pbPassword.Password = "";
                pbPassword.Foreground = Brushes.Black;
            }
        }

        private void pbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            var password = pbPassword.Password.Trim();
            if (password == "")
            {
                pbPassword.Password = "*****";
                pbPassword.Foreground = Brushes.Gray;
            }
        }

    }
}
