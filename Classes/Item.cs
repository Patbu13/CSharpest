namespace CSharpest.Classes;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 10/10/23
public class Item
{

    // fields
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid ItemId { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }


    public Item()
    {
        ItemId = Guid.NewGuid();
    }
}
