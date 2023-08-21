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

namespace AdvertesingAgency
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void OpenClientWindow_Button(object sender, RoutedEventArgs e)
        {
            var clientWindow = new ClientWindow();
            clientWindow.Show();
            Close();
        }

        private void OpenOrderWindow_Button(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrderWindow();
            orderWindow.Show();
            Close();
        }

        private void OpenServiceWindow_Button(object sender, RoutedEventArgs e)
        {
            var serviceWindow = new ServiceWindow();
            serviceWindow.Show();
            Close();
        }
    }
}
