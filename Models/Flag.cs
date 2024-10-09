using _2024_b1_individueel.Abstract;

namespace _2024_b1_individueel.Models;

/// <summary>
/// Represents a country's or institution's flag.
/// </summary>
public class Flag : Entity
{
    /// <summary>
    /// Country code for this flag, also used to generate the SVG URL.
    /// </summary>
    public required string CountryCode { get; set; }

    /// <summary>
    /// A list of correct answers for this flag.
    /// </summary>
    public required List<string> CorrectAnswers { get; set; }

    /// <summary>
    /// The deck this flag is a part of.
    /// </summary>
    public FlagDeck? InDeck { get; set; }

    /// <summary>
    /// The URL for the SVG file of this flag (from flagcdn.com).
    /// </summary>
    public string ImageURL => $"https://flagcdn.com/{CountryCode}.svg";
}
