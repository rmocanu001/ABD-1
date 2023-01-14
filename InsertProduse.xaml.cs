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
    /// Interaction logic for InsertProduse.xaml
    /// </summary>
    public partial class InsertProduse : Window
    {
        public Action goBack;

        public InsertProduse()
        { 
            InitializeComponent();
            var cat_name = (from u in Utils.context.CategorieProduse
                            select u.Denumire).ToList();
            foreach (var item in cat_name)
            {
                CatBox.Items.Add(item);
            }
            
        }

        private void Insert_button_Click(object sender, RoutedEventArgs e)
        {
            var produse = from u in Utils.context.Produse
                          select u.Denumire;


            var id_cat = (from u in Utils.context.CategorieProduse
                          where (u.Denumire.Equals(CatBox.SelectedItem.ToString()))
                          select u.IDCategorie).FirstOrDefault();

            //string des = Tb_Descriere.Text.ToString();
            if (produse.ToList().Contains(Tb_Denumire.Text.ToString()))
            {
                MessageBox.Show("Product alredy inserted", "Nice", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                return;
            }
            Produse pr = new Produse
            {
                IDCategorie = id_cat,
                Denumire=Tb_Denumire.Text.ToString(),
                DescriereProdus=Tb_Descriere.Text.ToString()
            };
            Utils.context.Produse.Add(pr);
            Utils.context.SaveChanges();
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage image = MessageBoxImage.Warning;
            MessageBox.Show("Product inserted", "Nice", button, image);
        }

        
    }
}
