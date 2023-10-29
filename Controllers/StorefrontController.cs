using Microsoft.AspNetCore.Mvc;
using CSharpest.Classes;
using System.Web;
using System.Net;
using NuGet.Packaging;
using CSharpest.Controllers;
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
            CartController cartController = new CartController();
            ItemController itemController = new ItemController();
            InventoryLoader inventoryLoader = new InventoryLoader(@".\data\inventory.json");
            Cart cart = new Cart(0);

            // GET: <StorefrontController>/welcome
            [HttpGet("welcome")]
            public ActionResult Welcome()
            {         
                return View(itemController.GetAllItems());
            }

            // GET: <StorefrontController>/cart
            [HttpGet("cart")]
            public ActionResult Cart()
            {

                return View(cartController.GetCartItems());
            }

            // GET: <StorefrontController>/checkout
            [HttpGet("checkout")]
            public ActionResult Checkout()
            {
                return View(cartController.GetCartItems());
            }

            // GET: <StorefrontController>/orderConfirmation
            [HttpGet("orderConfirmation")]
            public ActionResult OrderConfirmation()
            {
                return View();
            }
        }
    }
}

