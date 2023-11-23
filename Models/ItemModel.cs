using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using CSharpest.Classes;

namespace CSharpest.Models;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 11/20/23

public class ItemModel : IComparable<ItemModel>
{

    // fields
    public Guid Id { get; set; } // primary key
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Bundle? bundle { get; set; }

    // for a new item being added to database
    public ItemModel(string name, string description, decimal price, int stock, Bundle? _bundle)
    {
        Name = name;
        Description = description;
        Id = Guid.NewGuid();
        Price = price;
        Stock = stock;
        bundle = _bundle;
    }

    public ItemModel() { }

    // comparison method to allow Item to be included in SortedSet
    public int CompareTo(ItemModel otherItem)
    {
        // checks if other item is null or not
        if (otherItem != null)
        {
            return this.Id.CompareTo(otherItem.Id); // compares by price
        }
        // if null or otherwise, return 
        return 1;
    }
}
