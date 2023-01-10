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

namespace MagazinElectronic
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {

        public Account _account;
        public CreateAccount()
        {
            InitializeComponent();
        }

        public List<Account> GetUser(string username , string password)
        {
            // sql interogation to get data 

            return null;
        }

        public void InsertAccount(Account account)
        {
            //sql interogation to insert data
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _account = new Account(
                Username.Text.ToString(),
               Password.SecurePassword.ToString()
            );

            if ( GetUser(_account.Name,_account.Password) == null)
            {
                MessageBoxButton button = MessageBoxButton.OKCancel;
                MessageBoxImage image = MessageBoxImage.Warning;
                MessageBox.Show("Can t insert user. Already in database","Alert",button , image);
            }
            else
            {   
                InsertAccount(_account);
            }
        }

       
    }
}
