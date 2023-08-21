using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
       
        public OrderWindow()
        {
            InitializeComponent();
            OrderDB();
            
        }
        private void OrderWindowForm_Loaded(object sender, RoutedEventArgs e)
        {
           

            StatusCombo.ItemsSource = ConnectDB.Contxt().Payment_status.ToList();
            
            StatusCombo.DataContext = ConnectDB.Contxt().Payment_status.ToList();

            StatusCombo.SelectedItem = null;


        }

        public void OrderDB()
        {
            ConnectDB.Contxt().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            var masOrder = from Contract in ConnectDB.Contxt().Contract // когда создавал БД случайно назвал таблицу Contract, а не Order((
                           join Client in ConnectDB.Contxt().Client on Contract.Client equals Client
                           join Payment_status in ConnectDB.Contxt().Payment_status on Contract.Payment_status equals Payment_status
                           join Contract_status in ConnectDB.Contxt().Contract_status on Contract.Contract_status equals Contract_status
                           select new
                           {
                               ContractNumber = Contract.id_contract,
                               id_client = Client.id_client,
                               ClientFIO = Contract.Client.name + " " + Contract.Client.surname + " " + Contract.Client.patronymic,
                               DataPrepar = Contract.date_preparation,
                               DataExec = Contract.date_execution,
                               PayStatus = Contract.Payment_status.name_payment_status,
                               ContractDetails = Contract.contract_details,
                               ContractStat = Contract.Contract_status.contract_status_name,
                               id_paystat = Payment_status.id_payment_status
                              };
            if(!String.IsNullOrEmpty(SearchBox.Text))
            {
                masOrder = masOrder.Where(p => p.ClientFIO.Contains(SearchBox.Text));
            }
            if (!String.IsNullOrEmpty(StatusCombo.Text))
            {
                Payment_status ch = StatusCombo.SelectedItem as Payment_status;
                masOrder = masOrder.Where(p => p.PayStatus == ch.name_payment_status);
              
            }
            
            OrderGrid.ItemsSource = masOrder.ToList();
            
        }

        private void Client_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var labelClient = sender as Label;
            var clientInfoWindow = new ClietnInfoWindow(labelClient.Tag);
            clientInfoWindow.Owner = this;
            clientInfoWindow.Show();
        }

        private void Searching(object sender, TextChangedEventArgs e)
        {
            OrderDB();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var messageExit = MessageBox.Show("вы уверены что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo);
            switch (messageExit)
            {
                case MessageBoxResult.Yes:
                    Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void BackMenuButton_Click(object sender, RoutedEventArgs e)
        {
            var menu = new MenuWindow();
            menu.Show();
            Close();

        }

        private void ServiceListButton_Click(object sender, RoutedEventArgs e)
        {
            var serviceWindow = new ServiceWindow();
            serviceWindow.Show();
            Close();
        }

        private void StatusCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderDB();
        }

        private void CancelFiltrClient_Click(object sender, RoutedEventArgs e)
        {
            StatusCombo.Text = String.Empty;
            StatusCombo.SelectedItem = null;
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var addorder = new AddOrderWindow();
            addorder.Owner = this;
            addorder.Show();

        }

        private void ButtonEditContract(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            EditOrderWindow window = new EditOrderWindow(ConnectDB.Contxt().Contract.Where(p => p.id_contract == (int)but.Tag).First());
            window.Owner = this;
            window.Show();
        }
    }
}
