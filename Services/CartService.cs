using CSharpest.Classes;

//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 11/3/23

namespace CSharpest.Services
{
    public class CartService
    {
        private readonly CardService _cardService;
        InventoryLoader inventoryLoader = new InventoryLoader(@".\data\inventory.json");
        UserLoader userLoader = new UserLoader(@".\data\users.json");
        UserWriter userWriter = new UserWriter(@".\data\users.json");
        Guid currUserID = new Guid("c4f9f3c1-9aa1-4d72-8a4c-4e03549e5bc1");

        public CartService()
        {
        }

        public List<CartItem> GetCartItems(Guid UserID)
        {
            List<User> users = userLoader.loadUsers();
            User user = users.Find(x => x.AccountID == currUserID);

            if (user == null)
            {
                user = new User("Example", "User", "exampleuser@email.com", "ExamplePW", "phone", "address", new Cart());
            }

            List<CartItem> cartItems = user.Cart.Items;
            return cartItems;
        }

        public void AddItemToCart(Guid ItemID, int quantity)
        {
            List<Item> items = inventoryLoader.loadInventory();
            //Has been modified to not concern itself with getting current user back from frontend
            //currUserID has been hard coded for phase 1
            List<User> users = userLoader.loadUsers();

            User user = users.Find(x => x.AccountID == currUserID); // get user from database using id
            //ensure user was found
            if (user == null) { Environment.Exit(0); }

            Item item = items.Find(x => x.ItemId == ItemID); // get item from database using id
            //ensure item was found
            if (item == null) { Environment.Exit(0); }

            //Create totalPrice of product
            decimal totalPrice = item.Price * (decimal)quantity;

            //Adds x number of item y to cart
            if (user.Cart != null && quantity > 0 && item.Stock >= quantity)
            {

                if (user.Cart.Items.Find(x => x.Item.ItemId == ItemID) == null)
                {
                    //First instance of this item being in cart
                    //Create CartItem
                    CartItem cartItem = new CartItem(item, quantity, totalPrice);
                    user.Cart.Items.Add(cartItem);
                    user.Cart.Subtotal += cartItem.TotalPrice;
                    user.Cart.Taxes += (user.Cart.Subtotal * 0.08m);
                    user.Cart.Total += ((user.Cart.Subtotal * 1.08m) + 5.99m);
                    userWriter.writeUser(user);

                }
                else
                {   // make sure user cannot add more than (stock minus what's already in cart)
                    if ((user.Cart.Items.Single(x => x.Item.ItemId == ItemID).Quantity + quantity) <= item.Stock)
                    {
                        //Customer is adding more of this item to cart
                        user.Cart.Items.Single(x => x.Item.ItemId == ItemID).Quantity += quantity;
                        user.Cart.Items.Single(x => x.Item.ItemId == ItemID).TotalPrice += totalPrice;
                        user.Cart.Subtotal += quantity * item.Price;
                        user.Cart.Taxes += (user.Cart.Subtotal * 0.08m);
                        user.Cart.Total += ((user.Cart.Subtotal * 1.08m) + 5.99m);
                        userWriter.writeUser(user);
                    }
                }

            }
            else
            {

                if (user.Cart == null) { Environment.Exit(0); } // User added nothing to cart

                if (quantity < 0) { Environment.Exit(0); } // Should never happen but can't hurt

                if (item.Stock < quantity) { Environment.Exit(0); } // Not enough in stock to purchase that amount
            }

        }

        public void RemoveItem(Guid ItemID, int quantity)
        {
            List<Item> items = inventoryLoader.loadInventory();
            Item item = items.Find(x => x.ItemId == ItemID); // get item from database using id

            if (item == null) { Environment.Exit(0); } //ensure item was found

            List<User> users = userLoader.loadUsers(); // curUserID has been hardcoded for phase 1
            User user = users.Find(x => x.AccountID == currUserID); // get user from database using id

            //ensure user was found
            if (user == null) { Environment.Exit(0); } // ensure user was found

            //Create totalPrice of product
            decimal totalPrice = item.Price * (decimal)quantity;

            if (user.Cart != null && quantity > 0)
            {
                CartItem cartItem = user.Cart.Items.Find(x => x.Item.ItemId == ItemID); //Create CartItem
                // if the item is in the user's cart
                if (cartItem != null)
                {
                    // checks if the cart has more of said item than user is trying to remove
                    if (cartItem.Quantity >= quantity)
                    {
                        //Customer is adding more of this item to cart
                        user.Cart.Items.Single(x => x.Item.ItemId == ItemID).Quantity -= quantity;
                        user.Cart.Items.Single(x => x.Item.ItemId == ItemID).TotalPrice -= totalPrice;
                        user.Cart.Subtotal -= quantity * item.Price;
                        userWriter.writeUser(user); // update user
                    }
                    else // if user wants to remove more than what is already in cart 
                    {    // the whole item gets removed
                        user.Cart.Items.Remove(user.Cart.Items.Single(x => x.Item.ItemId == ItemID));
                        user.Cart.Subtotal -= item.Price * cartItem.Quantity;
                        userWriter.writeUser(user);
                    }
                }
                else
                {
                    if (user.Cart == null) { Environment.Exit(0); } // User added nothing to cart
                    if (cartItem.Quantity < 0) { Environment.Exit(0); } // Should never happen but can't hurt
                }
            }
        }
    }


    }
}
