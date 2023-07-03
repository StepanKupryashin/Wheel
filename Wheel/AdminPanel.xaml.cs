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

namespace Wheel
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
        }
        // если что оно не сохраняется просто мне уже лень
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            orderGrid.ItemsSource = Util.GetOrders();
            productsGrid.ItemsSource = Util.GetProducts();
        }
    }
}
