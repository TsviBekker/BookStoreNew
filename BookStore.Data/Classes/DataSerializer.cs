using BookStore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BookStore.Data
{
    public class DataSerializer
    {
        public void JsonSerialize(object data, string filePath)
        {
            using (FileStream streamFile = File.Open(filePath, FileMode.OpenOrCreate))
            {
                using (StreamWriter writer = new StreamWriter(streamFile))
                {
                    string fileContent = JsonConvert.SerializeObject(data, Formatting.Indented);
                    writer.Write(fileContent);
                }
            }
        }

        public object JsonDeserialize(Type dataType, string filePath)
        {
            object obj = null;
            var type = dataType.GetType();
            using (FileStream streamFile = File.Open(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(streamFile))
                {
                    string jsonString = reader.ReadToEnd();
                    obj = JsonConvert.DeserializeObject(jsonString)/*as JObject*/;
                    //products = JsonConvert.DeserializeObject<List<ProductBase>>(fileContent);
                }
            }
            return obj;
        }
        public void XmlSerialize(Type dataType, object data, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(dataType);
            if (File.Exists(filePath))
                File.Delete(filePath);
            TextWriter textWriter = new StreamWriter(filePath);
            xmlSerializer.Serialize(textWriter, data);
            textWriter.Close();
        }

        public object XmlDeserialize(Type dataType, string filePath)
        {
            object obj = null;
            XmlSerializer xmlSerializer = new XmlSerializer(dataType);
            if (File.Exists(filePath))
            {
                TextReader textReader = new StreamReader(filePath);
                obj = xmlSerializer.Deserialize(textReader);
                textReader.Close();
            }
            return obj;
        }
    }
}
