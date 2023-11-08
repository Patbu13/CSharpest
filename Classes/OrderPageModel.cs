//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 10/31/23

namespace CSharpest.Classes
{
    public class OrderPageModel
    {
        public List<CartItem> Items { get; set; }
        public decimal Subtotal { get; set; }
        //not sure if we need this?
        //public Guid CartId { get; set; }
        public Cart Cart { get; set; }
        public bool Confirmed { get; set; }


        public OrderPageModel(List<CartItem> _items, Cart _cart, decimal _subtotal, bool _confirmed)
        {
            Items = _items;
            Cart = _cart;
            Subtotal = _subtotal;
            Confirmed = _confirmed;
        }
    }
}
