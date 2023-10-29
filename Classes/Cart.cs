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

    // Add an item to the cart
    public void AddItem(Item item, int quantity)
    { 

        if (item != null && quantity > 0 && item.Stock >= quantity)
        {

            if (Items.ContainsKey(item))
            {
                int currQuant = Items[item].Item1 + quantity;
                Items[item] = Tuple.Create(currQuant, currQuant * item.Price);
            }
            else
            {
                Items.Add(item, Tuple.Create(quantity, quantity*item.Price));
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
                int currQuant = Items[item].Item1;
                if (currQuant > quantity)
                {
                    currQuant -= quantity;
                    Items[item] = Tuple.Create(currQuant, currQuant * item.Price);
                }
                else
                {
                    Items.Remove(item);
                }
            }
        }
    }
}
