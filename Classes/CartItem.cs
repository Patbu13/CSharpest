using Microsoft.AspNetCore.Http.Features;

namespace CSharpest.Classes;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 10/31/23

//  Shopping cart for a user that holds items
public class CartItem
{
    public Item item { get; set; }
    public int Quantity { get; set; }


    // public TotalCartPrice;
    public CartItem(Item my_item, int quantity)
    {
        item = my_item;
        Quantity = quantity;
    }


}
