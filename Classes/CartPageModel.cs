//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/30/23

namespace CSharpest.Classes
{
    public class CartPageModel
    {
        public List<CartItem> Items { get; set; }
        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }

        //Setup format for the future, phase 2
        public CartPageModel(List<CartItem> _items, Guid cartId) {
            Items = _items;
            CartId = cartId;
        }

    }
}
