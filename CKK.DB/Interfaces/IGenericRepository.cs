using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        int Add(T entity);
        int Update(T entity);
        int Delete(int id);
    }

}
