using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer Customer;
        private ShoppingCartItem Product1;
        private ShoppingCartItem Product2;
        private ShoppingCartItem Product3;

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
        }
        public int GetCutomerid()
        {
            return Customer.GetId();
        }
        public ShoppingCartItem GetProductByld(int id)
        {
            if (id == 1)
            {
                return Product1;
            }
            if (id == 2)
            {
                return Product2;
            }
            if (id == 3)
            {
                return Product3;
            }
            else
            {
                return null;
            }
        }
        public ShoppingCartItem AddProduct(Product prod)
        {
            AddProduct(prod, 1);
        }
        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity >= 1) 
            {
                if (Product1.GetProduct == prod.GetName)
                {
                    Product1.SetQuantity(quantity + (Product1.GetQuantity));
                }
            }
        }
    }
}
