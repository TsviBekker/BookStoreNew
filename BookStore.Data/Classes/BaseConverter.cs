using BookStore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BookStore.Data.Classes
{
    public class BaseConverter : JsonConverter
    {
        //This class allows the serializer to convert from ProductBase which is the default option
        //for storing items to a Book/Journal/Whatever
        //The convertion is determined by the ObjectType property of the products base
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings()
        {
            ContractResolver = new BaseSpecifiedConcreteClassConverter()
        };

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ProductBase);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            switch (jo["ObjectType"].Value<int>())
            {
                case 1:
                    return JsonConvert.DeserializeObject<Book>(jo.ToString(), SpecifiedSubclassConversion);
                case 2:
                    return JsonConvert.DeserializeObject<Journal>(jo.ToString(), SpecifiedSubclassConversion);
                default:
                    throw new Exception();
            }
            throw new NotImplementedException();
        }
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException(); // won't be called because CanWrite returns false
        }
    }
}
