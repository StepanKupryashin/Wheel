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
    /// Логика взаимодействия для RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : Window
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void loginInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(loginInput.Text == "" || password.Password == "" || password2.Password == "" || nameInput.Text == "")
            {
                MessageBox.Show("Убедитесь, что все поля введены");
            }
            else
            {
                if(password.Password != password2.Password)
                {
                    MessageBox.Show("Пароли не совпадают!");
                    return;
                }
                Util.createUser(loginInput.Text, nameInput.Text, Util.HashPassword(password.Password));
                MessageBox.Show("Вы успешно зарегестрированы!");
                AuthView authView = new AuthView();
                authView.Show();
                Close();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
