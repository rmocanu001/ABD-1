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
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        List<Produse> produses;
        List<int> quantity;
        decimal total;
        Costumer costumer;
        public Cart(List<Produse> produses,List<int>qua, Costumer c)
        {
            InitializeComponent();
            this.produses = produses;
            total=0;
            costumer=c;
            this.quantity = qua;
            var productsList =from u in produses
                              select new { DenumireProdus = u.Denumire, DescriereProdus = u.DescriereProdus};
            CartGrid.ItemsSource = productsList;
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if (produses.Count!=0)
            {
                var prices = (from u in produses
                              join k in Utils.context.Inventar on u.IDProdus equals k.IDProdus
                              select k.PretUnitar).ToList();
                for (int i = 0; i < produses.Count; i++)
                {
                    total+=quantity[i]*prices[i];
                }
                if (CodeTxt.Text.Equals("CODE10"))
                {
                    add_order();
                    MessageBox.Show($"Comanda plasata cu valoarea: {total-total*10/100} si reducerea de 10%");
                    this.Hide();
                    return;
                }
                if (CodeTxt.Text.Equals("CODE20"))
                {
                    add_order();
                    MessageBox.Show($"Comanda plasata cu valoarea: {total-total*20/100} si reducerea de 20%");
                    this.Hide();
                    return;
                }
                add_order();
                MessageBox.Show($"Comanda plasata cu valoarea: {total}");
                    this.Hide();
                return;
            }
            else
            {
                MessageBox.Show($"Nu aveti ce comanda");
                    this.Hide();
                return;
            }
        }

        private void add_order()
        {
            int i = 0;
            foreach (var pr in produses) {

                Order ord = new Order
                {
                    IDCostumer=costumer.IDCostumer,
                    IDProdus=pr.IDProdus,
                    Order_quantity=quantity[i],
                    DataPlasareComanda=DateTime.Now,
                };

                inventarUpdate(quantity[i], pr);
                i++;
                Utils.context.Order.Add(ord);
                
            }
            Utils.context.SaveChanges();
        }
        private void inventarUpdate(int cantitate, Produse pr)
        {
            var inv = Utils.context.Inventar.SingleOrDefault(b => b.IDProdus == pr.IDProdus);
            if (inv!=null)
            {
                inv.Cantitate-=cantitate;
                Utils.context.SaveChanges();
            }
        }

        public static void CreatePdfUsingDocumentBuilder()
        {
           
        }
    }
}
