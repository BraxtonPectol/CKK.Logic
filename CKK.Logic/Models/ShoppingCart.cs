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
                //adds product to shoppingcart if spot is available
                if (Product1 == null)
                {
                    Product1 = new ShoppingCartItem(prod, quantity);

                    return Product1;
                }
                if (Product2 == null)
                {
                    Product2 = new ShoppingCartItem(prod, quantity);

                    return Product2;
                }
                if (Product3 == null)
                {
                    Product3 = new ShoppingCartItem(prod, quantity);

                    return Product3;
                }
                //checks if product already exsist in shopping cart
                if (Product1.GetProduct().GetId() == prod.GetId())
                {
                    Product1.SetQuantity(Product1.GetQuantity() + quantity);
                    return Product1;
                }
                if (Product2.GetProduct().GetId() == prod.GetId())
                {
                    Product2.SetQuantity(Product2.GetQuantity() + quantity);
                    return Product2;
                }
                if (Product3.GetProduct().GetId() == prod.GetId())
                {
                    Product3.SetQuantity(Product3.GetQuantity() + quantity);
                    return Product3;
                }
                
                
                
                    return null;
                
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
                if(Product1.GetProduct().GetId() == Prod.GetId())
                {
                    Product1.SetQuantity(Product1.GetQuantity() - quantity);
                    return Product1;
                }
                if (Product2.GetProduct().GetId() == Prod.GetId())
                {
                    Product2.SetQuantity(Product1.GetQuantity() - quantity);
                    return Product2;
                }
                if (Product3.GetProduct().GetId() == Prod.GetId())
                {
                    Product3.SetQuantity(Product1.GetQuantity() - quantity);
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
            return (Product1.GetTotal() + Product2.GetTotal() + Product3.GetTotal());
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
