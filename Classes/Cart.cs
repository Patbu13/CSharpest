namespace CSharpest.Classes;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/12/23

//  Shopping cart for a user that holds items
public class Cart
{
    public int CartID { get; set; }
    public Dictionary<CartItem, int>? Items { get; set; }
    public Cart(int cartID)
    {
        CartID = cartID;
        Items = new Dictionary<CartItem, int>();
    }

    // Add an item to the cart
    public void AddItem(Item item, int quantity)
    {
        if (item != null && quantity > 0)
        {
            CartItem cartItem = new CartItem { Item = item, Quantity = quantity };

            if (Items.ContainsKey(cartItem))
            {
                Items[cartItem] += quantity;
            }
            else
            {
                Items.Add(cartItem, quantity);
            }
        }
    }

    // Remove an item from the cart
    public void RemoveItem(Item item, int quantity)
    {
        if (item != null && quantity > 0)
        {
            CartItem cartItem = new CartItem { Item = item, Quantity = 0 };

            if (Items.ContainsKey(cartItem))
            {
                int currentQuantity = Items[cartItem];
                if (currentQuantity > quantity)
                {
                    Items[cartItem] -= quantity;
                }
                else
                {
                    Items.Remove(cartItem);
                }
            }
        }
    }
}
