namespace CSharpest.Classes
{
    public class WelcomePageModel
    {
        public List<Item> Items { get; set; }
        //public Guid CartID { get; set; }
        //public Guid ItemID { get; set; }
        public int Quantity { get; set; }

        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }

        public WelcomePageModel(List<Item> items, int quantity, Guid cartId) {
            Items = items;
            CartId = cartId;
            Quantity = quantity;
        }

    }
}
