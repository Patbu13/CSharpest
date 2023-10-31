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
            Guid currUserID = new Guid("c4f9f3c1-9aa1-4d72-8a4c-4e03549e5bc1");

            // GET: <StorefrontController>/welcome
            [HttpGet("Welcome")]
            public ActionResult Welcome()
            {
                //ViewBag.Cart = cartController.GetCartItems(currUserID);
                WelcomePageModel model = new WelcomePageModel(itemController.GetAllItems(), 0, currUserID);
                return View(model);
            }

            // POST: <StorefrontController>/addToCart
            [HttpPost("Welcome")]
            public ActionResult Welcome([FromForm] int quantity, [FromForm] Guid currUserID, [FromForm] Guid itemId)
            {
                cartController.AddItemToCart(currUserID, itemId, quantity);
                WelcomePageModel model = new WelcomePageModel(itemController.GetAllItems(), 0, currUserID);
                return View(model);
            }

            // GET: <StorefrontController>/cart
            [HttpGet("cart")]
            public ActionResult Cart()
            {

                return View(cartController.GetCartItems(currUserID));
            }

            // GET: <StorefrontController>/checkout
            [HttpGet("checkout")]
            public ActionResult Checkout()
            {
                return View(cartController.GetCartItems(currUserID));
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

