using Microsoft.AspNetCore.Http.Features;

namespace CSharpest.Classes;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/30/23

//  Shopping cart for a user that holds items
public class Cart
{
    //Is the same as its User's AccountID
    public Guid CartID { get; set; }

    //Used to allow serialization to JSON
    //Changed b/c JSON Serializer would not accept Item as Dictionary key
    public List<CartItem>? Items { get; set; }

    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal Taxes { get; set;}
    public decimal Total { get; set; }
    
    public Cart()
    {
        Items = new List<CartItem>();
        Subtotal = 0;
        Discount = 0;
        Taxes = 0;
        Total = 0;
    }

    
}
