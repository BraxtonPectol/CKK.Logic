using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Persistance.Inheritance
{
    public interface ISavable
    {
        
        public void Save()
        {
        }
    }
}
