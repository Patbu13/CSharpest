﻿namespace CSharpest.Classes;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/12/23

//  Saves completed transactions with the items purchased & when
public class Transaction
{
	public Guid TransID { get; set; }
	public List<Item> Items { get; set; }
	public DateTime DateTime { get; set; }

	public Transaction(Guid _ID, List<Item> _items, DateTime _DT)
	{
		TransID = _ID;
		Items = _items;
		DateTime = _DT;
	}
}
