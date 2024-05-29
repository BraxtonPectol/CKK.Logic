using CKK.DB.Interfaces;
using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public int Add(ShoppingCartItem entity)
        {
            throw new NotImplementedException();
        }

        public ShoppingCartItem AddToCart(int ShoppingCardId, int ProductId, int quantity)
        {
            throw new NotImplementedException();
        }

        public int ClearCart(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotal(int ShoppingCartId)
        {
            throw new NotImplementedException();
        }

        public void Ordered(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public int Update(ShoppingCartItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
