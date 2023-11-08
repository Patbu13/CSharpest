using CSharpest.Classes;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 11/8/23

namespace CSharpest.Services
{
    public class CheckoutService
    {
        private readonly CheckoutService _checkoutService;
        InventoryLoader inventoryLoader = new InventoryLoader(@".\data\inventory.json");
        InventoryWriter inventoryWriter = new InventoryWriter(@".\data\inventory.json");
        UserLoader userLoader = new UserLoader(@".\data\users.json");
        UserWriter userWriter = new UserWriter(@".\data\users.json");
        Guid currUserID = new Guid("c4f9f3c1-9aa1-4d72-8a4c-4e03549e5bc1");

        public CheckoutService()
        {
        }

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

            if (card.CVV.ToString().Length! > 4)
            {
                return false;
            }
            return true;
        }

        public bool purchase(Shopper user)
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
            }
            else
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
            }
            else
            {
                return false;
                //return (false, "Transaction could not be added to user's transaction history");
            }
        }

        public Cart calculateTotal(Cart cart)
        {
            //decimal total = 0;

            List<Shopper> users = userLoader.loadUsers();

            Shopper user = users.Find(x => x.AccountID == currUserID); // get user from database using id
            //ensure user was found
            if (user == null) { Environment.Exit(0); }

            user.Cart.Total = 0;
            user.Cart.Taxes = 0;
            user.Cart.Subtotal = 0;

            foreach (CartItem cartItem in cart.Items)
            {
                //Calculate subtotal without discounts
                user.Cart.Subtotal += cartItem.Item.Price * cartItem.Quantity;

                // multiplies the cost of each item times the quantity of that item
                // then adds product to total

                // checks if item is Buy one Get one free
                if (cartItem.Item.Bogo)
                {
                    if (cartItem.Quantity % 2 == 1)
                    {
                        user.Cart.Total += cartItem.Item.Price + (cartItem.Item.Price * (cartItem.Quantity / 2));
                    }
                    else
                    {
                        user.Cart.Total += cartItem.Item.Price * (cartItem.Quantity / 2);
                    }
                }
                else
                {
                    user.Cart.Total += cartItem.Item.Price * cartItem.Quantity;
                }

            }

            user.Cart.Discount = user.Cart.Subtotal - user.Cart.Total;

            // adds tax to total; flat rate of 8% (for now)
            user.Cart.Taxes = (user.Cart.Total * 0.08m);

            user.Cart.Total += (user.Cart.Taxes);

            // calculate shipping; for now flat rate of 5.99
            user.Cart.Total += 5.99m;

            userWriter.writeUser(user);

            return user.Cart;
        }



    }
}
