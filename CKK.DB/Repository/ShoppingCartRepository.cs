using CKK.DB.Interfaces;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ShoppingCartRepository(IConnectionFactory Conn)
        {
            _connectionFactory = Conn;
        }
        public int Add(ShoppingCartItem entity)
        {
            var sql = "Insert into ShoppingCartItems (ShoppincCardId,ProductId,Quantity) VALUES (@ShoppincCardId,@ProductId, @Quantity)";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }

        public ShoppingCartItem AddToCart(int ShoppingCardId, int ProductId, int quantity)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                ProductRepository<Product> _productRepository = new ProductRepository<Product>(_connectionFactory);
                var item = _productRepository.GetById(ProductId);
                var ProductItems = GetProducts(ShoppingCardId).Find(x => x.ProductId == ProductId);

                var shopitem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCardId,
                    ProductId = ProductId,
                    Quantity = quantity
                };

                if (item.Quantity >= quantity)
                {
                    if (ProductItems != null)
                    {
                        //Product already in cart so update quantity
                        var test = Update(shopitem);
                    }
                    else
                    {
                        //New product for the cart so add it
                        var test = AddAsync(shopitem);
                    }
                }
                return shopitem;
            }
        }
    public int Update(ShoppingCartItem entity)
        {
            var sql = "UPDATE ShoppingCartItems SET ShoppingCartId = @ShoppingCartId, ProductId = @ProductId, Quantity = @Quantity WHERE ShoppingCartId = @ShoppingCartId AND ProductId = @ProductId";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }

        private object AddAsync(ShoppingCartItem shopitem)
        {
            var sql = "Insert into ShoppingCartItems (ShoppingCartId,ProductId,Quantity) VALUES (@ShoppingCartId, @ProductId, @Quantity)";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, shopitem);
                return result;
            }
        }

        private object UpdateAsync(ShoppingCartItem shopitem)
        {
            throw new NotImplementedException();
        }
        

        public int ClearCart(int shoppingCartId)
        {
            var sql = "DELETE * FROM ShoppingCartItems WHERE ShoppingCartId = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                connection.Execute(sql, new { Id = shoppingCartId });
                return 0;
            }
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            var sql = "SELECT * FROM ShoppingCartItems Where ShoppingCartId = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Query<ShoppingCartItem>(sql, new {Id = shoppingCartId}).ToList();
                return result;
            }
        }

        public decimal GetTotal(int ShoppingCartId)
        {
            var sql = "SELECT * FROM ShoppingCartItems Where ShoppingCartId = @Id";
            List<ShoppingCartItem> list = new List<ShoppingCartItem>();
            decimal result = 0;
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                list = connection.Query<ShoppingCartItem>(sql, new { Id = ShoppingCartId }).ToList();  
            }
            foreach(var item in list)
            {
                var q = "SELECT Price FROM Products Where ProductId = @Id";
                using (var connection = _connectionFactory.GetConnection)
                {
                    connection.Open();
                    List<Product> x = connection.Query<Product>(q, new { Id = item.ProductId }).ToList();
                    result += item.GetTotal(x[0].Price);
                }
                
            }
            return result;
        }

        public void Ordered(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        
    }
}
