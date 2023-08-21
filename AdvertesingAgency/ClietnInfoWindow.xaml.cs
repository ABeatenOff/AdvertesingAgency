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
    /// Логика взаимодействия для ClietnInfoWindow.xaml
    /// </summary>
    public partial class ClietnInfoWindow : Window
    {
        private int IdClient;
        public ClietnInfoWindow(object tag)
        {
            InitializeComponent();
            IdClient = (int)tag;
            var result = ConnectDB.Contxt().Client.Where(p => p.id_client == IdClient);
            labelName.Content = result.First().name;
            LabIdClient.Content = tag.ToString();
            labelSurname.Content = result.First().surname;
            labelPatronymic.Content = result.First().patronymic;
            labelCompanyname.Content = result.First().company_name;
            labelphonenumb.Content = result.First().phone_number;
            labelEmail.Content = result.First().email;
        }

        private void CloseButtoneClientInfo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
