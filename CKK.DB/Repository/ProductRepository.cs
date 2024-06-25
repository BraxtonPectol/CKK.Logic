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
    public class ProductRepository : IProductRepository
        //public class ProductRepository<Product> : IProductRepository<Product> where Product : class
    {
        private readonly IConnectionFactory _connectionFactory;

        //initialize connection
        public ProductRepository(IConnectionFactory Conn) 
        {
            _connectionFactory = Conn;
        }
        
        //add a product
        public int Add(Product entity)
        {
            List<Product> products = GetByName(entity.Name);

            if (products == null)
            {
                //create sql command
                var sql = "Insert into Products (Price,Quantity,Name) VALUES (@Price,@Quantity,@Name)";
                using (var connection = _connectionFactory.GetConnection)
                {
                    //open connection
                    connection.Open();
                    //execute
                    var result = connection.Execute(sql, entity);
                    return result;
                }
            }
            else 
            {
                products[0].Quantity += entity.Quantity;
                Update(products[0]);
                return products[0].Quantity;
            }
        }

        //delete a product
        public int Delete(int id)
        {
            //create sql command
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                connection.Execute(sql, new { Id = id });
                return 0;
            }
        }
        
        //get a product by its id
        public Product GetById(int id)
        {
            //create sql command
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            using(var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                var result = connection.QuerySingleOrDefault<Product>(sql, new {Id = id});
                return result;
            }
        }

        //get a list of all products
        public List<Product> GetAll()
        {
            //create sql command
            var sql = "SELECT * FROM Products";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                var result = connection.Query<Product>(sql).ToList();
                return result;
            }
        }

        //get a list of products by name
        public List<Product> GetByName(string name)
        {
            //create sql command
            var sql = "SELECT * FROM Products WHERE Name = @Name";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                var result = connection.Query<Product>(sql, new { Name = name }).ToList();
                return result;
            }
        }

        //update a product
        public int Update(Product entity)
        {
            //create sql command
            var sql = "UPDATE Products SET Price = @Price ,Quantity = @Quantity, Name = @Name WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                var result = connection.Execute(sql, entity);
                return result;
            }
        }
        
        //get all products by price
        public List<Product> GetByPrice(double price)
        {
            //create sql command
            var sql = "SELECT * FROM Products WHERE Price = @Price";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //exectute
                var result = connection.Query<Product>(sql, new { Price = price }).ToList();
                return result;
            }
        }
        
        //get a list a products based on quantity
        public List<Product> GetByQuantity(int quantity)
        {
            //create sql command
            var sql = "SELECT * FROM Products WHERE Quantity = @Quantity";
            using (var connection = _connectionFactory.GetConnection)
            {
                //open connection
                connection.Open();
                //execute
                var result = connection.Query<Product>(sql, new { Quantity = quantity }).ToList();
                return result;
            }
        }

    }
}
