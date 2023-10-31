using CSharpest.Classes;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/30/23

// Handles the checkout process for user completing purchase
// Handles card info, deals with discount bundles
namespace CSharpest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        InventoryLoader inventoryLoader = new InventoryLoader(@".\data\inventory.json");
        InventoryWriter inventoryWriter = new InventoryWriter(@".\data\inventory.json");
        UserWriter userWriter = new UserWriter(@".\data\users.json");

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
        public bool purchase (PurchaseRequestParams purchaseParams)
        {
            // ALREADY CHECKED IN CART
            // Logically, should be in checkout but trying to meet deadline

            /*// check in-stock by quantity purchased
            foreach (var item in purchaseParams.Cart.Items)
            {
                if (item.Stock - item.Value.Item1 < 0)
                {
                    return false;
                    //return (false, $"Not enough \"{item.Key.Name}\" (ID:{item.Key.ItemId}) in stock");
                }
            }*/

            // save this transaction to user's history
            Transaction newTransaction = new Transaction(Guid.NewGuid(), purchaseParams.Cart.Items, DateTime.Now);
            if (purchaseParams.User.TransHistory != null)
            {
                purchaseParams.User.TransHistory.Add(newTransaction);
            } else
            {
                purchaseParams.User.TransHistory = new List<Transaction> { newTransaction };
            }

            List<Item> items = inventoryLoader.loadInventory();

            if (purchaseParams.User.TransHistory.Contains(newTransaction))
            {
                foreach (var cartItem in purchaseParams.Cart.Items)
                {
                    var item = items.Find(x => x.ItemId == cartItem.Item.ItemId);
                    item.Stock -= cartItem.Quantity;
                    inventoryWriter.writeInventory(item);
                }
                
                return true;
                //return (true, "Successful transaction");
            } else
            {
                return false;
                //return (false, "Transaction could not be added to user's transaction history");
            }

        }

        [HttpPost("{total}")]
        public decimal calculateTotal(Cart cart)
        {
            decimal total = 0;

            foreach (CartItem cartItem in cart.Items)
            { 
                // multiplies the cost of each item times the quantity of that item
                // then adds product to total
                total += ((cartItem.Item.Price) * (cartItem.Quantity));
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