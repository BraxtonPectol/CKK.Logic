using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic
{
    internal class StoreItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public StoreItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
