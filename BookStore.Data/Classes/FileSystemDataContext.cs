using BookStore.Data.Classes;
using BookStore.Data.Interfaces;
using BookStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookStore.Data
{
    //This class enables a serialization from external files
    public class FileSystemDataContext : IRepository<ProductBase>
    {
        //Singleton
        private static FileSystemDataContext instance;
        public static FileSystemDataContext Instance
        {
            get
            {
                if (instance == null)
                    instance = new FileSystemDataContext();
                return instance;
            }
        }
        public string FilePath { get; private set; }
        string folderPath;
        private List<ProductBase> products;
        //Ctor
        public FileSystemDataContext()
        {
            //folderPath = @"C:\Users\Tsviki\OneDrive\שולחן העבודה\BookStore";
            folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            FilePath = $"{folderPath}//products.json";
            Init();
        }
        //deserialize
        public void Init()
        {
            //if file doesnt exits or is empty just create a new list
            if (File.Exists(FilePath) == false || File.ReadAllText(FilePath) == "")
            {
                products = new List<ProductBase>();
                return;
            }
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {//settings for serialization
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
            };
            settings.Converters.Add(new BaseConverter()); //this is very important
            //deserialize
            using (FileStream streamFile = File.Open(FilePath, FileMode.OpenOrCreate))
            using (StreamReader reader = new StreamReader(streamFile))
            {
                string fileContent = reader.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<ProductBase>>(fileContent, settings);
            }
        }
        //serialize
        public void Dispose()
        {
            File.Delete(FilePath);
            JsonSerializer jsonSerializer = new JsonSerializer { Formatting = Formatting.Indented };
            using (FileStream streamFile = File.Open(FilePath, FileMode.OpenOrCreate))
            using (StreamWriter writer = new StreamWriter(streamFile))
            using (JsonWriter jsonWriter = new JsonTextWriter(writer))
            {
                jsonSerializer.Serialize(jsonWriter, products, typeof(ProductBase));
            }
        }
        public bool Delete(Guid id) => products.Remove(Get(id));
        public ProductBase Get(Guid id) => products.FirstOrDefault(p => p.Id == id);
        public IEnumerable<ProductBase> Get(Predicate<ProductBase> filter = null)
        {
            if (filter == null) return products;
            return products.Where(p => filter.Invoke(p));
        }
        public Guid Insert(ProductBase item)
        {
            products.Add(item);
            return item.Id;
        }
        public ProductBase Update(ProductBase item)
        {
            Delete(item.Id);
            Insert(item);
            return item;
        }
    }
}
