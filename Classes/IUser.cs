namespace CSharpest.Classes;
using System.Text.Json.Serialization;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 11/7/23

//  Interface for the basic information for any account
interface IUser
{
	string FirstName {  get; set; }
	string LastName { get; set; }
	Guid AccountID { get; set; }
	string Email { get; set; }
	string Password { get; set; } //not addressing security
	string? Phone { get; set; }

}
