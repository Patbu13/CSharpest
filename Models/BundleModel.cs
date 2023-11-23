using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CSharpest.Models;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 11/21/23

public class BundleModel : IComparable<BundleModel>
{

    // fields
    public Guid Id { get; set; } // primary key
    public string Name { get; set; }

    // for a new item being added to database
    public BundleModel(string name)
    {
        Id = Guid.NewGuid(); 
        Name = name;
    }

    public BundleModel() { }

    // comparison method to allow Item to be included in SortedSet
    public int CompareTo(BundleModel otherBundle)
    {
        // checks if other item is null or not
        if (otherBundle != null)
        {
            return this.Id.CompareTo(otherBundle.Id); // compares by bundle id
        }
        // if null or otherwise, return 
        return 1;
    }
}
