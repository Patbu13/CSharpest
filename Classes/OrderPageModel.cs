//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 10/31/23

namespace CSharpest.Classes
{
    public class OrderPageModel
    {
        public List<CartItem> Items { get; set; }
        public decimal Subtotal { get; set; }
        public Guid CartId { get; set; }


        //public Guid CartId { get; set; }
        //public Card Card { get; set; }

        public OrderPageModel(List<CartItem> _items, decimal _subtotal) {
            Items = _items;
            Subtotal = _subtotal;
            //CartId = cartId;
            //Card = card;
        }

    }
}
