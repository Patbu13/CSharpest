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
        Items = new Dictionary<Item, int>();
    }

    // Add an item to the cart
    public void AddItem(Item item, int quantity)
    { 

        if (item != null && quantity > 0 && item.Stock >= quantity)
        {

            if (Items.ContainsKey(item))
            {
                Items[item] += quantity;
            }
            else
            {
                Items.Add(item, quantity);
            }
        }
    }

    // Remove an item from the cart
    public void RemoveItem(Item item, int quantity)
    {
        if (item != null && quantity > 0)
        {

            if (Items.ContainsKey(item))
            {
                int currentQuantity = Items[item];
                if (currentQuantity > quantity)
                {
                    Items[item] -= quantity;
                }
                else
                {
                    Items.Remove(item);
                }
            }
        }
    }
}
