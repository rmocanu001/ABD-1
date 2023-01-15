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
    /// Interaction logic for ItemSelected.xaml
    /// </summary>
    public partial class ItemSelected : Window
    {
        List<Produse> produses;

        Produse produs;
        


        public ItemSelected(List<Produse> produses,Produse produse)
        {
            InitializeComponent();
            MessageBox.Show(produse.Denumire);
            this.produses = produses;
            this.produs = produse;

            f.Text = produs.Denumire.ToString();
            g.Text = produs.DescriereProdus.ToString();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            produses.Add(produs);
            this.Hide();
        }
    }
}
