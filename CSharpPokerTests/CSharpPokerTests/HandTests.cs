using System.Xml;
using CSharpPoker;
using FluentAssertions;

namespace CSharpPokerTests;

public class HandTests
{
    [Fact]
    public void CanCreateHand()
    {
        var hand = new Hand();
        hand.Cards.Should().BeEmpty();
    }

    [Fact]
    public void CanHandDrawCard()
    {
        var card = new Card(CardValue.Ace, CardSuit.Spades);
        var hand = new Hand();

        hand.Draw(card);
        hand.Cards.First().Should().Be(card);
    }

    [Fact]
    public void CanGetHighCard()
    {
        var hand = new Hand();
        hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));
        hand.HighCard().Value.Should().Be(CardValue.King);
    }
    
    [Fact]
    public void CanScoreHighCard()
    {
        var hand = new Hand();
        hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));
        hand.GetHandRank().Should().Be(HandRank.HighCard);
    }

    [Fact]
    public void CanScoreFlush()
    {
        var hand = new Hand();
        hand.Draw(new Card(CardValue.Two, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Three, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Five, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Six, CardSuit.Spades));
        hand.GetHandRank().Should().Be(HandRank.Flush);
    }
    [Fact]
    public void CanScoreRoyalFlush()
    {
        var hand = new Hand();
        hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Spades));
        hand.Draw(new Card(CardValue.King, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));
        hand.GetHandRank().Should().Be(HandRank.RoyalFlush);
    }
    
    [Fact]
    public void CanScorePair()
    {
        var hand = new Hand();
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Nine, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));
        hand.GetHandRank().Should().Be(HandRank.Pair);
    }

    [Fact]
    public void CanScoreThreeOfAKind()
    {
        var hand = new Hand();
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Nine, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
        hand.GetHandRank().Should().Be(HandRank.ThreeOfAKind);
    }
    [Fact]
    public void CanScoreFourOfAKind()
    {
        var hand = new Hand();
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
        hand.GetHandRank().Should().Be(HandRank.FourOfAKind);

    }
    [Fact]
    public void CanScoreFullHouse()
    {
        var hand = new Hand();
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
        hand.GetHandRank().Should().Be(HandRank.FullHouse);

    }
}