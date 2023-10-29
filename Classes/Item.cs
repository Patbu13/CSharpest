using System.Text.Json.Serialization;

namespace CSharpest.Classes;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 10/10/23
public class Item : IComparable<Item>
{

    // fields
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid ItemId { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }


    // for a new item being added to database
    public Item(string name, string description, decimal price, int stock)
    {
        Name = name;
        Description = description;
        ItemId = Guid.NewGuid();
        Price = price;
        Stock = stock;
    }

    // for an already existing item being read from database
    [JsonConstructor]
    public Item(string name, string description, Guid itemId, decimal price, int stock)
    {
        Name = name;
        Description = description;
        ItemId = itemId;
        Price = price;
        Stock = stock;
    }

    public Item() { }

    // comparison method to allow Item to be included in SortedSet
    public int CompareTo(Item otherItem)
    {
        // checks if other item is null or not
        if (otherItem != null)
        {
            return this.Price.CompareTo(otherItem.Price); // compares by price
        }
        // if null or otherwise, return 
        return 1;
    }
}
