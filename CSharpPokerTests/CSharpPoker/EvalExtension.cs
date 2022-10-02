using System.Collections.Concurrent;

namespace CSharpPoker;

public static class EvalExtension
{
    public static IEnumerable<KeyValuePair<CardValue, int>> ToKindAndQuantity(this IEnumerable<Card> cards)
    {
        var dict = new ConcurrentDictionary<CardValue, int>();
        foreach (var card in cards)
        {
            dict.AddOrUpdate(card.Value, 1, (cardValue, quantity) => ++quantity);
        }

        return dict;
    }
}