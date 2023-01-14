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
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {

        public Action goBack;
        public AdminMenu()
        {
            InitializeComponent();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Hide();
            goBack();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            goBack();
        }
        private void Insert_Produse_Click(object sender, RoutedEventArgs e)
        {
            InsertProduse pr = new InsertProduse();
            pr.Show();
           // this.Hide();
        }
        private void Insert_Categorie_Click(object sender, RoutedEventArgs e)
        {
            InsertCategorie cat = new InsertCategorie();
            cat.Show();
            //this.Hide();
        }
        private void Administrare_inventar_Click(object sender, RoutedEventArgs e)
        {
            Inventar iv = new Inventar();
            iv.Show();
           // this.Hide();
        }
    }
}
