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
    public class OrderRepository : IOrderRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        //initialize connection
        public OrderRepository(IConnectionFactory Conn)
        {
            _connectionFactory = Conn;
        }
        //add order
        public int Add(Order entity)
        {
            //create sql command
            var sql = "Insert into Orders ( OrderId,OrderNumber,CustomerId,ShoppingCartId) VALUES (@OrderId, @OrderNumber, @CustomerId, @ShoppingCartId)";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                var result = connection.Execute(sql, entity);
                return result;
            }
        }

        //delete an order
        public int Delete(int id)
        {
            //create sql command
            var sql = "DELETE FROM Orders WHERE OrderId = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                connection.Execute(sql, new { Id = id });
                return 0;
            }
        }

        //get an order by its Id
        public Order GetById(int id)
        {
            //create sql command
            var sql = "SELECT * FROM Orders WHERE OrderId = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                var result = connection.QuerySingleOrDefault<Order>(sql, new { Id = id });
                return result;
            }
        }

        //get a list of all order
        public List<Order> GetAll()
        {
            //create sql command
            var sql = "SELECT * FROM Orders";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                var result = connection.Query<Order>(sql).ToList();
                return result;
            }
        }

        //get an order by its id
        public Order GetOrderByCustomerId(int id)
        {
            //create sql command
            var sql = "SELECT * FROM Orders WHERE CustomerId = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                var result = connection.QuerySingleOrDefault<Order>(sql, new { Id = id });
                return result;
            }
        }

        //update an order
        public int Update(Order entity)
        {
            //create sql command
            var sql = "UPDATE Orders SET OrderId = @OrderId ,CustomerId = @CustomerId, ShoppingCartId = @ShoppingCartId WHERE OrderId = @OrderId";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                var result = connection.Execute(sql, entity);
                return result;
            }
        }
    }
}
