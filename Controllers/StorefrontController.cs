using Microsoft.AspNetCore.Mvc;
using CSharpest.Classes;
using System.Web;
using System.Net;
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
            // GET: <StorefrontController>/welcome
            [HttpGet("welcome")]
            public ActionResult Welcome()
            {
                var viewModel = new Item()
                {
                    Name = "Milk",
                    Description = "Refreshing milk fresh from the Milky Way",
                    ItemId = Guid.NewGuid(),
                    Price = 2.89m,
                    Stock = 100
                };
                return View(viewModel);
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

