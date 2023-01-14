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
    /// Interaction logic for InsertCategorie.xaml
    /// </summary>
    public partial class InsertCategorie : Window
    {
        string categorie;
        public Action goBack;

        public InsertCategorie()
        {
            InitializeComponent();
        }

        private void Insert_button_Click(object sender, RoutedEventArgs e)
        {
            categorie=Tb_Categorie.Text.ToString();
            CategorieProduse cat = new CategorieProduse
            {
               Denumire = categorie,
            };
            Utils.context.CategorieProduse.Add(cat);
            Utils.context.SaveChanges();
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage image = MessageBoxImage.Warning;
            MessageBox.Show("Category inserted","Nice", button, image);

        }

        private void Tb_Categorie_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
