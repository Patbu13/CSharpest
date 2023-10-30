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
            Dictionary < Item, Tuple<int, decimal> > cartItems = user.UserCart.Items;
            return cartItems;
        }


        [HttpPost("AddItemToCart")]
        public string AddItemToCart(Guid cartID, Guid itemID, int quantity)
        {
            List<Item> items = inventoryLoader.loadInventory();
            Item item = items.Find(x => x.ItemId == itemID); // get item from database using id

            List<User> users = userLoader.loadUsers();
            User user = users.Find(x => x.AccountID == cartID); // get user from database using id

            if (item != null && user.UserCart != null && quantity > 0 && item.Stock >= quantity)
            {

                if (user.UserCart.Items.ContainsKey(item))
                {
                    int currQuant = user.UserCart.Items[item].Item1 + quantity;
                    user.UserCart.Items[item] = Tuple.Create(currQuant, currQuant * item.Price);
                }
                else
                {
                    user.UserCart.Items.Add(item, Tuple.Create(quantity, quantity * item.Price));
                }
            }
            else
            {
                if (item == null) { return "Failure: Cannot add 'null' to cart."; }

                if (user.UserCart == null) { return "Failure: Cart does not exist."; }

                if (quantity < 0) { return "Failure: Quantity must be positive."; }

                if (item.Stock < quantity) { return "Failure: Not enough in stock."; }
            }
            return "Success!";
        }

        // Add an item to the cart
        public void AddItem(Guid cartID, Item item, int quantity)
        {
            //get cart from ID
            List<User> users = userLoader.loadUsers();
            User user = users.Find(x => x.AccountID == cartID); // get user from database using id

            if (item != null && quantity > 0 && item.Stock >= quantity)
            {

                if (user.UserCart.Items.ContainsKey(item))
                {
                    int currQuant = user.UserCart.Items[item].Item1 + quantity;
                    user.UserCart.Items[item] = Tuple.Create(currQuant, currQuant * item.Price);
                }
                else
                {
                    user.UserCart.Items.Add(item, Tuple.Create(quantity, quantity * item.Price));
                }
            }
        }

        // Remove an item from the cart
        public void RemoveItem(Guid cartID, Item item, int quantity)
        {
            //get cart from ID
            List<User> users = userLoader.loadUsers();
            User user = users.Find(x => x.AccountID == cartID); // get user from database using id

            if (item != null && quantity > 0)
            {

                if (user.UserCart.Items.ContainsKey(item))
                {
                    int currQuant = user.UserCart.Items[item].Item1;
                    if (currQuant > quantity)
                    {
                        currQuant -= quantity;
                        user.UserCart.Items[item] = Tuple.Create(currQuant, currQuant * item.Price);
                    }
                    else
                    {
                        user.UserCart.Items.Remove(item);
                    }
                }
            }
        }
    }
}
