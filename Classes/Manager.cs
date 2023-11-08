namespace CSharpest.Classes;
using System.Text.Json.Serialization;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 11/7/23

//  Holds the base information for account + allows for store manager privileges
public class Manager : IUser
{
	public string FirstName {  get; set; }
	public string LastName { get; set; }
	public Guid AccountID { get; set; }
	public string Email { get; set; }
	public string Password { get; set; } //not addressing security
	public string? Phone { get; set; }
	public string? Address { get; set; }

    // for an already existing manager being read from database (needed?)
    [JsonConstructor]
    public Manager(string _FN, string _LN, Guid _ID, string _email, string _PW, string? _phone, string? _address)
    {
        AccountID = _ID;
        FirstName = _FN;
        LastName = _LN;
        Email = _email;
        Password = _PW;
        Phone = _phone;
        Address = _address;
    }

    // for a new manager being added to database
    public Manager(string _FN, string _LN, string _email, string _PW, string? _phone, string? _address)
	{
		AccountID = Guid.NewGuid();
		FirstName = _FN;
		LastName = _LN;
		Email = _email;
		Password = _PW;
		Phone = _phone;
		Address = _address;
	}
    public Manager() { }

}
