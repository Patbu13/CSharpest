namespace CSharpest.Classes;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/12/23

//  Interaction with the main page of the storefront (not sure if will need)

// Make this a singleton. 
public static class Storefront
{
    public static Dictionary<Item, int> Stock {  get; set; }

}
