using CKK.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public abstract class Entity
    {
        public int Id { get { return Id; } set { if (value < 0) { throw new InvalidIdException(); } Id = value; } }
        public string name { get; set; }
    }
}
