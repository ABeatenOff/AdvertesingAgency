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
    /// Логика взаимодействия для ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        public ServiceWindow()
        {
            InitializeComponent();
            DBService();
            FiltrBox.ItemsSource = ConnectDB.Contxt().Status_service.ToList();
            FiltrBox.DataContext = ConnectDB.Contxt().Status_service.ToList();
        }

        public void DBService()
        {
            ConnectDB.Contxt().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            var masClient = from list_purpose in ConnectDB.Contxt().list_purpose
                            join Contract in ConnectDB.Contxt().Contract on list_purpose.Contract equals Contract
                            join Service in ConnectDB.Contxt().Service on list_purpose.Service equals Service
                            join Dept in ConnectDB.Contxt().Dept on list_purpose.Dept equals Dept
                            join Status_service in ConnectDB.Contxt().Status_service on list_purpose.Status_service equals Status_service
                            select new
                            {
                                id_purpose = list_purpose.id_purpose,
                                id_contract = list_purpose.id_contract,
                                service = list_purpose.Service.name_service,
                                status_service = list_purpose.Status_service.service_status_name,
                                dept = list_purpose.Dept.dept_name

                            };
            if(!String.IsNullOrEmpty(FiltrBox.Text))
            {
                Status_service ch = FiltrBox.SelectedItem as Status_service;
                masClient = masClient.Where(p => p.status_service == ch.service_status_name);
            }
         

            ServiceGrid.ItemsSource = masClient.ToList();
        }

        private void ButtonEditPurpose(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var editserviceWindow = new EditServiceWindow(ConnectDB.Contxt().list_purpose.Where(p => p.id_purpose == (int)button.Tag).First());
            editserviceWindow.Owner = this;
            editserviceWindow.Show();
        }

        private void ButtonAddService_Click(object sender, RoutedEventArgs e)
        {
            var addservice = new AddSeviceWindow();
            addservice.Owner = this;
            addservice.Show();
        }

        private void BackMenuButton_Click(object sender, RoutedEventArgs e)
        {
            var menu = new MenuWindow();
            menu.Show();
            Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CancelFiltrClient_Click(object sender, RoutedEventArgs e)
        {
            FiltrBox.Text = String.Empty;
            
        }

        private void FiltrBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DBService();
        }
    }
}
