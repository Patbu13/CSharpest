namespace CSharpest.Classes
{
    public class WelcomePageModel
    {
        public List<Item> Items { get; set; }
        //public Guid CartID { get; set; }
        //public Guid ItemID { get; set; }
        public int Quantity { get; set; }

        public WelcomePageModel(List<Item> items, int quantity) {
            Items = items;
            Quantity = quantity;
        }

    }
}
