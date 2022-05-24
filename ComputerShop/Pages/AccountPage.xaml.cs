using ComputerShop.Classes;
using ComputerShop.Data;
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
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
            var employeeType = DatabaseInteraction.GetEmployeeTypes();
            var employees = DatabaseInteraction.GetEmployees();
            var employee = employees.Where(x => x.IdEmployee == PassClass.IdEmployee).FirstOrDefault();


            tbLastName.Text = employee.LastName;
            tbMiddleName.Text = employee.MiddleName;
            tbFirstName.Text = employee.FirstName;
            tbEmail.Text = employee.Email;
            tbPhone.Text = employee.Phone;
            tbAddress.Text = employee.Address;
            tbTypeEmployee.Text += employeeType.Where(i => i.IdEmployeeType == employee.IdEmployeeType).Select(w => w.Title).FirstOrDefault();

            if (Photo(employee) != null)
            {
                iPhoto.Source = Photo(employee);
            }
        }

        public BitmapImage Photo(Employee employee)
        {
            if (employee.EmployeePhoto == null || employee.EmployeePhoto.Length == 0)
            {
                return null;
            }
            MemoryStream mem = new MemoryStream(employee.EmployeePhoto);
            var photo = new BitmapImage();
            photo.BeginInit();
            photo.CacheOption = BitmapCacheOption.OnLoad;
            photo.StreamSource = mem;
            photo.EndInit();
            photo.Freeze();
            return photo;
        }
    }
}
