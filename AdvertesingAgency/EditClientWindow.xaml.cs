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
    /// Логика взаимодействия для EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        Client clin;
        
        public EditClientWindow(Client client)
        {
            clin = client;
            InitializeComponent();
            DataContext = client;
           

            NameBox.Text = ConnectDB.Contxt().Client.ToString();
            SurnameBox.Text = ConnectDB.Contxt().Client.ToString();
            PatronymicBox.Text = ConnectDB.Contxt().Client.ToString();
            EmailBox.Text = ConnectDB.Contxt().Client.ToString();
            CompanyNameBox.Text = ConnectDB.Contxt().Client.ToString();
            PhoneBox.Text = ConnectDB.Contxt().Client.ToString();


        }

        private void SaveChangesClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(NameBox.Text) || String.IsNullOrEmpty(SurnameBox.Text) || String.IsNullOrEmpty(PatronymicBox.Text) || String.IsNullOrEmpty(PhoneBox.Text) || String.IsNullOrEmpty(CompanyNameBox.Text) || String.IsNullOrEmpty(EmailBox.Text))
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                ConnectDB.Contxt().SaveChanges();
                ((ClientWindow)this.Owner).DBClient();
                MessageBox.Show("Данные изменены");
                Close();
            }
        }
    }
}
