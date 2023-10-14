namespace CSharpest.Classes;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/12/23

//  Holds the information for an account
public class User
{
	public string FirstName {  get; set; }
	public string LastName { get; set; }
	public Guid AccountID { get; set; }
	public string Email { get; set; }
	public string Password { get; set; } //not addressing security
	public int? Phone { get; set; }
	public string? Address { get; set; }
	public List<Transaction>? TransHistory { get; set; }
	public Cart UserCart { get; set; } 
	public List<Card>? UserCards { get; set; }
	
	public User(string _FN, string _LN, Guid _ID, string _email, string _PW, int? _phone, string? _address, Cart _cart)
	{
		AccountID = Guid.NewGuid();
		FirstName = _FN;
		LastName = _LN;
		AccountID = _ID;
		Email = _email;
		Password = _PW;
		Phone = _phone;
		Address = _address;
		UserCart = _cart;
	}
}
