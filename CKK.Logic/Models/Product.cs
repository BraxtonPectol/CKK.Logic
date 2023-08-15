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
       
        public decimal Price { get; set; }
        
        public void SetPrice(decimal price)
        {
            Price = price;
        }
        public decimal GetPrice()
        {
            return Price;
        }

    }
}



