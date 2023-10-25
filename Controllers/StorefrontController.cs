using Microsoft.AspNetCore.Mvc;
using CSharpest.Classes;
using System.Web;
//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 10/24/23
namespace CSharpest
{
    namespace CSharpest.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        // If using ActionResult and other methods from Web API, need to have controller inherit from Controller, not ControllerBase
        public class StorefrontController : Controller
        {
            // GET: api/<StorefrontController>/welcome
            [HttpGet("welcome")]
            public ActionResult Welcome()
            {
                return View();
            }

            // GET: api/<StorefrontController>/cart
            [HttpGet("cart")]
            public ActionResult Cart()
            {
                return View();
            }

            // GET: api/<StorefrontController>/checkout
            [HttpGet("checkout")]
            public ActionResult Checkout()
            {
                return View();
            }
        }
    }
}

