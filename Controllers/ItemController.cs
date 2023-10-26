using CSharpest.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace CSharpest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        // GET: <ItemController>/GetAllItems
        [HttpGet("GetAllItems")]
        public Item[] GetAllItems()
        {
            Item[] items = new Item[10];
            return items;
        }

        // POST: <ItemController>/GetAllItems
        [HttpPost("AddItemToCart")]
        public bool AddItemToCart(Guid cartId, Guid itemId, int quantity)
        {
            return true;
        }

    }
}
