﻿namespace CSharpest.Classes;
using System.Text.Json.Serialization;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 11/7/23

//  Holds the base information for account + shopper properties ex: cart
public class Shopper : IUser
{
	public string FirstName {  get; set; }
	public string LastName { get; set; }
	public Guid AccountID { get; set; }
	public string Email { get; set; }
	public string Password { get; set; } //not addressing security
	public string? Phone { get; set; }
	public string? Address { get; set; }
	public List<Transaction>? TransHistory { get; set; }
	public Cart? Cart { get; set; } 
	public List<Card>? UserCards { get; set; }

    // for an already existing shopper being read from database (needed?)
    [JsonConstructor]
    public Shopper(string _FN, string _LN, Guid _ID, string _email, string _PW, string? _phone, string? _address, Cart _cart)
    {
        AccountID = _ID;
        FirstName = _FN;
        LastName = _LN;
        Email = _email;
        Password = _PW;
        Phone = _phone;
        Address = _address;
        Cart = _cart;
        Cart.CartID = _ID;
    }

    // for a new shopper being added to database
    public Shopper(string _FN, string _LN, string _email, string _PW, string? _phone, string? _address, Cart _cart)
	{
		AccountID = Guid.NewGuid();
		FirstName = _FN;
		LastName = _LN;
		Email = _email;
		Password = _PW;
		Phone = _phone;
		Address = _address;
        Cart = _cart;
        Cart.CartID = AccountID;
	}
    public Shopper() { }

}
