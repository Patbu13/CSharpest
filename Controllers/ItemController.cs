using CSharpest.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/29/23

namespace CSharpest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        InventoryLoader inventoryLoader = new InventoryLoader(@".\data\inventory.json");
        // GET: <ItemController>/GetAllItems
        [HttpGet("GetAllItems")]
        public SortedSet<Item> GetAllItems()
        {
            SortedSet<Item> items = inventoryLoader.loadInventory();
            return items;
        }

        [HttpPost("AddItemToCart")]
        public string AddItemToCart(Guid cartID, Guid itemID, int quantity)
        {
            Item item = new Item(itemID); // get item from database using id
            Cart cart = new Cart(cartID); // get cart from database using id

            if (item != null && cart != null && quantity > 0 && item.Stock >= quantity)
            {

                if (Items.ContainsKey(item))
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


    }
}
