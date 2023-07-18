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
        private List<ShoppingCartItem> Products = new List<ShoppingCartItem>();

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
        }
        public int GetCutomerid()
        {
            return Customer.GetId();
        }
        public ShoppingCartItem GetProductById(int id)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].GetProduct().GetId() == id)
                {
                    return Products[i];
                }
            }
            return null;
        }
        public ShoppingCartItem AddProduct(Product prod)
        {
            return AddProduct(prod, 1);

        }
        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            //checks if stock is empty
            if (Products.Count == 0)
            {
                Products.Add(new ShoppingCartItem(prod, quantity));
                return Products[0];
            }
            //checks if product is already in store
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].GetProduct().GetId() == prod.GetId())
                {
                    Products[i].SetQuantity(quantity);
                    return Products[i];
                }
            }
            //adds product if not present in current stock
            Products.Add(new ShoppingCartItem(prod, quantity));
            return Products[0];
        }
        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if (quantity > 0)
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i].GetProduct().GetId() == id)
                    {
                        Products[i].SetQuantity(--quantity);
                    }
                }

                return null;

            }
            return null;
        }
        public decimal GetTotal()
        {
            decimal total = Products.Sum(x => x.GetProduct().GetPrice());
            return total;
        }
        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }

    }
}
