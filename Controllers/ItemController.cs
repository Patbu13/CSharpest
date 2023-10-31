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
            SortedSet<Item> items = inventoryLoader.loadInventorySorted();
            return items;
        }
    }
}
