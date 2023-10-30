using Microsoft.AspNetCore.Mvc;
using CSharpest.Classes;
using System.Collections.Generic;
using System.Collections;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/29/23
namespace CSharpest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        InventoryLoader inventoryLoader = new InventoryLoader(@".\data\inventory.json");
        UserLoader userLoader = new UserLoader(@".\data\users.json");
        // GET: api/<CartController>
        [HttpGet("GetCartItems")]
        public Dictionary<Item, Tuple<int, decimal>> GetCartItems(Guid UserID)
        {
            List<User> users = userLoader.loadUsers();
            User user = users.Find(x => x.AccountID == UserID);
            Cart newUser = user.Cart;
            Dictionary < Item, Tuple<int, decimal> > cartItems = user.Cart.Items;
            return cartItems;
        }


        [HttpPost("AddItemToCart")]
        public string AddItemToCart(AddItemReqParams itemParams)
        {
            List<Item> items = inventoryLoader.loadInventory();
            Item item = items.Find(x => x.ItemId == itemParams.ItemID); // get item from database using id

            List<User> users = userLoader.loadUsers();
            User user = users.Find(x => x.AccountID == itemParams.CartID); // get user from database using id

            if (item != null && user.Cart != null && itemParams.Quantity > 0 && item.Stock >= itemParams.Quantity)
            {

                if (user.Cart.Items.ContainsKey(item))
                {
                    int currQuant = user.Cart.Items[item].Item1 + itemParams.Quantity;
                    user.Cart.Items[item] = Tuple.Create(currQuant, currQuant * item.Price);
                }
                else
                {
                    user.Cart.Items.Add(item, Tuple.Create(itemParams.Quantity, itemParams.Quantity * item.Price));
                }
            }
            else
            {
                if (item == null) { return "Failure: Cannot add 'null' to cart."; }

                if (user.Cart == null) { return "Failure: Cart does not exist."; }

                if (itemParams.Quantity < 0) { return "Failure: Quantity must be positive."; }

                if (item.Stock < itemParams.Quantity) { return "Failure: Not enough in stock."; }
            }

            RedirectToAction("Cart");
         
            return "Success!";
        }

        [HttpPost("RemoveItemFromCart")]

        // Remove an item from the cart
        public void RemoveItem(RemoveItemReqParams itemParams)
        {
            //get cart from ID
            List<User> users = userLoader.loadUsers();
            User user = users.Find(x => x.AccountID == itemParams.CartID); // get user from database using id

            if (itemParams.Item != null && itemParams.Quantity > 0)
            {

                if (user.Cart.Items.ContainsKey(itemParams.Item))
                {
                    int currQuant = user.Cart.Items[itemParams.Item].Item1;
                    if (currQuant > itemParams.Quantity)
                    {
                        currQuant -= itemParams.Quantity;
                        user.Cart.Items[itemParams.Item] = Tuple.Create(currQuant, currQuant * itemParams.Item.Price);
                    }
                    else
                    {
                        user.Cart.Items.Remove(itemParams.Item);
                    }
                }
            }
        }
    }
}
