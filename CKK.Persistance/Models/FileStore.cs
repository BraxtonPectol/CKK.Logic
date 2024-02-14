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
        public string filename = @"C:\Users\Braxx\Documents\Persistance\StoreItems.dat";
        public List<StoreItem> items { get; set; }
        private int idCounter;

        
        public FileStore() 
        {
            CreatePath();
        }
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
    }
}
