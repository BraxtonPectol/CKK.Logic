using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store
    {
        private int id;
        public void SetId(int Id) { id = Id; }
        public int Id { get { return id; } }
        private string name;
        public void setName(string Name) { name = Name; }
        public string Name { get { return name; } }
        public Product Product1;
        public Product Product2;
        public Product Product3;

        public void AddStoreItem(Product prod)
        {
            if (Product1 == null){ Product1 = prod; }
            else if (Product2 == null){ Product2 = prod; }
            else if (Product3 == null){ Product3 = prod; }
        }
        public void RemoveStoreItem(int productNum)
        {
            if (productNum == 1) { Product1 = null; }
            if (productNum == 2) { Product2 = null; }
            if (productNum == 3) { Product3 = null; }
        }
        public Product GetStoreItem(int productNumber)
        {
            if (productNumber == 1) { return Product1; }
            if (productNumber == 2) { return Product2; }
            if (productNumber == 3) { return Product3; }
            else { return null; }
        }
        public Product FindStoreItemByld(int id)
        {
            if (id == Product1.GetId()) { return Product1; }
            if (id == Product2.GetId()) {  return Product2; }
            if (id == Product3.GetId()) { return Product3; }
            else { return null; }
        }

    }
}
