using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace CSharpest.Classes
{
    public class InventoryLoader
    {
        private readonly string _filepath;

        public InventoryLoader(string filepath) {
            _filepath = filepath;
        }


        public SortedSet<Item> loadInventory()
        {
            SortedSet<Item> storeInventory = new SortedSet<Item>();


            using StreamReader reader = new StreamReader(_filepath);
            var json = reader.ReadToEnd();
            var jarray = JArray.Parse(json);

            foreach (var i in jarray)
            {
                Item item = i.ToObject<Item>();
                storeInventory.Add(item);
            }
            //using StreamReader reader = new StreamReader(_filepath);
            //var json = reader.ReadToEnd();
            //List<Item> storeInventory = JsonSerializer.Deserialize<List<Item>>(json);
            //SortedSet<Item> storeInventory = JsonSerializer.Deserialize<SortedSet<Item>>(json);

            return storeInventory;
        }


    }
}
