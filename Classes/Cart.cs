namespace CSharpest.Classes;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/12/23

//  Shopping cart for a user that holds items
public class Cart
{
    public int CartID { get; set; }
    public Dictionary<Item, int>? Items { get; set; }
    public Cart(int cartID)
    {
        CartID = cartID;
    }
}
