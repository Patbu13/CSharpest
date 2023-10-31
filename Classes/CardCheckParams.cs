namespace CSharpest.Classes
{
    public class CardCheckParams
    {
        public User User { get; set; }
        public Card Card { get; set; }  

        public CardCheckParams(User _user, Card _card)
        {
            User = _user;
            Card = _card;
        }
    }
}
