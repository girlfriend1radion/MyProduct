using MyProduct.Components;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyProduct.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void listProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listProduct_Loaded(object sender, RoutedEventArgs e)
        {
            listProduct.ItemsSource = DBConnect.db.Product.ToList();
        }

        private void NameDisSearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            IEnumerable<Product> FilterproductPages = DBConnect.db.Product;
            if (SortCb.SelectedIndex > 0)
            {
                if (SortCb.SelectedIndex == 1)
                    FilterproductPages = FilterproductPages.OrderBy(x => x.Cost);
                else
                    FilterproductPages = FilterproductPages.OrderByDescending(x => x.Cost);
            }
            if (NameDisSearchTb.Text.Length > 0)
                FilterproductPages = FilterproductPages.Where(x => x.Name.ToLower().Contains(NameDisSearchTb.Text.ToLower()));

          //  MenuPage. = FilterproductPages.ToList();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
