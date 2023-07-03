using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wheel
{
    /*
     * Классс реализующий функции утилиты для взаимодействия с моделями, почему так?
     * да потому что при обновлении модели код модели регениться, а нам нужно что-то постабильнее
     */
    public class Util
    {

        private static WheelDBEntities wheel = new WheelDBEntities();

        public static users GetUserByLogin(string login)
        {
            // поиск юзера по логину
            return wheel.users.FirstOrDefault(user => user.login == login);
        }

        public static products GetProduct(int id)
        {
            // поиск продукта по id
            return wheel.products.Find(id);
        } 

        public static void createOrder(string customer, string delivery, dynamic user_id = null)
        {
            orders order = new orders();


            order.created_at = DateTime.Now;

            order.updated_at = DateTime.Now;

            order.user_id = user_id;

            order.customer = customer;

            order.delivery_address = delivery;

            wheel.orders.Add(order);

            wheel.SaveChanges();


            foreach (int id in Basket.getBasket())
            {

                wheel.orders_products.Add(new orders_products() {order_id = order.id, product_id = GetProduct(id).id });
                wheel.SaveChanges();


            }
        }

        public static void createUser(string login, string name, string password)
        {
            wheel.users.Add(new users() { login = login, name = name, password = password});
            wheel.SaveChanges();
        }

        public static string HashPassword(string password)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                var hashedBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            var enteredPasswordHash = HashPassword(enteredPassword);
            return string.Equals(enteredPasswordHash, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
        // поиск  позиций в заказе
        public static List<products> getProductsOrder(int id)
        {
            List<orders_products> orders = wheel.orders_products.Where(
                orders_product => orders_product.order_id == id).ToList();

            List<products> productsList = new List<products>();

            foreach(orders_products product in orders)
            {
                productsList.Add(GetProduct((int)product.product_id));
            }

            return productsList;
        }

        public static List<orders> GetUserOrders(int userId)
        {
            return wheel.orders.Where(order => order.user_id == userId).ToList();
        }

        public static List<orders> GetOrders()
        {
            return wheel.orders.ToList();
        }

        public static List<products> GetProducts()
        {
            return wheel.products.ToList();
        }
    }
}
