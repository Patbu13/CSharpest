using CSharpest.Classes;
using CSharpest.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 11/3/2023

// Handles the checkout process for user completing purchase
// Handles card info, deals with discount bundles
namespace CSharpest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly CheckoutService _checkoutService;
        public CheckoutController(CheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        // takes in a new card and then saves it to user object
        // POST: <CheckoutController>/address
        [HttpPost("{card}")]
        public bool takeCardInput(CardCheckParams checkParams)
        {
            return _checkoutService.takeCardInput(checkParams);
        }


        // POST: <CheckoutController>/card
        [HttpPost("{cardCheck}")]
        public bool ValidateCardDetails(Card card)
        {
            return _checkoutService.ValidateCardDetails(card);
        }

        // Adding address functionality either if we have time or in phase 2
        /*// POST: <CheckoutController>/address
        [HttpPost("{address}")]
        public bool ValidateShippingAddress(User user)
        {
            return true;
        }*/

        // POST: <CheckoutController>/purchase
        [HttpPost("{purchase}")]
        public bool purchase (User user)
        {
            return _checkoutService.purchase(user);
        }

        [HttpPost("{total}")]
        public decimal calculateTotal(Cart cart)
        {
            return _checkoutService.calculateTotal(cart);
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



    }
}