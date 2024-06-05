using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Xaml;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.DB.Repository;
using CKK.DB.UOW;
using CKK.DB.Interfaces;

namespace CKK.UI
{
 //<summary>
 //Interaction logic for InventoryDis.xaml
 //</summary>
public partial class InventoryDis : Window
    {
        public IConnectionFactory conn = new DatabaseConnectionFactory();
        public UnitOfWork _Store;
        public ObservableCollection<Product> _Items { get; private set; }
        public InventoryDis()
        {
            //_Store = store;
            InitializeComponent();
            _Items = new ObservableCollection<Product>();
            bInventoryList.ItemsSource = _Items;
            _Store = new UnitOfWork(conn);

            RefreshList();
        }
        private void RefreshList()
        {
            _Items.Clear();
            foreach (Product si in new ObservableCollection<Product>(_Store.Products.GetAll()))
                _Items.Add(si);
        }


        private void AddNewProductBut_Click(object sender, RoutedEventArgs e)
        {
            //Product product = new Product();
            //product.Name = "Name";
            //product.Price = 1;
            //product.Id = 1;
            //int quan=1;

            Addproduct productWindow = new Addproduct();
            //productWindow.product 
            if (productWindow.ShowDialog() == true)
            {
                _Store.Products.Add(productWindow.product);
                RefreshList();
            }
        }

        private void SearchByName_KeyDown(object sender, KeyEventArgs e)
{
    if (e.Key == Key.Return)
    {
        _Items.Clear();
        List<Product> x = _Store.Products.GetByName(SearchByName.Text);
        foreach (Product si in x)
            _Items.Add(si);
    }

}

private void SearchId_KeyDown(object sender, KeyEventArgs e)
{
    if (e.Key == Key.Return)
    {
        _Items.Clear();
        Product x = _Store.Products.GetById(Convert.ToInt32(SearchByName.Text));
        _Items.Add(x);
    }
}

private void SearchByPrice_KeyDown(object sender, KeyEventArgs e)
{
    //if (e.Key == Key.Return)
    //{
    //    _Items.Clear();
    //    List<StoreItem> x = _Store.GetAllProductsByPrice(Convert.ToInt32(SearchByPrice.Text));
    //    foreach (StoreItem si in x)
    //        _Items.Add(si);
    //}
}

private void SearchByQuantity_KeyDown(object sender, KeyEventArgs e)
{
    //if (e.Key == Key.Return)
    //{
    //    _Items.Clear();
    //    List<Product> x = _Store.Products.Get(Convert.ToInt32(SearchByQuantity.Text));
    //    foreach (StoreItem si in x)
    //        _Items.Add(si);
    //}
}

private void Refresh_Click(object sender, RoutedEventArgs e)
{
    RefreshList();
}

private void RemoveProductBut_Click(object sender, RoutedEventArgs e)
{
    Removeproduct productWindow = new Removeproduct();
    //productWindow.product 
    if (productWindow.ShowDialog() == true)
    {
        _Store.Products.Delete(productWindow.id);
        RefreshList();
    }
}
    }
}
