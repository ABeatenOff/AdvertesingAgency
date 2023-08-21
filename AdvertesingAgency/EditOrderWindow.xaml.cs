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
    /// Логика взаимодействия для EditOrderWindow.xaml
    /// </summary>
    public partial class EditOrderWindow : Window
    {
    
        public EditOrderWindow(Contract contract)
        {
           
            InitializeComponent();
            DataContext = contract;
            ClientCombo.ItemsSource = ConnectDB.Contxt().Client.ToList();
            DateCreatBox.Text = ConnectDB.Contxt().Contract.ToString();
            DateExecBox.Text = ConnectDB.Contxt().Contract.ToString();
            PayStatusCombo.ItemsSource = ConnectDB.Contxt().Payment_status.ToList();
            DescroptionBox.Text = ConnectDB.Contxt().Contract.ToString();
            OrderStatusCombo.ItemsSource = ConnectDB.Contxt().Contract_status.ToList();
        }

        private void SaveChangeButton_Click(object sender, RoutedEventArgs e)
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
            if (DescroptionBox.Text == "")
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
                ConnectDB.Contxt().SaveChanges();
                ((OrderWindow)this.Owner).OrderDB();
                MessageBox.Show("Данные изменены");
                Close();
            }
        }
    }
}
