using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CSharpest.Models;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 11/20/23

public class CartModel : IComparable<CartModel>
{
    public Guid Id { get; set; } // primary key: cartId
    public Guid userId { get; set; }

    public CartModel(CustomerModel user)
    {
        Id = user.CartId;
        userId = user.Id;
    }

    public CartModel() { }

    // comparison method to allow Item to be included in SortedSet
    public int CompareTo(CartModel other)
    {
        // checks if other item is null or not
        if (other != null)
        {
            return this.Id.CompareTo(other.Id); // compares by id
        }
        // if null or otherwise, return 
        return 1;
    }
}
