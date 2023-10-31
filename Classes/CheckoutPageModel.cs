//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/31/23

namespace CSharpest.Classes
{
    public class CheckoutPageModel
    {
        public List<CartItem> Items { get; set; }
        public Guid CartId { get; set; }
        public Card Card { get; set; }

        public CheckoutPageModel(List<CartItem> items, Guid cartId, Card card) {
            Items = items;
            CartId = cartId;
            Card = card;
        }

    }
}
