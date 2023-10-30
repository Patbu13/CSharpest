namespace CSharpest.Classes
{
    public class AddItemReqParams
    {
        public Guid CartID { get; set; }
        public Guid ItemID { get; set; }
        public int Quantity { get; set; }

    }
}
