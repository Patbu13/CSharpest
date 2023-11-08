namespace CSharpest.Classes
{
    public class CardCheckParams
    {
        public Shopper User { get; set; }
        public Card Card { get; set; }  

        public CardCheckParams(Shopper _user, Card _card)
        {
            User = _user;
            Card = _card;
        }
    }
}
