namespace CSharpest.Classes;

//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 10/25/23

//  Manages the checkout procedure from cart -> transaction (not sure if needed)
public class Checkout
{
    private const decimal tax = 1.08m; // flat rate of 8% (for now)
    private const decimal shipping = 5.99m; // flat rate of $5.99

    public Checkout()
	{
		
	}

	public decimal calculateTotal(Cart cart)
	{
        decimal total = 0;
		for (int i = 0; i < cart.Items.Count; i++)
		{
			KeyValuePair<CartItem, int> Item = cart.Items.ElementAt(i);

			// adds to total the cost of each item, times the quantity of that item
			total += ((Item.Key.Item.Price) * (Item.Key.Quantity));
		}

		// adds tax to total; flat rate of 8% (for now)
		total += (total * 1.08m);

		// calculate shipping; for now flat rate of 5.99
		total += 5.99m;

		return total;
	}

	public bool validateCardInput(Card card)
	{
		// checks for valid credit card number length
		if (card.Number.ToString().Length > 19 || card.Number.ToString().Length < 16)
		{
			return false;
		}

		// checks for valid month

		if (card.Month < 1 || card.Month > 12)
		{
			return false;
		}

        // checks for valid year

        if (card.Year <= 2022 || card.Year > 2100)
        {
            return false;
        }

		if (card.CVV.ToString().Length != 3 || card.CVV.ToString().Length != 4)
		{
			return false; 
		}
        return true;
	}

	// takes in a new card and then saves it to user object
	public bool takeCardInput(Card card, User user)
	{
		if (validateCardInput(card))
		{
            // if card validation successful, save to user's list of cards
            if (!(user.UserCards.Contains(card)))
			{
                user.UserCards.Add(card);
			}
			// otherwise, validation is still successful
			return true;
		}

		// if not valid, returns false
		return false;
	}

	public bool handlePurchase(Cart cart, User user)
	{
		// reduce stock by quantity purchased

		// save this transaction to user's history

		return true;
	}


}
