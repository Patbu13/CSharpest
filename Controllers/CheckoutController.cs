    using CSharpest.Classes;
using Microsoft.AspNetCore.Mvc;

//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 10/24/23
namespace CSharpest
{
    namespace CSharpest.Controllers
    {
        [Route("[controller]")]
        [ApiController]
        public class CheckoutController : ControllerBase
        {
            
            /*// takes in a new card and then saves it to user object
            // POST: <CheckoutController>/address
            [HttpPost("{card}")]
            public bool takeCardInput(Card card, User user)
            {
                if (ValidateCardDetails(card))
                {
                    // if card validation successful, save to user's list of cards
                    if (!(user.UserCards.Contains(card)))
                    {
                        user.UserCards.Add(card);
                    }
                    // otherwise, validation is still successful
                    return true;
                }

                // if not valid, returns false
                return false;
            }
            

            // POST: <CheckoutController>/card
            [HttpPost("{cardCheck}")]
            public bool ValidateCardDetails(Card card)
            {
                // checks for valid credit card number length
                if (card.Number.ToString().Length > 19 || card.Number.ToString().Length < 16)
                {
                    return false;
                }

                // checks for valid month

                if (card.Month < 1 || card.Month > 12)
                {
                    return false;
                }

                // checks for valid year

                if (card.Year <= 2022 || card.Year > 2100)
                {
                    return false;
                }

                if (card.CVV.ToString().Length != 3 || card.CVV.ToString().Length != 4)
                {
                    return false;
                }
                return true;
            }*/


            // POST: <CheckoutController>/address
            [HttpPost("{address}")]
            public bool ValidateShippingAddress(User user)
            {
                return true;
            }

            // POST: <CheckoutController>/purchase
            [HttpPost("{cart}")]
            public bool purchase (Cart cart)
            {
                // reduce stock by quantity purchased

                // save this transaction to user's history

                return true;
            }

            [HttpPost("{total}")]
            public decimal calculateTotal(Cart cart)
            {
                decimal total = 0;

                for (int i = 0; i < cart.Items.Count; i++)
                {
                    KeyValuePair<Item, Tuple<int, decimal>> currItem = cart.Items.ElementAt(i);

                    // adds to total the cost of each item, times the quantity of that item
                    total += ((currItem.Key.Price) * (currItem.Value.Item1));
                }

                // adds tax to total; flat rate of 8% (for now)
                total += (total * 1.08m);

                // calculate shipping; for now flat rate of 5.99
                total += 5.99m;

                return total;
            }


            // GET: <CheckoutController>/confirm
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
