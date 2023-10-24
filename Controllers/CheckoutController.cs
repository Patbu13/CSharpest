using CSharpest.Classes;
using Microsoft.AspNetCore.Mvc;

namespace CSharpest
{
    namespace CSharpest.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CheckoutController : ControllerBase
        {
   
            // POST: api/<CheckoutController>/card
            [HttpPost("{card}")]
            public bool ValidateCardDetails(Card card)
            {
                return true;
            }

            // POST: api/<CheckoutController>/address
            [HttpPost("{address}")]
            public bool ValidateShippingAddress(User user)
            {
                return true;
            }

            // POST: api/<CheckoutController>/purchase
            [HttpPost("{cart}")]
            public void purchase (Cart cart)
            {
            }


            // GET: api/<CheckoutController>/confirm
            [HttpGet("confirm")]
            public string sendConfirmation()
            {
                return "Successful!";
            }

            // to be looked at later

            // POST: api/<CheckoutController>/giftCard
            //[HttpPost("{giftCard}")]
            //public bool RedeemGiftCard(User user)
            //{
            //    return true;
            //}



            //// GET: api/<CheckoutController>
            //[HttpGet]
            //public bool validatePayPalDetails()
            //{
            //    return true;
            //}


            //[HttpGet]
            //public ActionResult Index()
            //{
            //    return View();
            //}

            //// GET: HomeController/Details/5
            //public ActionResult Details(int id)
            //{
            //    return View();
            //}

            //// GET: HomeController/Create
            //public ActionResult Create()
            //{
            //    return View();
            //}

            //// POST: HomeController/Create
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Create(IFormCollection collection)
            //{
            //    try
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}

            //// GET: HomeController/Edit/5
            //public ActionResult Edit(int id)
            //{
            //    return View();
            //}

            //// POST: HomeController/Edit/5
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Edit(int id, IFormCollection collection)
            //{
            //    try
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}

            //// GET: HomeController/Delete/5
            //public ActionResult Delete(int id)
            //{
            //    return View();
            //}

            //// POST: HomeController/Delete/5
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Delete(int id, IFormCollection collection)
            //{
            //    try
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}
        }
    }

}
