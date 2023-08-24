using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
    {
        
        
        public Customer Customer { get; set; }
        public List<ShoppingCartItem> Products { get; set; }

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
            Products = new List<ShoppingCartItem>();
        }
        public int GetCustomerId()
        {
            return Customer.Id;
        }
        //gpbid not returning null when expected to
        public ShoppingCartItem GetProductById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
                return null;
            }
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
        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            //checks validity of argument
            if(quantity <= 0)
            {
                throw new InventoryItemStockTooLowException();
            }
            
            //checks if stock is empty
            if (Products.Count == 0)
            {
                Products.Add(new ShoppingCartItem(prod, quantity));
                return Products[0];
            }
            //checks if product is already in store
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Product.Id == prod.Id)
                {
                    Products[i].Quantity = (Products[i].Quantity + quantity);
                    return Products[i];
                }
                
            }
            //adds product if not present in current stock
            Products.Add(new ShoppingCartItem(prod, quantity));
            return Products.Last();
        }
        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = 0; i < Products.Count; i++)
                {
                if (Products[i].Product.Id == id)
                {
                    
                    
                    if (Products[i].Quantity - quantity <= 0)
                    {
                        Products.Remove(Products[i]);
                        return new ShoppingCartItem(null, 0);
                    }
                    Products[i].Quantity = (Products[i].Quantity - quantity);
                    return Products[i];
                }
            }

                throw new ProductDoesNotExistException();

           
        }
        public decimal GetTotal()
        {
            decimal total = Products.Sum(x => x.GetTotal());
            return total;
        }
        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }

    }
}
