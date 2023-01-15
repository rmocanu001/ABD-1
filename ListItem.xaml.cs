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

        private List<Produse> ProduseList;
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
            ProduseList = new List<Produse>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        

        private void EnterClick(object sender, KeyEventArgs e)
        {   
            if(e.Key == Key.Enter)
            {
                
                
                string findItem = SearchItem.Text.ToString();

                // sql interogation

                var productsList = Utils.context.Produse.Where(b => b.Denumire.Contains(findItem)).ToList();

                //var productsList =
                //        from u in Utils.context.Produse
                //        join i in Utils.context.Inventar on u.Inventars equals i
                //        where u.Denumire.Contains(findItem)
                //        select new { u.Denumire, u.CategorieProduse, };
                   
   
                Lista.ItemsSource = productsList.ToList();

                e.Handled = true;
            }
           
           
        }

        private void Lista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var currentRow = Lista.Items.IndexOf(Lista.SelectedItem);//e.GetPosition(this));

            if(Lista.SelectedItem != null)
            {
                Produse produs = (Produse)Lista.Items.GetItemAt(currentRow);
                ItemSelected itemSelected = new ItemSelected(ProduseList, produs);
                itemSelected.Show();

            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Cart cart = new Cart(ProduseList);
            cart.Show();

        }
    }
}
