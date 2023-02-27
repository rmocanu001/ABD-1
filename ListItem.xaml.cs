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
        private List<int> quantity;
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
            quantity = new List<int>(); 
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

                //var productsList = Utils.context.Produse.Where(b => b.Denumire.Contains(findItem)).ToList();

                var productsList =
                        from u in Utils.context.Produse
                        join i in Utils.context.Inventar on u.IDProdus equals i.IDProdus
                        //join k in Utils.context.CategorieProduse on u.IDCategorie equals k.IDCategorie
                        where u.Denumire.Contains(findItem)
                        select new { u.Denumire, i.PretUnitar, i.Cantitate };


                Lista.ItemsSource = productsList.ToList();

                e.Handled = true;
            }
           
           
        }

        private void Lista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var currentRow = Lista.SelectedItem.ToString().Substring(13).Split(',');//e.GetPosition(this));

            var str = currentRow[0].ToString();

            if (Lista.SelectedItem != null)
            {
                Produse produs = (from u in Utils.context.Produse where (u.Denumire.Equals(str)) select u).ToList().First();
                ItemSelected itemSelected = new ItemSelected(ProduseList, produs,quantity);
                itemSelected.Show();

            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Cart cart = new Cart(ProduseList,quantity,_account);
            cart.Show();
        }
        private void Clear_fnc(object sender, RoutedEventArgs e)
        {
            this.ProduseList.Clear();
            this.quantity.Clear();
            //Lista.Items.Clear();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            goBack();
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage image = MessageBoxImage.Warning;
            MessageBox.Show("No bills yet", "Alert", button, image);
        }
    }
}
