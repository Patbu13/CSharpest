//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/30/23

namespace CSharpest.Classes
{
    public class CheckoutPageModel
    {
        public List<CartItem> Items { get; set; }
        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }

        public CheckoutPageModel(List<CartItem> items, Guid cartId) {
            Items = items;
            CartId = cartId;
        }

    }
}
