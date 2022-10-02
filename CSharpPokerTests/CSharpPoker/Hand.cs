namespace CSharpPoker;

public class Hand
{
    private readonly List<Card> cards = new List<Card>();
    public IEnumerable<Card> Cards => cards;
   
    public void Draw(Card card) => cards.Add(card);

    public Card HighCard() =>
        Cards.Aggregate((highCard, nextCard) 
            => nextCard.Value > highCard.Value ? nextCard : highCard);

    public HandRank GetHandRank() =>
        HasRoyalFlush() ? HandRank.RoyalFlush :
        HasFlush() ? HandRank.Flush :
        HasFullHouse() ? HandRank.FullHouse :
        HasFourOfAKind() ? HandRank.FourOfAKind :
        HasThreeOfAKind() ? HandRank.ThreeOfAKind :
        HasTwoPair() ? HandRank.TwoPair :
        HasPair() ? HandRank.Pair :
        HandRank.HighCard;

    private bool HasFlush() => cards.All(c => cards.First().Suit == c.Suit);

    private bool HasRoyalFlush() => HasFlush() && cards.All(c => c.Value > CardValue.Nine);

    private bool HasOfAKind(int num) => cards.ToKindAndQuantity().Any(c => c.Value == num);

    private int CountOfAKind(int num) => cards.ToKindAndQuantity().Count(c => c.Value == num);

    private bool HasPair() => HasOfAKind(2);
    private bool HasTwoPair() => CountOfAKind(2) == 2;
    private bool HasThreeOfAKind() => HasOfAKind(3);
    private bool HasFourOfAKind() => HasOfAKind(4);

    private bool HasFullHouse() => HasThreeOfAKind() && HasPair();

}