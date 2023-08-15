using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Customer : Entity
    {

        private string Address { get; set; }
       
        public void SetAddress(string address)
        {
            Address = address;
        }
        public string GetAddress()
        {
            return Address;
        }

    }
}
