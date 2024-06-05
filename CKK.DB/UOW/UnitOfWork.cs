using CKK.DB.Interfaces;
using CKK.DB.Repository;
using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IConnectionFactory Conn) 
        {
            Products = new ProductRepository<Product>(Conn);
            Orders = new OrderRepository<Order>(Conn);
            ShoppingCarts = new ShoppingCartRepository(Conn);
        }
        public IProductRepository<Product> Products { get; private set; }
        
        public IOrderRepository<Order> Orders { get; private set; }
        public IShoppingCartRepository ShoppingCarts { get; private set;}
    }
}
