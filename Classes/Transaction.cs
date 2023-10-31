namespace CSharpest.Classes;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/30/23

//  Saves completed transactions with the items purchased & when
public class Transaction
{
	public Guid TransID { get; set; }
	public IEnumerable<CartItem> Items { get; set; }
	public DateTime DateTime { get; set; }

	public Transaction(Guid _ID, IEnumerable<CartItem> _items, DateTime _DT)
	{
		TransID = _ID;
		Items = _items;
		DateTime = _DT;
	}
}
