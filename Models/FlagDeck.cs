using _2024_b1_individueel.Abstract;

namespace _2024_b1_individueel.Models;

/// <summary>
/// Represents a deck of flags, 1:n of flags.
/// </summary>
public class FlagDeck : Entity
{
    /// <summary>
    /// The 1:n flags in this deck.
    /// </summary>
    public required Queue<Flag> Flags { get; set; }

    /// <summary>
    /// Shuffles the flags, returns a new FlagDeck with shuffled flags.
    /// </summary>
    /// <returns>A new FlagDeck with shuffled flags.</returns>
    public FlagDeck Shuffle()
    {
        // TODO: make this method use immutable values
        var random = new Random();
        var flags = Flags.ToList();

        var count = flags.Count;

        while (count > 0)
        {
            count--;
            var firstSpot = count;
            var secondSpot = random.Next(0, count + 1);
            var flagToSwap = flags[firstSpot]!;
            flags[firstSpot] = flags[secondSpot];
            flags[secondSpot] = flagToSwap;
        }

        return new FlagDeck() { Flags = new Queue<Flag>(flags) };
    }
}
