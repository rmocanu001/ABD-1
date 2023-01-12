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
    /// Interaction logic for ListItem.xaml
    /// </summary>
    public partial class ListItem : Window
    {
        private Costumer _account;
        // private Account _account;
        public Action goBack;
        public string ClientName { get ; set; }
        public ListItem(Costumer account)
        {   
            //_account = account;
            InitializeComponent();
            this.DataContext = this;
            _account = account;
            ClientName = _account.login_name;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EnterClick(object sender, KeyEventArgs e)
        {   
            if(e.Key == Key.Enter)
            {
                MessageBox.Show("EOK");
                string findItem = Searchitem.Text.ToString();

                // sql interogation
                var productsList = Utils.context.Produses.ToList().Where(b => b.Denumire == findItem);

                Lista.ItemsSource = productsList;

                e.Handled = true;
            }
           
        }
    }
}
