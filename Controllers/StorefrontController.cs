using Microsoft.AspNetCore.Mvc;
using CSharpest.Classes;
using CSharpest.Services;
using System.Web;
using System.Net;
using NuGet.Packaging;
using CSharpest.Controllers;
using System.Drawing.Text;
using Microsoft.AspNetCore.Cors.Infrastructure;
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
            // declaring services
            private ItemService itemService;
            private CardService cardService;
            private CartService cartService;
            private CheckoutService checkoutService;

            // declaring controllers
            private ItemController itemController;
            private CardController cardController;
            private CheckoutController checkoutController;
            private CartController cartController;

            public StorefrontController()
            {
                // initializes controllers that interact with StorefrontController
                itemService = new ItemService();
                cartService = new CartService();
                cardService = new CardService();
                checkoutService = new CheckoutService();

                itemController = new ItemController(itemService);
                cartController = new CartController(cartService);
                cardController = new CardController(cardService);
                checkoutController = new CheckoutController(checkoutService);

            }

            UserLoader userLoader = new UserLoader(@".\data\users.json");
            Guid currUserID = new Guid("c4f9f3c1-9aa1-4d72-8a4c-4e03549e5bc1");

            // GET: <StorefrontController>/welcome
            [HttpGet("Welcome")]
            public ActionResult Welcome()
            {
                WelcomePageModel model = new WelcomePageModel(itemController.GetAllItems(), 0, currUserID);
                return View(model);
            }

            // took out currUserID from form for now.
            // POST: <StorefrontController>/addToCart
            [HttpPost("Welcome")]
            public ActionResult Welcome([FromForm] int quantity, [FromForm] Guid itemId)
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
                List<Shopper> users = userLoader.loadUsers();
                Shopper user = users.Find(x => x.AccountID == currUserID);
                if (user.Cart != null)
                {
                    CartPageModel model = new CartPageModel(user.Cart.Items, user.Cart.Subtotal, currUserID);
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
                List<Shopper> users = userLoader.loadUsers();
                Shopper user = users.Find(x => x.AccountID == currUserID);
                if (user.Cart != null)
                {
                    CartPageModel model = new CartPageModel(user.Cart.Items, user.Cart.Subtotal, currUserID);
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
                List<Shopper> users = userLoader.loadUsers();
                Shopper user = users.Find(x => x.AccountID == currUserID);
                user.Cart = checkoutController.calculateTotal(user.Cart);
                if (user.Cart != null)
                {
                    CheckoutPageModel model = new CheckoutPageModel(user.Cart.Items, currUserID, user.Cart);
                    return View(model);
                } else
                {
                    return View(null);
                }
                
            }

            // POST: <StorefrontController>/checkout
            [HttpPost("checkout")]
            public ActionResult Checkout([FromForm] long cardNumber, [FromForm] int month, [FromForm] int year, [FromForm] int cvv, [FromForm]string name) 
            {
                List<Shopper> users = userLoader.loadUsers();
                Shopper user = users.Find(x => x.AccountID == currUserID);
                Card card = new Card(cardNumber, month, year, name, cvv);
                CardCheckParams cardCheck = new CardCheckParams(user, card);

                if (checkoutController.takeCardInput(cardCheck))
                {
                    if (user.Cart != null)
                    {
                        OrderPageModel model = new OrderPageModel(user.Cart.Items, user.Cart, user.Cart.Subtotal, checkoutController.purchase(user));
                        return View("orderConfirmation", model);
                    }
                    else
                    {

                        return View(null);
                    }
                }
                else
                {
                    return View(null);
                }
            }

            // POST: <StorefrontController>/orderConfirmation
            [HttpPost("orderConfirmation")]
            public ActionResult OrderConfirmation([FromForm] long cardNumber, [FromForm] int month, [FromForm] int year, [FromForm] int cvc, [FromForm] string name)
            {
                List<Shopper> users = userLoader.loadUsers();
                Shopper user = users.Find(x => x.AccountID == currUserID);
                Card card = new Card(cardNumber, month, year, name, cvc);
                CardCheckParams cardCheck = new CardCheckParams(user, card);

                if (checkoutController.takeCardInput(cardCheck))
                {
                    if (user.Cart != null)
                    {
                        OrderPageModel model = new OrderPageModel(user.Cart.Items, user.Cart, user.Cart.Subtotal,checkoutController.purchase(user));
                        return View(model);
                    }
                    else
                    {
                        return View(null);
                    }
                } else
                {
                    return View(null);
                }

                
            }

            // Don't think this gets used
            // GET: <StorefrontController>/orderConfirmation
            [HttpGet("orderConfirmation")]
            public ActionResult OrderConfirmation()
            {
                List<Shopper> users = userLoader.loadUsers();
                Shopper user = users.Find(x => x.AccountID == currUserID);

                if (user.Cart != null)
                {
                    OrderPageModel model = new OrderPageModel(user.Cart.Items, user.Cart, user.Cart.Subtotal, true);
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

