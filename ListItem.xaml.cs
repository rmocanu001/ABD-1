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

        // private Account _account;
        public Action goBack;

        public ListItem()
        {   
            //_account = account;
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string findItem = Searchitem.Text.ToString();

            // sql interogation 

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
