using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Persistance.Inheritance;
using CKK.Persistance.Interfaces;

namespace CKK.Persistance.Models
{
    public class FileStore : IStore, ILoadable, ISavable
    {
        BinaryFormatter bf = new BinaryFormatter();
        public string filename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance" + Path.DirectorySeparatorChar + "StoreItems.dat";
        public FileStore() 
        {
            CreatePath();
        }
        public void CreatePath()
        {
            
        }
        public void Save()
        {
            bf();
        }
    }
}
