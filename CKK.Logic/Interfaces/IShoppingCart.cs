using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    
    //interface for shoppingCart
    public interface IShoppingCart
    {
        public Customer Customer { get; set; }
        public List<ShoppingCartItem> Products { get; set; }

        
        public int GetCutomerId()
        {
            return Customer.Id;
        }
        public ShoppingCartItem GetProductById(int id)
        {
            List<int> SampleData = Products.Select(x => x.Product.Id).ToList();
            for (int i = 0; i < SampleData.Count; i++)
            {
                if (SampleData[i] == id)
                {
                    return Products[i];
                }
            }
            return null;
        }
       
        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }
    }
}
