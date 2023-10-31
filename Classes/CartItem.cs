using Microsoft.AspNetCore.Http.Features;

namespace CSharpest.Classes;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 10/31/23

//  Shopping cart for a user that holds items
public class CartItem
{
    public Item Item { get; set; }
    public int Quantity { get; set; }

    public decimal TotalPrice {  get; set; }


    // public TotalCartPrice;
    public CartItem(Item _item, int _quantity, decimal _totalPrice)
    {
        Item = _item;
        Quantity = _quantity;
        TotalPrice = _totalPrice;
    }

}
