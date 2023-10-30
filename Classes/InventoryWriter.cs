using System.Collections.Generic;
using System.Net;
using System.Text.Json;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/30/23

namespace CSharpest.Classes
{
    public class InventoryWriter
    {
        private readonly string _filepath;

        public InventoryWriter(string filepath)
        {
            _filepath = filepath;
        }

        public void writeInventory(Item item)
        {
            InventoryLoader inventoryLoader = new InventoryLoader(_filepath);
            List<Item> currInventory = inventoryLoader.loadInventory();

            bool exists = currInventory.Contains(item);

            if (exists)
            {
                int index = currInventory.IndexOf(item);
                currInventory[index] = item;
            } else
            {
                currInventory.Add(item);
            }

            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };

            JsonSerializerOptions optionsCopy = new(options);
            string jsonString = JsonSerializer.Serialize(currInventory, optionsCopy);

            File.WriteAllText(_filepath, jsonString);
        }


    }
}
