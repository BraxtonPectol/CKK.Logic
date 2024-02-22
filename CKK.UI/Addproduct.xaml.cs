using CKK.Logic.Models;
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
using CKK.UI;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for Addproduct.xaml
    /// </summary>
    public partial class Addproduct : Window
    {
        public Addproduct()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Name = Name.Text;
            product.Price = Convert.ToDecimal(Price.Text);
            product.Id = Convert.ToInt32(Id.Text);
            StoreItem item = new StoreItem(product, Convert.ToInt32(Quantity.Text));
            //((InventoryDis)Application.Current.MainWindow).product = product;

            ((InventoryDis)Application.Current.MainWindow)._Items.Add(item);
            ((InventoryDis)Application.Current.MainWindow).bInventoryList.Items.Refresh();
            this.Close();
        }
    }
}
