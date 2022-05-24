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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComputerShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<HistoryView> history = DatabaseInteraction.GetHistory();

            if (PassClass.TypeEmployee != 3)
            {
                history = history.Where(w => w.IdEmployeeType == PassClass.TypeEmployee).ToList();
            }

            dgHistory.ItemsSource = history;
        }
    }
}
