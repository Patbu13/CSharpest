using Microsoft.AspNetCore.Mvc;
using CSharpest.Classes;
using System.Collections.Generic;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/29/23
namespace CSharpest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        // GET: api/<CartController>
        [HttpGet("GetCartItems")]
        public Dictionary<Item, Tuple<int, decimal>> GetCartItems()
        {
            Dictionary < Item, Tuple<int, decimal> > cartItems = cart.Items;
            return cartItems;
        }


        [HttpPost("AddItemToCart")]
        public string AddItemToCart(Guid cartID, Guid itemID, int quantity)
        {
            Item item = new Item(itemID); // get item from database using id
            Cart cart = new Cart(cartID); // get cart from database using id

            if (item != null && cart != null && quantity > 0 && item.Stock >= quantity)
            {

                if (cart.Items.ContainsKey(item))
                {
                    int currQuant = cart.Items[item].Item1 + quantity;
                    cart.Items[item] = Tuple.Create(currQuant, currQuant * item.Price);
                }
                else
                {
                    cart.Items.Add(item, Tuple.Create(quantity, quantity * item.Price));
                }
            }
            else
            {
                if (item == null) { return "Failure: Cannot add 'null' to cart."; }

                if (cart == null) { return "Failure: Cart does not exist."; }

                if (quantity < 0) { return "Failure: Quantity must be positive."; }

                if (item.Stock < quantity) { return "Failure: Not enough in stock."; }
            }
            return "Success!";
        }

        // Add an item to the cart
        public void AddItem(Guid cartID, Item item, int quantity)
        {
            //get cart from ID
            if (item != null && quantity > 0 && item.Stock >= quantity)
            {

                if (cart.Items.ContainsKey(item))
                {
                    int currQuant = cart.Items[item].Item1 + quantity;
                    cart.Items[item] = Tuple.Create(currQuant, currQuant * item.Price);
                }
                else
                {
                    cart.Items.Add(item, Tuple.Create(quantity, quantity * item.Price));
                }
            }
        }

        // Remove an item from the cart
        public void RemoveItem(Guid cartID, Item item, int quantity)
        {
            //get cart from ID
            if (item != null && quantity > 0)
            {

                if (cart.Items.ContainsKey(item))
                {
                    int currQuant = cart.Items[item].Item1;
                    if (currQuant > quantity)
                    {
                        currQuant -= quantity;
                        cart.Items[item] = Tuple.Create(currQuant, currQuant * item.Price);
                    }
                    else
                    {
                        cart.Items.Remove(item);
                    }
                }
            }
        }
    }
}
