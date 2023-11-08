namespace CSharpest.Classes
{
    public class RemoveItemReqParams
    {
        public Guid CartID { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }

    }
}
