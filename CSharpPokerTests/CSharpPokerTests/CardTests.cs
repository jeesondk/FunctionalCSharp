using CSharpPoker;
using FluentAssertions;

namespace CSharpPokerTests;

public class CardTests
{
    [Fact]
    public void CanCreateCard()
    {
        var card = new Card();
        card.Should().NotBeNull();
    }

    [Fact]
    public void CanCreateCardWithValue()
    {
        var card = new Card(CardValue.Eight, CardSuit.Clubs);

        card.Suit.Should().Be(CardSuit.Clubs);
        card.Value.Should().Be(CardValue.Eight);

    }

    [Fact]
    public void CanDescribeCard()
    {
        var card = new Card(CardValue.Ace, CardSuit.Spades);
        card.ToString().Should().Be("Ace of Spades");
    }
}