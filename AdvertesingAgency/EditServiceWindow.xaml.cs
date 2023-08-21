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
    /// Логика взаимодействия для EditServiceWindow.xaml
    /// </summary>
    public partial class EditServiceWindow : Window
    {
        public EditServiceWindow(object editserviceWindow)
        {
            InitializeComponent();
            DataContext = editserviceWindow;

            IdOrderCombo.ItemsSource = ConnectDB.Contxt().Contract.ToList();
            ServiceCombo.ItemsSource = ConnectDB.Contxt().Service.ToList();
            DeptCombo.ItemsSource = ConnectDB.Contxt().Dept.ToList();
            StatusServiceCombo.ItemsSource = ConnectDB.Contxt().Status_service.ToList();
        }

        private void EditServiceButton_Click(object sender, RoutedEventArgs e)
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

                ConnectDB.Contxt().SaveChanges();
                ((ServiceWindow)this.Owner).DBService();
                MessageBox.Show("Данные добавлены");
                Close();
            }
        }
    }
}
