using Microsoft.AspNetCore.Mvc;
using CSharpest.Classes;
using CSharpest.Services;

//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 11/3/23

namespace CSharpest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;
       
        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        // GET: api/<CartController>
        [HttpGet("GetCartItems")]
        public List<CartItem> GetCartItems(Guid UserID)
        {
            return _cartService.GetCartItems(UserID);
           
        }

        [HttpPost("AddItemToCart")]
        public void AddItemToCart(Guid ItemID, int quantity)
        {
            _cartService.AddItemToCart(ItemID, quantity);
        }

        // Remove an item from the cart
        [HttpPost("RemoveItemFromCart")]
        public void RemoveItem(Guid ItemID, int quantity)
        {
            _cartService.RemoveItem(ItemID, quantity);
        }
    }
}
