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
    /// Логика взаимодействия для AuthView.xaml
    /// </summary>
    public partial class AuthView : Window
    {
        public AuthView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (loginInput.Text == "" || passwordInput.Password == "")
            {
                MessageBox.Show("Убедитесь что все поля введены");
            }
            else
            {
                users user = Util.GetUserByLogin(loginInput.Text);
                if (user != null && Util.VerifyPassword(passwordInput.Password, user.password))
                {
                    AppState.Add("isLogin", true);

                    AppState.Add("userType", "user");

                    AppState.Add("user", user);

                    if(user.permission == 2)
                    {
                        AdminPanel adminPanel = new AdminPanel();
                        adminPanel.Show();
                        Close();
                        return;
                    }

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppState.Add("isLogin", true);

            AppState.Add("userType", "guest");

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            Close();
        }
    }
}
