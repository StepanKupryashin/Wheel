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
    /// Логика взаимодействия для BasketView.xaml
    /// </summary>
    public partial class BasketView : Window
    {
        private List<products> basketItems = new List<products>();

        public BasketView()
        {
            InitializeComponent();

            // заполнение listView
            basketItems = new List<products>();
            foreach(int id in Basket.getBasket())
            {
                basketItems.Add(Util.GetProduct(id));
            }
            BasketListView.ItemsSource = basketItems;

            if(AppState.Get("userType") == "user")
            {
                nameLabel.Content = $"Ваше ФИО: {AppState.Get("user").name}";
                nameInput.Visibility = Visibility.Hidden;
            }


            updateResultSum();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(AppState.Get("userType") == "guest")
            {
                if(DeliveryInput.Text == "" || nameInput.Text == "")
                {
;                   string msg = "Введите ";
                    msg += DeliveryInput.Text == "" ? "адрес доставки," : "";
                    msg += nameInput.Text == "" ? " ФИО" : "";
                    MessageBox.Show(msg);
                    return;
                }
                createOrder();
            }
            else if(AppState.Get("userType") == "user")
            {
                if(DeliveryInput.Text == "")
                {
                    MessageBox.Show("Введите адрес доставки");
                    return;
                }
                createOrder();
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.ComponentModel.IEditableCollectionView items = BasketListView.Items; //Cast to interface

            products selectedItem = BasketListView.SelectedItems[0] as products; // cast item to product

            Basket.Delete((int)selectedItem.id); // remove product from basket


            items.Remove(BasketListView.SelectedItem); // remove product from listView

            

            updateResultSum();
        }

        private void updateResultSum()
        {
            // хуйня для подсчета хуеты
            resultSum.Content = $"Итого:{basketItems.Sum(product => product.price - product.discount)} Скидка: {basketItems.Sum(product => product.discount)}";

        }

        private void createOrder()
        {
            if (AppState.Get("userType") == "guest")
            {
                Util.createOrder(nameInput.Text, DeliveryInput.Text, null);

                MessageBox.Show("Заказ создан");
            }
            else
            {
                Util.createOrder(AppState.Get("user").name, DeliveryInput.Text, AppState.Get("user").id);
                MessageBox.Show("Заказ создан");

            }
        }
    }
}
