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
using System.Xml.Linq;

namespace AdvertesingAgency
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
           
            
           if(String.IsNullOrEmpty(NameBox.Text) || String.IsNullOrEmpty(SurnameBox.Text) || String.IsNullOrEmpty(PatronymicBox.Text) || String.IsNullOrEmpty(PhoneBox.Text) || String.IsNullOrEmpty(CompanyNameBox.Text) || String.IsNullOrEmpty(EmailBox.Text))
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                ConnectDB.Contxt().Client.Add(new Client()
                {
                    name = NameBox.Text,
                    surname = SurnameBox.Text,
                    patronymic = PatronymicBox.Text,
                    company_name = CompanyNameBox.Text,
                    phone_number = PhoneBox.Text,
                    email = EmailBox.Text,
                });
                ConnectDB.Contxt().SaveChanges();
                ((ClientWindow)this.Owner).DBClient();
                MessageBox.Show("Данные добавлены");
                Close();
            }
        }
    }
}
