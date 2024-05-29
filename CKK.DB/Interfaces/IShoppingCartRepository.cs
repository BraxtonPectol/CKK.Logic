using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCartItem AddToCart(int ShoppingCardId, int ProductId, int quantity);
        int ClearCart(int shoppingCartId);
        decimal GetTotal(int ShoppingCartId);
        List<ShoppingCartItem> GetProducts(int shoppingCartId);
        void Ordered(int shoppingCartId);
        int Update(ShoppingCartItem entity);
        int Add(ShoppingCartItem entity);
    }
}
