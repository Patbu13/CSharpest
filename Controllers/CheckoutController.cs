using CSharpest.Classes;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

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
        UserLoader userLoader = new UserLoader(@".\data\users.json");
        UserWriter userWriter = new UserWriter(@".\data\users.json");
        Guid currUserID = new Guid("c4f9f3c1-9aa1-4d72-8a4c-4e03549e5bc1");

        // takes in a new card and then saves it to user object
        // POST: <CheckoutController>/address
        [HttpPost("{card}")]
        public bool takeCardInput(CardCheckParams checkParams)
        {
            //FIND USER using userID will be working in phase 2, hardcode for now

            if (ValidateCardDetails(checkParams.Card))
            {
                // if card validation successful, save to user's list of cards
                if (!(checkParams.User.UserCards.Contains(checkParams.Card)))
                {
                    checkParams.User.UserCards.Add(checkParams.Card);
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
            // checks card nullity
            if (card == null)
            {
                return false;
            }

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

            if (card.CVV.ToString().Length !> 4)
            {
                return false;
            }
            return true;
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
            Transaction newTransaction = new Transaction(Guid.NewGuid(), user.Cart.Items, DateTime.Now);
            if (user.TransHistory != null)
            {
                user.TransHistory.Add(newTransaction);
            } else
            {
                user.TransHistory = new List<Transaction> { newTransaction };
            }

            List<Item> items = inventoryLoader.loadInventory();

            if (user.TransHistory.Contains(newTransaction))
            {
                foreach (var cartItem in user.Cart.Items)
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

                // checks if item is Buy one Get one free
                if (cartItem.Item.Bogo)
                {
                    if (cartItem.Quantity % 2 == 1) {
                        total += cartItem.Item.Price + (cartItem.Item.Price * (cartItem.Quantity / 2));
                    } else
                    {
                        total += cartItem.Item.Price * (cartItem.Quantity / 2);
                    } 
                } else
                {
                    total += cartItem.Item.Price * cartItem.Quantity;
                }
                
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