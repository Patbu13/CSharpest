using Microsoft.AspNetCore.Http.Features;

namespace CSharpest.Classes;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/12/23

//  Shopping cart for a user that holds items
public class Cart
{
    public Guid CartID { get; set; }
    //public Dictionary<Item, int>? Items { get; set; }
    public Dictionary<Item, Tuple<int, decimal>>? Items { get; set; }
    

    // public TotalCartPrice;
    public Cart()
    {
        Items = new Dictionary<Item, Tuple<int, decimal>>(); // new Dictionary<Item, int>();
    }

    
}
