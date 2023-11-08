//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 10/31/23

namespace CSharpest.Classes
{
    public class OrderPageModel
    {
        public IEnumerable<CartItem> Items { get; set; }
        //public Guid CartId { get; set; }
        public Cart Cart { get; set; }
        public bool Confirmed { get; set; }


        public OrderPageModel(IEnumerable<CartItem> _items, Cart _cart, bool _confirmed)
        {
            Items = _items;
            Cart = _cart;
            Confirmed = _confirmed;
        }
    }
}
