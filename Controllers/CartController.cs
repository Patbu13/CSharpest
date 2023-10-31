using Microsoft.AspNetCore.Mvc;
using CSharpest.Classes;
using System.Collections.Generic;
using System.Collections;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

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
        UserWriter userWriter = new UserWriter(@".\data\users.json");
        Guid currUserID = new Guid("c4f9f3c1-9aa1-4d72-8a4c-4e03549e5bc1");

        // GET: api/<CartController>
        [HttpGet("GetCartItems")]
        public Dictionary<Item, Tuple<int, decimal>> GetCartItems(Guid UserID)
        {
            List<User> users = userLoader.loadUsers();
            User user = users.Find(x => x.AccountID == UserID);
            if (user == null)
            {
                user = new User("Example", "User", "exampleuser@email.com", "ExamplePW","phone", "address", new Cart());
            }

            Dictionary < Item, Tuple<int, decimal> > cartItems = user.Cart.Items;
            return cartItems;
        }


        //[HttpPost("AddItemToCart")]
        //public int AddItemToCart(int Quantity)
        //{
        //    return Quantity; 
        //}

        [HttpPost("AddItemToCart")]
        public void AddItemToCart(Guid CartID, Guid ItemID, int Quantity)
        {
            List<Item> items = inventoryLoader.loadInventory();
            Item item = items.Find(x => x.ItemId == ItemID); // get item from database using id

            List<User> users = userLoader.loadUsers();
            User user = users.Find(x => x.AccountID == currUserID); // get user from database using id
            
            if (item != null && user.Cart != null && Quantity > 0 && item.Stock >=Quantity)
            {

                if (user.Cart.Items.ContainsKey(item))
                {
                    int currQuant = user.Cart.Items[item].Item1 + Quantity;
                    user.Cart.Items[item] = Tuple.Create(currQuant, currQuant * item.Price);
                    userWriter.writeUser(user);
                }
                else
                {
                    user.Cart.Items.Add(item, Tuple.Create(Quantity, Quantity * item.Price));
                    userWriter.writeUser(user);
                }
            }
            else
            {
                if (item == null) { Environment.Exit(0); }

                if (user.Cart == null) { Environment.Exit(0); }

                if (Quantity < 0) { Environment.Exit(0); }

                if (item.Stock < Quantity) { Environment.Exit(0); }
            }

            //return "Success!";
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
                        userWriter.writeUser(user);
                    }
                    else
                    {
                        user.Cart.Items.Remove(itemParams.Item);
                        userWriter.writeUser(user);
                    }
                }
            }
        }
    }
}
