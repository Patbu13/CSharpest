using CSharpest.Classes;
using Microsoft.AspNetCore.Mvc;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/29/23
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
            public bool takeCardInput(Card card, Guid userID)
            {
                //FIND USER using USERID once json written
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


            /*// POST: <CheckoutController>/address
            [HttpPost("{address}")]
            public bool ValidateShippingAddress(User user)
            {
                return true;
            }*/

            // POST: <CheckoutController>/purchase
            [HttpPost("{purchase}")]
            public (bool, string) purchase (User user, Cart cart)
            {
                // check in-stock by quantity purchased
                foreach (var item in cart.Items)
                {
                    if (item.Key.Stock - item.Value.Item1 < 0)
                    {
                        return (false, $"Not enough \"{item.Key.Name}\" (ID:{item.Key.ItemId}) in stock");
                    }
                }

                // save this transaction to user's history
                Transaction newTransaction = new Transaction(Guid.NewGuid(), (from k in cart.Items select k.Key), DateTime.Now);
                user.TransHistory.Add(newTransaction);

                if (user.TransHistory.Contains(newTransaction))
                {
                    foreach (var item in cart.Items)
                    {
                        item.Key.Stock -= item.Value.Item1;
                    }
                    return (true, "Successful transaction");
                } else
                { 
                    return (false, "Transaction could not be added to user's transaction history");
                }
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

}
