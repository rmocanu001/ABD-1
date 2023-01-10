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
    /// Interaction logic for Login.xaml
    /// </summary>
    

    public partial class Login : Window
    {
        private Account _account;
        
        public Login()
        {
            InitializeComponent();

        }

        public bool Authenticate(string user, string pass)
        {   
            // sql interogation 
            if (user == "ADMIN" && pass == "Pass")
            {
                return true;
            }

            return false;
        }
        private void ShowWindow()
        {
            this.Show();
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //_account = new Account(
            //    UsernameLabel.Text.ToString(),
            //    PasswordLabel.SecurePassword.ToString()
            //);

            // sql interogation 
            // if find then move to next Listing Window
            if (String.IsNullOrEmpty(UsernameLabel.Text.ToString() ?? PasswordLabel.ToString()))
            {
                MessageBox.Show("Fields can't be empty!");
            }
            else
            {
                if(Authenticate(UsernameLabel.Text.ToString(), PasswordLabel.ToString()))
                {
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.goBack=this.ShowWindow();
                    this.Hide();

                }
                string hashedPass = Utils.ComputeSha256Hash(PasswordLabel.Password);
                var user = (from u in Utils.context.Costumers
                            where (u.login_name.Equals(UsernameLabel.Text) || u.email.Equals(UsernameLabel.Text)) && u.login_password.Equals(hashedPass)
                            select u).FirstOrDefault();
                if (user != null)
                {
                    ListItem items = new ListItem();
                    items.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User/Password wrong! Please try again.");
                }
            }
            
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CreateAccount createAccountView = new CreateAccount();
            createAccountView.Show();
            this.Hide();
        }
    }
}
