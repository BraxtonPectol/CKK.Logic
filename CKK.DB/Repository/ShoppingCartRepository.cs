using CKK.DB.Interfaces;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        
        //initialize connection
        public ShoppingCartRepository(IConnectionFactory Conn)
        {
            _connectionFactory = Conn;
        }
        
        //add a shopping cart item
        public int Add(ShoppingCartItem entity)
        {
            //create sql command
            var sql = "Insert into ShoppingCartItems (ShoppingCartId,ProductId,Quantity) VALUES (@ShoppingCartId, @ProductId, @Quantity)";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                var result = connection.Execute(sql, entity);
                return result;
            }
        }

        //update client cart information
        public ShoppingCartItem AddToCart(int ShoppingCartId, int ProductId, int quantity)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                //initialize product repository
                ProductRepository _productRepository = new ProductRepository(_connectionFactory);
                
                //create copy of selected product
                var item = _productRepository.GetById(ProductId);
                
                //get all current shoppingcart items
                var ProductItems = GetProducts(ShoppingCartId).Find(x => x.ProductId == ProductId);

                //create new shoppingcart Item
                var shopitem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    ProductId = ProductId,
                    Quantity = quantity
                };

                //test if product exsists in cart
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
                        var test = Add(shopitem);
                    }
                }
                return shopitem;
            }
        }
    
        //update a shoppingcart item
        public int Update(ShoppingCartItem entity)
        {
            //create sql command
            var sql = "UPDATE ShoppingCartItems SET ShoppingCartId = @ShoppingCartId, ProductId = @ProductId, Quantity = @Quantity WHERE ShoppingCartId = @ShoppingCartId AND ProductId = @ProductId";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                var result = connection.Execute(sql, entity);
                return result;
            }
        }
        
        //clear current shopping cart
        public int ClearCart(int shoppingCartId)
        {
            //create sql command
            var sql = "DELETE FROM ShoppingCartItems WHERE ShoppingCartId = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                connection.Execute(sql, new { Id = shoppingCartId });
                return 0;
            }
        }

        //get all items in a shopping cart
        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            //create sql command
            var sql = "SELECT * FROM ShoppingCartItems Where ShoppingCartId = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                var result = connection.Query<ShoppingCartItem>(sql, new {Id = shoppingCartId}).ToList();
                return result;
            }
        }

        //get price total of shopping cart
        public decimal GetTotal(int ShoppingCartId)
        {
            //create sql commands
            var sql = "SELECT * FROM ShoppingCartItems Where ShoppingCartId = @Id";
            var q = "SELECT * FROM Products WHERE Id = @Id";
            
            //initialize list for shoppingcart items
            List<ShoppingCartItem> list = new List<ShoppingCartItem>();
            
            //initialize result
            decimal result = 0;
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute first query
                list = connection.Query<ShoppingCartItem>(sql, new { Id = ShoppingCartId }).ToList();  
            }
            
            //iterate over each shopping cart item
            foreach(var item in list)
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    //open connection
                    connection.Open();
                    
                    //find product based on shopping cart item
                    List<Product> x = connection.Query<Product>(q, new { Id = item.ProductId }).ToList();
                    
                    //update total with product price
                    result += item.GetTotal(x[0].Price);
                }
                
            }
            return result;
        }

        //not implemented
        public void Ordered(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        
    }
}
