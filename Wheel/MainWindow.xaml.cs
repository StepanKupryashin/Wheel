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
namespace Wheel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // немного костыльно, но увы и ах, идите нахуй, мне лень заморачиваться со страницами
            if (!(bool)AppState.Get("isLogin"))
            {
                AuthView authView = new AuthView();
                authView.Show();
                this.Close();
            }

            WheelDBEntities wheel = new WheelDBEntities();
            InitializeComponent();
            ProductsListView.ItemsSource = wheel.products.ToList();
            this.checkBasketCount();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var current = (products)ProductsListView.SelectedItem;
            //MessageBox.Show($"{current.id} {current.name}");
            Basket.addProduct((int)current.id);
            this.checkBasketCount();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string msg = "";
            foreach (var product in Basket.getBasket())
            {
                msg += $" {product}";
            }
            MessageBox.Show($"{msg}");
            BasketView basketView = new BasketView();
            basketView.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Basket.ClearBasket();
            this.checkBasketCount();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (AppState.Get("userType") == "guest")
            {
                userNameBox.Content = "Гость";
            }
            else
            {
                userNameBox.Content = AppState.Get("user").name;
            }
        }

        private void checkBasketCount()
        { 
            btnClearBasket.Visibility = Visibility.Hidden;
            btnEnterBasket.Visibility = Visibility.Hidden;
            if (Basket.getBasket().Count > 0)
            {
                btnClearBasket.Visibility = Visibility.Visible;
                btnEnterBasket.Visibility = Visibility.Visible;
            }

        }

        private void userNameBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UserOrders userOrders = new UserOrders();
            userOrders.Show();
            Close();
        }
    }
}
