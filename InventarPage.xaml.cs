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
using System.Xml.Serialization;

namespace MagazinElectronic
{
    /// <summary>
    /// Interaction logic for Inventar.xaml
    /// </summary>
    public partial class InventarPage : Window
    {
        public Action goBack;

        public InventarPage()
        {
            InitializeComponent();
            loadCB();
        }

        private void loadCB()
        {
            var cat_name = (from u in Utils.context.CategorieProduse
                            select new { u.Denumire , u.IDCategorie}).ToList();
            
            foreach (var item in cat_name)
            {
                CatBox.Items.Add(item.Denumire);
            }
        }



        private void checkIfInserted()
        {
            var id_Pr = (from u in Utils.context.Produse
                          where (u.Denumire.Equals(ProdBox.SelectedItem.ToString()))
                          select u.IDProdus).FirstOrDefault();
            var prod_name = (from u in Utils.context.Inventar where(u.IDProdus.Equals(id_Pr))
                             select u.IDProdus).FirstOrDefault();
            if (prod_name==0)
            {
                Inventar inv = new Inventar
                {
                    IDProdus=id_Pr,
                    Cantitate=Int32.Parse(CantitateText.Text.ToString()),
                    PretUnitar=Int32.Parse(PretText.Text.ToString())
                };
                Utils.context.Inventar.Add(inv);
                Utils.context.SaveChanges();
            }
            else
            {
                var inv = Utils.context.Inventar.SingleOrDefault(b => b.IDProdus == prod_name);
                if (inv!=null)
                {
                    inv.Cantitate=Int32.Parse(CantitateText.Text.ToString());
                    inv.PretUnitar=Int32.Parse(PretText.Text.ToString());
                    Utils.context.SaveChanges();
                }
            }
        }


        private void Insert_button_Click(object sender, RoutedEventArgs e)
        {
            checkIfInserted();
        }

        private void CatBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id_cat = (from u in Utils.context.CategorieProduse
                          where (u.Denumire.Equals(CatBox.SelectedItem.ToString()))
                          select u.IDCategorie).FirstOrDefault();

            var prod_name = (from u in Utils.context.Produse where(u.IDCategorie.Equals(id_cat))
                            select u.Denumire).ToList();

            ProdBox.Items.Clear();
            foreach (var item in prod_name)
            {
                ProdBox.Items.Add(item);
            }
        }
    }
}
