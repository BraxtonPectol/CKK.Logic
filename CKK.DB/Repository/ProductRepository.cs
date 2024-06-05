using CKK.DB.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CKK.DB.Repository
{
    public class ProductRepository<Product> : IProductRepository<Product> where Product : class
    {
        private readonly IConnectionFactory _connectionFactory;

        public ProductRepository(IConnectionFactory Conn) 
        {
            _connectionFactory = Conn;
        }
        
        public int Add(Product entity)
        {
            var sql = "Insert into Products (Price,Quantity,Name) VALUES (@Price,@Quantity,@Name)";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }

        public int Delete(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                connection.Execute(sql, new { Id = id });
                return 0;
            }
        }
        public Product GetById(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault<Product>(sql, new {Id = id});
                return result;
            }
        }

        public List<Product> GetAll()
        {
            var sql = "SELECT * FROM Products";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Query<Product>(sql).ToList();
                return result;
            }
        }

        public List<Product> GetByName(string name)
        {
            var sql = "SELECT * FROM Products WHERE Name = @Name";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Query<Product>(sql, new { Name = name }).ToList();
                return result;
            }
        }

        public int Update(Product entity)
        {
            var sql = "UPDATE Products SET Price = @Price ,Quantity = @Quantity, Name = @Name WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }

        internal object GetByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
