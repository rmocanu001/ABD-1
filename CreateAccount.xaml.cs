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

        public Costumer _account;
        public CreateAccount()
        {
            InitializeComponent();
        }

        public Costumer GetUser(string username , string password)
        {
            // sql interogation to get data 

            Costumer user = (from u in Utils.context.Costumers
                        where (u.login_name.Equals(username) && u.login_password.Equals(password))
                        select u).FirstOrDefault();
            return user;

        }

        public void InsertAccount(Costumer account)
        {
            //sql interogation to insert data
           Utils.context.Costumers.Add(account);
           Utils.context.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _account = new Costumer {
               login_name = Username.Text.ToString(),
              login_password = Password.Password.ToString(),
                email =  Email.Text.ToString()
            };

            if ( GetUser(_account.login_name,_account.login_password) != null)
            {
                MessageBoxButton button = MessageBoxButton.OKCancel;
                MessageBoxImage image = MessageBoxImage.Warning;
                MessageBox.Show("Can t insert user. Already in database","Alert",button , image);
            }
            else
            {   

                InsertAccount(_account);
                ListItem listItem = new ListItem(_account);
                listItem.Show();
                this.Hide();

            }
        }

       
    }
}
