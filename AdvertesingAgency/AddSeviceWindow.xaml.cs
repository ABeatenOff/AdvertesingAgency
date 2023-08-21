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
    /// Логика взаимодействия для AddSeviceWindow.xaml
    /// </summary>
    public partial class AddSeviceWindow : Window
    {
        public AddSeviceWindow()
        {
            InitializeComponent();
            IdOrderCombo.ItemsSource = ConnectDB.Contxt().Contract.ToList();
            ServiceCombo.ItemsSource = ConnectDB.Contxt().Service.ToList();
            DeptCombo.ItemsSource = ConnectDB.Contxt().Dept.ToList();
            StatusServiceCombo.ItemsSource = ConnectDB.Contxt().Status_service.ToList();
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (IdOrderCombo.SelectedItem == null)
                errors.AppendLine("Не указан клиент");
            if (ServiceCombo.SelectedItem == null)
                errors.AppendLine("Не указан статус оплаты");

            if (DeptCombo.SelectedItem == null)
                errors.AppendLine("Не указан статус оплаты");
           
            if (StatusServiceCombo.SelectedItem == null)
                errors.AppendLine("Не указан статус заказа");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {

                ConnectDB.Contxt().list_purpose.Add(new list_purpose()
                {
                    Contract = IdOrderCombo.SelectedItem as Contract,
                    Service = ServiceCombo.SelectedItem as Service,
                    Dept = DeptCombo.SelectedItem as Dept,
                    Status_service = StatusServiceCombo.SelectedItem as Status_service

                });

                ConnectDB.Contxt().SaveChanges();
                ((ServiceWindow)this.Owner).DBService();
                MessageBox.Show("Данные добавлены");
                Close();
            }
        }
    }
}
