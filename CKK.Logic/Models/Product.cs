using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    [Serializable]

    public class Product : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private decimal price;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}



