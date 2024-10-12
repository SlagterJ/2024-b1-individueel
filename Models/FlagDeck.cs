using _2024_b1_individueel.Abstract;
using Microsoft.EntityFrameworkCore;

namespace _2024_b1_individueel.Models;

/// <summary>
/// Represents a deck of flags, 0:n of flags.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class FlagDeck : Entity
{
    /// <summary>
    /// Name of this FlagDeck.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The 0:n flags in this deck.
    /// </summary>
    public ICollection<Flag> Flags { get; set; } = [];

    /// <summary>
    /// The scores pupils have obtained with this deck.
    /// </summary>
    public ICollection<Score> Scores { get; set; } = [];

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

        return new FlagDeck() { Name = this.Name, Flags = flags };
    }
}
