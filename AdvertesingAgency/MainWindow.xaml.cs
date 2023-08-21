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

namespace AdvertesingAgency
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(LoginBox.Text))
            {
                if(!String.IsNullOrEmpty(PassBox.Password))
                {
                    IQueryable<User> users = ConnectDB.Contxt().User.Where(p => p.login == LoginBox.Text && p.password == PassBox.Password);
                    if (users.Count() == 1)
                    {
                        MessageBox.Show($"Добро пожаловать, {users.First().name} {users.First().surname}");
                        var menus = new MenuWindow();
                        menus.Show();
                        Close();
                    }
                    else MessageBox.Show("Неверный логин или пароль");
                }    
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
