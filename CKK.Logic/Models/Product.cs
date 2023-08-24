using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Product : Entity
    {

        private decimal price;
        public decimal Price { get { return price; } set { if (value < 0) { throw new ArgumentOutOfRangeException(); }price = value ; } }
        
        public decimal GetPrice()
        {
            return Price;
        }

    }
}



