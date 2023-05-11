using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    internal class StoreItem
    {
        private Product Product;
        private int Quantity;
        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
        public int GetQuantity()
        {
            return Quantity;
        }
        public void SetProduct(Product prodcut)
        {
            Product = prodcut;
        }
        public Product GetProduct()
        {
            return Product;
        }

        public StoreItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
