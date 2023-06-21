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
        public ShoppingCartItem GetProductById(int id)
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
            return AddProduct(prod, 1);
        }
        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            //validate quantity
            if (quantity >= 1) 
            {
                //checks if product already exsist in shopping cart
                if (Product1.GetProduct() == prod)
                {
                    Product1.SetQuantity(quantity + (Product1.GetQuantity()));
                    return Product1;
                }
                if (Product2.GetProduct() == prod)
                {
                    Product2.SetQuantity(quantity + (Product2.GetQuantity()));
                    return Product2;
                }
                if (Product3.GetProduct() == prod)
                {
                    Product3.SetQuantity(quantity + (Product3.GetQuantity()));
                    return Product3;
                }
                //adds product to shoppingcart if spot is available
                else if (Product1 == null)
                {
                    Product1.SetProduct(prod);
                    Product1.SetQuantity(quantity);
                    return Product1;
                }
                else if (Product2 == null)
                {
                    Product2.SetProduct(prod);
                    Product2.SetQuantity(quantity);
                    return Product2;
                }
                else if (Product3 == null)
                {
                    Product3.SetProduct(prod);
                    Product3.SetQuantity(quantity);
                    return Product3;
                }
                else
                {
                    return null;
                }
            } 
            else
            {
                return null;
            }
        }
        public ShoppingCartItem RemoveProduct(Product Prod, int quantity)
        {
            if(quantity >= 1)
            {
                if(Product1.GetProduct() == Prod)
                {
                    Product1.SetQuantity(-quantity);
                    return Product1;
                }
                if (Product2.GetProduct() == Prod)
                {
                    Product2.SetQuantity(-quantity);
                    return Product2;
                }
                if (Product3.GetProduct() == Prod)
                {
                    Product3.SetQuantity(-quantity);
                    return Product3;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public decimal GetTotal()
        {
            return Product1.GetTotal() + Product2.GetTotal() + Product3.GetTotal();
        }
        public ShoppingCartItem GetProduct(int prodNum)
        {
            if(prodNum == 1)
            {
                return Product1;
            }
            if (prodNum == 2)
            {
                return Product2;
            }
            if (prodNum == 3)
            {
                return Product3;
            }
            else
            {
                return null;
            }
        }
    }
}
