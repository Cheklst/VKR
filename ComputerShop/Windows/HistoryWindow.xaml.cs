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
    public partial class HistoryWindow : Window
    {
        public HistoryWindow()
        {
            InitializeComponent();
            List<HistoryView> history = DatabaseInteraction.GetHistory();

            if (PassClass.TypeEmployee != 3)
            {
                history = history.Where(w => w.IdEmployeeType == PassClass.TypeEmployee).ToList();
            }

            dgHistory.ItemsSource = history;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
