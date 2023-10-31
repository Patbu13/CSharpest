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
            UserLoader userLoader = new UserLoader(@".\data\users.json");
            Guid currUserID = new Guid("c4f9f3c1-9aa1-4d72-8a4c-4e03549e5bc1");

            // GET: <StorefrontController>/welcome
            [HttpGet("Welcome")]
            public ActionResult Welcome()
            {
                WelcomePageModel model = new WelcomePageModel(itemController.GetAllItems(), 0, currUserID);
                return View(model);
            }

            // POST: <StorefrontController>/addToCart
            [HttpPost("Welcome")]
            public ActionResult Welcome([FromForm] int quantity, [FromForm] Guid currUserID, [FromForm] Guid itemId)
            {
                //Currently not implementing "current user" functionality so don't need currUserID here
                cartController.AddItemToCart(itemId, quantity);
                WelcomePageModel model = new WelcomePageModel(itemController.GetAllItems(), 0, currUserID);
                return View(model);
            }

            // GET: <StorefrontController>/cart
            [HttpGet("cart")]
            public ActionResult Cart()
            {
                List<User> users = userLoader.loadUsers();
                User user = users.Find(x => x.AccountID == currUserID);
                if (user.Cart != null)
                {
                    CartPageModel model = new CartPageModel(user.Cart.Items, currUserID);
                    return View(model);
                } else
                {
                    return View(null);
                }
                
                
            }

            // POST: <StorefrontController>/cart
            [HttpPost("cart")]
            public ActionResult Cart([FromForm] Guid cartID)
            {
                List<User> users = userLoader.loadUsers();
                User user = users.Find(x => x.AccountID == currUserID);
                if (user.Cart != null)
                {
                    CartPageModel model = new CartPageModel(user.Cart.Items, currUserID);
                    return View(model);
                }
                else
                {
                    return View(null);
                }
            }

            // GET: <StorefrontController>/checkout
            [HttpGet("checkout")]
            public ActionResult Checkout()
            {
                List<User> users = userLoader.loadUsers();
                User user = users.Find(x => x.AccountID == currUserID);
                if (user.Cart != null)
                {
                    CheckoutPageModel model = new CheckoutPageModel(user.Cart.Items, currUserID);
                    return View(model);
                } else
                {
                    return View(null);
                }
                
            }

            // POST: <StorefrontController>/checkout
            [HttpPost("checkout")]
            public ActionResult Checkout(int cardNumber, int month, int year, string name, int cvc) 
            {
                List<User> users = userLoader.loadUsers();
                User user = users.Find(x => x.AccountID == currUserID);
                Card card = new Card (cardNumber, month, year, name, cvc);
                user.UserCards.Add(card);
                if (user.Cart != null)
                {
                    CheckoutPageModel model = new CheckoutPageModel(user.Cart.Items, currUserID, user.UserCards[0]);
                    return View(model);
                }
                else
                {
                    return View(null);
                }
            }

            // GET: <StorefrontController>/orderConfirmation
            [HttpGet("orderConfirmation")]
            public ActionResult OrderConfirmation()
            {
                List<User> users = userLoader.loadUsers();
                User user = users.Find(x => x.AccountID == currUserID);

                if (user.Cart != null)
                {
                    OrderPageModel model = new OrderPageModel(user.Cart.Items);
                    return View(model);
                }
                else
                {
                    return View(null);
                }
            }

        }
    }
}

