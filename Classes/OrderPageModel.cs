//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 10/31/23

namespace CSharpest.Classes
{
    public class OrderPageModel
    {
        public List<CartItem> Items { get; set; }
<<<<<<< HEAD
        public decimal Subtotal { get; set; }
        public Guid CartId { get; set; }


        //public Guid CartId { get; set; }
        //public Card Card { get; set; }

        public OrderPageModel(List<CartItem> _items, decimal _subtotal) {
            Items = _items;
            Subtotal = _subtotal;
=======
        public bool Confirmed { get; set; }
        //public Guid CartId { get; set; }
        //public Card Card { get; set; }

        public OrderPageModel(List<CartItem> items, bool _confirmed) {
            Items = items;
            Confirmed = _confirmed;
>>>>>>> 903af12156c4186e58e88297057cee37bcf997ea
            //CartId = cartId;
            //Card = card;
        }

    }
}
