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

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for InventoryDis.xaml
    /// </summary>
    public partial class InventoryDis : Window
    {
        private IStore _Store;
        public ObservableCollection<StoreItem> _Items { get; private set; }
        public InventoryDis(Store store)
        {
            _Store = store;
            InitializeComponent();
            _Items = new ObservableCollection<StoreItem>();
            bInventoryList.ItemsSource = _Items;
            RefreshList();
        }
        private void RefreshList()
        {
            _Items.Clear();
            foreach (StoreItem si in new ObservableCollection<StoreItem>(_Store.GetStoreItems())) 
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
            productWindow.Show();
            

        RefreshList();
        }

        
    }
}
