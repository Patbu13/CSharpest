using Microsoft.AspNetCore.Mvc;
using CSharpest.Classes;
using System.Web;
using System.Net;
using NuGet.Packaging;
//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 10/24/23
namespace CSharpest
{
    namespace CSharpest.Controllers
    {
        [Route("[controller]")]
        [ApiController]
        // If using ActionResult and other methods from Web API, need to have controller inherit from Controller, not ControllerBase
        public class StorefrontController : Controller
        {
            InventoryLoader inventoryLoader = new InventoryLoader(@"C:\Users\vivia\source\repos\CSharpest\data\inventory.json");
            // GET: <StorefrontController>/welcome
            [HttpGet("welcome")]
            public ActionResult Welcome()
            {
                SortedSet<Item> viewModels = inventoryLoader.loadInventory();
         
                return View(viewModels);
            }

            // GET: <StorefrontController>/cart
            [HttpGet("cart")]
            public ActionResult Cart()
            {
                return View();
            }

            // GET: <StorefrontController>/checkout
            [HttpGet("checkout")]
            public ActionResult Checkout()
            {
                return View();
            }
        }
    }
}

