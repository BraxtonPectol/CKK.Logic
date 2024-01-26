using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store : Entity, IStore
    {
        public Store()
        {
            items = new List<StoreItem>();
        }

        public List<StoreItem> items { get; set; }
        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            
            if (quantity <= 0)
            {
                throw new InventoryItemStockTooLowException();
                
            }
            int idcheck = 1;
            //checks if stock is empty
            if (items.Count == 0)
            {
                items.Add(new StoreItem(prod, quantity));
                items[0].Product.Id = idcheck;
                idcheck++;
                return items[0];
            }
            //checks if product is already in store
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Product.Id == prod.Id)
                {
                    items[i].Quantity = (items[i].Quantity + quantity);
                    return items[i];
                }
            }
            //adds product if not present in current stock
            items.Add(new StoreItem(prod, quantity));
            items.Last().Product.Id = idcheck;
            idcheck++;
            return items.Last();


        }
        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Product.Id == id)
                {
                    if(items[i].Quantity - quantity <= 0)
                    {
                        items[i].Quantity = (0);
                        return items[i];
                    }
                    items[i].Quantity = (items[i].Quantity - quantity);
                    return items[i];
                }
            }
            throw new ProductDoesNotExistException();
        }
        public List<StoreItem> GetStoreItems()
        {
            return items;
        }
        public StoreItem FindStoreItemById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }
            List<int> ids = items.Select(x => x.Product.Id).ToList();
            for (int i = 0; i < items.Count; i++)
            {
                if (ids[i] == id)
                {

                    return items[i];
                }
            }
            return null;
        }

        public void DeleteStoreItem(int id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Product.Id == id)
                {
                    items.RemoveAt(i);
                }
            }
            throw new ProductDoesNotExistException();
        }

    }
}
