using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CSharpest.Models;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 11/22/23

public class OrderDetailModel : IComparable<OrderDetailModel>
{
    public Guid Id { get; set; } // primary key: orderDetailId
    public Guid OrderId { get; set; }
    public Guid ItemId { get; set; }
    public Guid BundleId { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }


    public OrderDetailModel(OrderModel order, ItemModel item, BundleModel bundle, int quantity, decimal subtotal)
    {
        Id = Guid.NewGuid();
        OrderId = order.Id;
        ItemId = item.Id;
        BundleId = bundle.Id;
        Quantity = quantity;
        Subtotal = subtotal; // leave this for now but this is where the bundle effect will be calculated.
    }

    public OrderDetailModel() { }

    // comparison method to allow item to be included in SortedSet
    public int CompareTo(OrderDetailModel other)
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
