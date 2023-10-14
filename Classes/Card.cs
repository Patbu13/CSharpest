namespace CSharpest.Classes;

//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/12/23
    
//  Stores user credit/debit card information
public class Card
{
    public int Number {  get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public string Name { get; set; }
    public int CVV { get; set; }
    public Card(int number, int month, int year, string name, int cVV)
    {
        Number = number;
        Month = month;
        Year = year;
        Name = name;
        CVV = cVV;
    }
}
