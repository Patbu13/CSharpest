using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 10/28/23

namespace CSharpest.Classes
{
    public class InventoryLoader
    {
        private readonly string _filepath;

        public InventoryLoader(string filepath) {
            _filepath = filepath;
        }


        public List<Item> loadInventory()
        {
            List<Item> storeInventory = new List<Item>();


            using StreamReader reader = new StreamReader(_filepath);
            var json = reader.ReadToEnd();
            var jarray = JArray.Parse(json);

            foreach (var i in jarray)
            {
                Item item = i.ToObject<Item>();
                storeInventory.Add(item);
            }

            return storeInventory;
        }

        public SortedSet<Item> loadInventorySorted()
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

            return storeInventory;
        }



    }
}
