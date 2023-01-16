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

        List<int> quantity;
        


        public ItemSelected(List<Produse> produses,Produse produse,List<int> q)
        {
            InitializeComponent();
            MessageBox.Show(produse.Denumire);
            this.produses = produses;
            this.produs = produse;
            quantity = q;   

            f.Text = produs.Denumire.ToString();
            g.Text = produs.DescriereProdus.ToString();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var quant=Int32.Parse(CantitateTB.Text.ToString());
            if (quant!=0)
            {
                var qu= (from i in Utils.context.Inventar where (i.IDProdus.Equals(produs.IDProdus)) select i.Cantitate).FirstOrDefault();
                if (qu<quant)
                {
                    MessageBoxButton button = MessageBoxButton.OKCancel;
                    MessageBoxImage image = MessageBoxImage.Warning;
                    MessageBox.Show("Cantitate indisponibila verificati cantitatea", "Alert", button, image);
                    return;
                }
                produses.Add(produs);
                quantity.Add(quant);
                this.Hide();
            }
            else
            {
                MessageBoxButton button = MessageBoxButton.OKCancel;
                MessageBoxImage image = MessageBoxImage.Warning;
                MessageBox.Show("Alegeti cantitatea", "Alert", button, image);
                return;
            }
        }
    }
}
