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
        public Product product = new Product();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            product.Name = Name.Text;
            product.Price = Convert.ToDecimal(Price.Text);
            product.Quantity = Convert.ToInt32(Quantity.Text);
            this.DialogResult = true;
            //((InventoryDis)Application.Current.MainWindow).product = product;
            this.Close();
        }
    }
}
