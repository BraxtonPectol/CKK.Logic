using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    public interface IOrderRepository<Order> : IGenericRepository<Order> where Order : class
    {
        Order GetOrderByCustomerId(int id);
    }
}
