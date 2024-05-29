using CKK.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Repository
{
    public class OrderRepository<Order> : IOrderRepository<Order> where Order : class
    {
        public int Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
