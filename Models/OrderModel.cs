using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CSharpest.Models;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 11/22/23

public class OrderModel : IComparable<OrderModel>
{
    public Guid Id { get; set; } // primary key: orderDetailId
    public Guid UserId { get; set; }
    public long CardId { get; set; } // card number, fk
    public string DateTime {  get; set; }
    public string Address { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal TotalCost { get; set; }


    public OrderModel(CustomerModel user, CardModel card, string datetime, string address, decimal shipping)
    {
        Id = Guid.NewGuid();
        UserId = user.Id;
        CardId = card.Number;
        DateTime = datetime;
        Address = address;
        ShippingCost = shipping;

        // loop through all the OrderDetails corresponding to this order
        // and add the shipping cost to that sum to get TotalCost. Idk how to though
        TotalCost = 0;
    }

    public OrderModel() { }

    // comparison method to allow item to be included in SortedSet
    public int CompareTo(OrderModel other)
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
