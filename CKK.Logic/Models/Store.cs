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
        public int GetId() { return id; }
        private string name;
        public void SetName(string Name) { name = Name; }
        public string GetName() { return name; }

        private List<StoreItem> items = new List<StoreItem>();
        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            //checks if stock is empty
            if (items.Count == 0)
            {
                items.Add(new StoreItem(prod, quantity));
                return items[0];
            }
            //checks if product is already in store
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].GetProduct().GetId() == prod.GetId())
                {
                    items[i].SetQuantity(quantity);
                    return items[i];
                }
            }
            //adds product if not present in current stock
            items.Add(new StoreItem(prod, quantity));
            return items[0];


        }
        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].GetProduct().GetId() == id)
                {
                    items[i].SetQuantity(items[i].GetQuantity() - quantity);
                    return items[i];
                }
            }
            return null;
        }
        public List<StoreItem> GetStoreItems()
        {
            return items;
        }
        public StoreItem FindStoreItemById(int id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].GetProduct().GetId() == id)
                {

                    return items[i];
                }
            }
            return null;
        }

    }
}
