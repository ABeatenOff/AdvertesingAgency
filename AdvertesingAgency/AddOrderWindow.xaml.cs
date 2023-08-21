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
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow()
        {
            InitializeComponent();
            ClientCombo.ItemsSource = ConnectDB.Contxt().Client.ToList();
            PayStatusCombo.ItemsSource = ConnectDB.Contxt().Payment_status.ToList();
            OrderStatusCombo.ItemsSource = ConnectDB.Contxt().Contract_status.ToList();
            

        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (ClientCombo.SelectedItem == null)
                errors.AppendLine("Не указан клиент");
            if (DateCreatBox.Text == "")
                errors.AppendLine("Не укаказана дата создания");
            if (DateExecBox.Text == "")
                errors.AppendLine("Не укаказана дата исполнения");
            if (PayStatusCombo.SelectedItem == null)
                errors.AppendLine("Не указан статус оплаты");
            if (DescriptionBox.Text == "")
                errors.AppendLine("Не укаказано описание заказа");
            if (OrderStatusCombo.SelectedItem == null)
                errors.AppendLine("Не указан статус заказа");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {

                ConnectDB.Contxt().Contract.Add(new Contract()
                {
                    Client = ClientCombo.SelectedItem as Client,
                    date_preparation = DateCreatBox.Text,
                    date_execution = DateExecBox.Text,
                    contract_details = DescriptionBox.Text,
                    Contract_status = OrderStatusCombo.SelectedItem as Contract_status,
                    Payment_status = PayStatusCombo.SelectedItem as Payment_status,

                });
                ConnectDB.Contxt().SaveChanges();
                ((OrderWindow)this.Owner).OrderDB();
                MessageBox.Show("Данные добавлены");
                Close();
            }

           
        }
    }
}
