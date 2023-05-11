using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    internal class Product
    {
        private int Id;
        private string Name;
        private decimal Price;
        public void SetId(int id)
        {
            Id = id;
        }
        public int GetId()
        {
            return Id;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public string GetName()
        {
            return Name;
        }
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



