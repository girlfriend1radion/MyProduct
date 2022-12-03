using Microsoft.Win32;
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
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        Product product;
        public AddProductPage()
        {
            InitializeComponent();
            TypeCb.ItemsSource = DBConnect.db.Unit.ToList();
            TypeCb.DisplayMemberPath = "ProductType_Name";
            //  MaterialCb.ItemsSource = DbConnect.Database.MaterialType.ToList();
            //  MaterialCb.DisplayMemberPath = "Id_material";
       //     product = _product;
            this.DataContext = product;
        }

        private void ExitCb_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            product.Id = (TypeCb.SelectedItem as Product).Id;
            //product. = (MaterialCb.SelectedItem as Material).Id_material;

            if (product.Id == 0)
            {
                DBConnect.db.Product.Add(product);
            }
            DBConnect.db.SaveChanges();
            MessageBox.Show("Успешно выполнено");
        }

        /* 
         private void AddImageBtn_Click(object sender, RoutedEventArgs e)
          {
              OpenFileDialog openFile = new OpenFileDialog()
              {
                  Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg" //только эти расширения
              };
              if (openFile.ShowDialog().GetValueOrDefault())
              {
                  product.Photo = File.ReadAllText(openFile.FileName); //считать байты
                  ServiceImage.Source = new BitmapImage(new Uri(openFile.FileName)); //URi объект как приобраз картинка
              }
          }
        */
    }
}
