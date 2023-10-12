using System;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/5/23
public class User
{
	//basic fields
	public string FirstName {  get; set; }
	public string LastName { get; set; }
	public Guid AccountID { get; set; }
	public string Email { get; set; }
	public int Phone { get; set; }
	public string Password { get; set; } //not worrying about security ?
	public string Address { get; set; }
	/*
	 * public Cart UserCart { get; set; }
	 * public List<Card> UserCards { get; set; }
	 * public List<Transaction> TransHistory { get; set; }
	 */

	
	public User()
	{
		AccountID = Guid.NewGuid();
	}
}
