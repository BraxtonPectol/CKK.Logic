using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Persistance.Inheritance;
using CKK.Persistance.Interfaces;
using System.Runtime.Serialization;
using System.IO.Enumeration;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Persistance.Models
{
    public class FileStore : IStore, ILoadable, ISavable
    {

        //public string filename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance" + Path.DirectorySeparatorChar + "StoreItems.dat";

        private int idCounter;

        public string filename = @"C:\Users\Braxx\Documents\Persistance\StoreItems.dat";
        public FileStore() 
        {
            CreatePath();
            items = new List<StoreItem>();
            
        }
        public List<StoreItem> items { get; set;}
        private void CreatePath()
        {
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(filename))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(filename);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(filename));

                //// Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }

        public List<StoreItem> GetStoreItems()
        {
            return items;
        }
        public void Save()
        {
            using (var writeStream = new FileStream(filename, FileMode.Open))
            {

                var formatter = new BinaryFormatter();
                formatter.Serialize(writeStream, items); 
                writeStream.Flush();
            }
        }
        public void Load() 
        {
            using (var writeStream = new FileStream(filename, FileMode.Open))
            {

                var formatter = new BinaryFormatter();
                formatter.Deserialize(writeStream);
                writeStream.Flush();
            }
        }
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
                Save();
                return items[0];
            }
            //checks if product is already in store
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Product.Id == prod.Id)
                {
                    items[i].Quantity = (items[i].Quantity + quantity);
                    Save();
                    return items[i];
                }
            }
            //adds product if not present in current stock
            items.Add(new StoreItem(prod, quantity));
            items.Last().Product.Id = idcheck;
            idcheck++;
            Save();
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
                    if (items[i].Quantity - quantity <= 0)
                    {
                        items[i].Quantity = (0);
                        Save();
                        return items[i];
                    }
                    items[i].Quantity = (items[i].Quantity - quantity);
                    Save();
                    return items[i];
                }
            }
            throw new ProductDoesNotExistException();
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
        public List<StoreItem> GetAllProductsByName(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }
            else
            {
                List<StoreItem> templist = new List<StoreItem>();
                char[] chars = key.ToCharArray();
                for (int i = 0; i < items.Count; i++)
                {
                    char[] lichars = items[i].Product.Name.ToCharArray();
                    if (chars[0] == lichars[0])
                    {
                        templist.Add(items[i]);
                    }
                }
                return templist;

            }
        }
        public List<StoreItem> GetAllProductsByQuantity(int key)
        {
            List<StoreItem> templist = new List<StoreItem>();
            foreach (var item in items)
            {
                if (item.Quantity == key)
                {
                    templist.Add(item);
                }
            }
            for (int i = 0; i < templist.Count - 1; i++)
            {
                for (int j = 0; j < templist.Count - 1; j++)
                {
                    int x = templist[j].Quantity;
                    int y = templist[j + 1].Quantity;
                    if (x < y)
                    {
                        StoreItem tempitem = templist[j];
                        templist[j] = templist[j + 1];
                        templist[j + 1] = tempitem;
                    }
                }
            }
            return templist;
        }
        public List<StoreItem> GetAllProductsByPrice(decimal key)
        {
            List<StoreItem> templist = new List<StoreItem>();
            foreach (var item in items)
            {
                if (item.Product.Price == key)
                {
                    templist.Add(item);
                }
            }
            for (int i = 0; i < templist.Count - 1; i++)
            {
                for (int j = 0; j < templist.Count - 1; j++)
                {
                    decimal x = templist[j].Product.Price;
                    decimal y = templist[j + 1].Product.Price;
                    if (x < y)
                    {
                        StoreItem tempitem = templist[j];
                        templist[j] = templist[j + 1];
                        templist[j + 1] = tempitem;
                    }
                }
            }
            return templist;
        }
    }
}
