namespace CSharpest.Classes
{
    public class WelcomePageModel
    {
        public List<CartItem> Items { get; set; }
        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }

        public WelcomePageModel(List<CartItem> items, Guid cartId) {
            Items = items;
            CartId = cartId;
        }

    }
}
