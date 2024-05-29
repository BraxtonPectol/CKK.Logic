using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
