using CKK.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using CKK.Logic.Models;

namespace CKK.DB.Repository
{
    public class OrderRepository<Order> : IOrderRepository<Order> where Order : class
    {
        private readonly IConnectionFactory _connectionFactory;
        public OrderRepository(IConnectionFactory Conn)
        {
            _connectionFactory = Conn;
        }
        public int Add(Order entity)
        {
            var sql = "Insert into Orders (OrderNumber,CustomerId,ShoppingCartId) VALUES (@OrderNumber,@CustomerId,@ShoppingCartId)";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }

        public int Delete(int id)
        {
            var sql = "DELETE FROM Orders WHERE OrderId = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                connection.Execute(sql, new { Id = id });
                return 0;
            }
        }

        public Order GetById(int id)
        {
            var sql = "SELECT * FROM Orders WHERE OrderId = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault<Order>(sql, new { Id = id });
                return result;
            }
        }

        public List<Order> GetAll()
        {
            var sql = "SELECT * FROM Orders";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Query<Order>(sql).ToList();
                return result;
            }
        }

        public Order GetOrderByCustomerId(int id)
        {
            var sql = "SELECT * FROM Orders WHERE CustomerId = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault<Order>(sql, new { Id = id });
                return result;
            }
        }

        public int Update(Order entity)
        {
            var sql = "UPDATE Orders SET OrderId = @OrderId ,CustomerId = @CustomerId, ShoppingCartId = @ShoppingCartId WHERE OrderId = @OrderId";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }
    }
}
