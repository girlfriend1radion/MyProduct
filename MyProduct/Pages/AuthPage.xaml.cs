using MyProduct.Components;
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


namespace MyProduct.Pages
{
    class UserRole
    {
        public static int Info { get; set; } }
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTxt.Text == "" || PasswordTxt.Text == "")
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var UserPath = DBConnect.db.User.Where(x => x.Login == LoginTxt.Text && x.Password == PasswordTxt.Text).FirstOrDefault();
                if (UserPath != null)
                {
                    if (UserPath.RoleId == 2)
                    {
                        MessageBox.Show("Admin");
                        UserRole.Info = UserPath.Role.Id;
                        this.NavigationService.Navigate(new MenuPage());

                    }
                    else if (UserPath.RoleId == 4)
                    {
                        MessageBox.Show("Admin");
                        UserRole.Info = UserPath.Role.Id;
                        this.NavigationService.Navigate(new MenuPage());
                    }
                    else if (UserPath.RoleId == 3)
                    {
                        MessageBox.Show("Admin");
                        UserRole.Info = UserPath.Role.Id;
                        this.NavigationService.Navigate(new MenuPage());
                    }
                    else
                    {
                        UserRole.Info = 1;
                        this.NavigationService.Navigate(new MenuPage());
                        MessageBox.Show("Покупатель");
                    }

                   
                    
                }
                else
                {
                    MessageBox.Show("Такого пользователя нет");
                }

            }

        }
    }
}
