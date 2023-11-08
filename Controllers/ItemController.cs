using CSharpest.Classes;
using CSharpest.Services;
using Microsoft.AspNetCore.Mvc;

//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 11/3/23

namespace CSharpest.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: <ItemController>/GetAllItems
        [HttpGet("GetAllItems")]
        public SortedSet<Item> GetAllItems()
        {
           return _itemService.GetAllItems();
        }
    }
}
