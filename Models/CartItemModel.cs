using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CSharpest.Models;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 11/20/23

public class CartItemModel : IComparable<CartItemModel>
{
    public Guid Id { get; set; } // primary key: cartItemId
    public Guid CartId { get; set; } // foreign key
    public Guid ItemId { get; set; } // foreign key
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }


    public CartItemModel(ItemModel item, CartModel cart, int quantity, decimal totalPrice)
    {
        Id = Guid.NewGuid();
        ItemId = item.Id;
        CartId = cart.Id;
        Quantity = quantity;
        if (item.bundle != null)
        {
            if (item.bundle.Name == "bogo")
            {
                TotalPrice = totalPrice * 0.5m;
            }
        }
        TotalPrice = totalPrice;
    }

    public CartItemModel() { }

    // comparison method to allow Item to be included in SortedSet
    public int CompareTo(CartItemModel other)
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
