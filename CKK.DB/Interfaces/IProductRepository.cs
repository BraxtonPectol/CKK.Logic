using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetByName(string name);
        List<Product> GetByPrice(double price);
        List<Product> GetByQuantity(int quantity);
        List<Product> GetAll();
        Product GetById(int id);
        int Add(Product entity);
        int Delete(int id);
        public int Update(Product entity);
    }
}
