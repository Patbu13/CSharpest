using Microsoft.AspNetCore.Mvc;
using CSharpest.Classes;
using System.Collections.Generic;
using System.Collections;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/30/23
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
        public List<CartItem> GetCartItems(Guid UserID)
        {
            List<User> users = userLoader.loadUsers();
            User user = users.Find(x => x.AccountID == currUserID);

            if (user == null)
            {
                user = new User("Example", "User", "exampleuser@email.com", "ExamplePW","phone", "address", new Cart());
            }

            List<CartItem> cartItems = user.Cart.Items;
            return cartItems;
        }


        //[HttpPost("AddItemToCart")]
        //public int AddItemToCart(int Quantity)
        //{
        //    return Quantity; 
        //}

        [HttpPost("AddItemToCart")]
        public void AddItemToCart(Guid ItemID, int quantity)
        {
            List<Item> items = inventoryLoader.loadInventory();
            Item item = items.Find(x => x.ItemId == ItemID); // get item from database using id
            //ensure item was found
            if (item == null) { Environment.Exit(0); }

            //Create CartItem
            CartItem cartItem = new CartItem(item, quantity);

            //Has been modified to not concern itself with getting current user back from frontend
            //currUserID has been hard coded for phase 1
            List<User> users = userLoader.loadUsers();
            User user = users.Find(x => x.AccountID == currUserID); // get user from database using id
            //ensure user was found
            if (user == null) { Environment.Exit(0); }

            //Adds x number of item y to cart
            if (user.Cart != null && cartItem.Quantity > 0 && item.Stock >= cartItem.Quantity)
            {

                if (user.Cart.Items.Find(x => x.Item.ItemId == ItemID) == null)
                {
                    //First instance of this item being in cart
                    user.Cart.Items.Add(cartItem);
                    userWriter.writeUser(user);
                    
                }
                else
                {
                    //Customer is adding more of this item to cart
                    //LINQ?? maybe :)
                    //Now realizing a List was probably not the best for this.. too late -patrick
                    user.Cart.Items.Single(x => x.Item.ItemId == ItemID).Quantity += cartItem.Quantity;
                    userWriter.writeUser(user);
                }
            }
            else
            {

                if (user.Cart == null) { Environment.Exit(0); } // User added nothing to cart

                if (cartItem.Quantity < 0) { Environment.Exit(0); } // Should never happen but can't hurt

                if (item.Stock < cartItem.Quantity) { Environment.Exit(0); } // Not enough in stock to purchase that amount
            }

        }

/*        //NEEDS DONE
        [HttpPost("RemoveItemFromCart")]

        // Remove an item from the cart
        public void RemoveItem(RemoveItemReqParams itemParams)
        {
            //get cart from ID
            List<User> users = userLoader.loadUsers();
            User user = users.Find(x => x.AccountID == itemParams.CartID); // get user from database using id

            if (itemParams.Item != null && itemParams.Quantity > 0)
            {

                if (user.Cart.Items.Contains(itemParams.Item))
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
        }*/
    }
}
