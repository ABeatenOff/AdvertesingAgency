using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace AdvertesingAgency
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
            DBClient();


        }

        public void DBClient()
        {
            var cli = from Client in ConnectDB.Contxt().Client
                      select new
                      {
                          id_clientg = Client.id_client,
                          name = Client.name,
                          surname = Client.surname,
                          patronymic = Client.patronymic,
                          company_name = Client.company_name,
                          phone_number = Client.phone_number,
                          email = Client.email,
                          clientfull = Client.patronymic + Client.surname + Client.name + Client.company_name + Client.phone_number + Client.email + Client.id_client
                      };

            if (!String.IsNullOrEmpty(BoxSearch.Text))
            {
                cli = cli.Where(p => p.clientfull.Contains(BoxSearch.Text) );
            }
            ClientGrid.ItemsSource = cli.ToList();
        }

        private void ButtonEditClient(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            EditClientWindow window = new EditClientWindow(ConnectDB.Contxt().Client.Where(p => p.id_client == (int)but.Tag).First());
            window.Owner = this;
            window.Show();
        }

        private void ButtonAddClient_Click(object sender, RoutedEventArgs e)
        {
            var addClient = new AddClientWindow();
            addClient.Owner = this;
            addClient.Show();
            
        }

        private void ButtonBackMenu_Click(object sender, RoutedEventArgs e)
        {
            var menu = new MenuWindow();
            menu.Show();
            Close();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
           var messageExit = MessageBox.Show("вы уверены что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo);
           switch(messageExit)
            {
                case MessageBoxResult.Yes:
                    Close();
                    break;
                    case MessageBoxResult.No:
                    break;
            }
        }

        private void Searching(object sender, TextChangedEventArgs e)
        {
            DBClient();
        }
    }
}
