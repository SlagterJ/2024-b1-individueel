using _2024_b1_individueel.Abstract;
using Microsoft.EntityFrameworkCore;

namespace _2024_b1_individueel.Models;

/// <summary>
/// Represents a country's or institution's flag.
/// </summary>
[Index(nameof(CountryCode), IsUnique = true)]
public class Flag : Entity
{
    /// <summary>
    /// Country code for this flag, also used to generate the SVG URL.
    /// </summary>
    public required string CountryCode { get; set; }

    /// <summary>
    /// A list of correct answers for this flag.
    /// </summary>
    public required string CorrectAnswer { get; set; }

    /// <summary>
    /// The flagdeck to which this flag belongs.
    /// </summary>
    public required FlagDeck FlagDeck { get; set; }

    /// <summary>
    /// The URL for the SVG file of this flag (from flagcdn.com).
    /// </summary>
    public string ImageURL => $"https://flagcdn.com/{CountryCode}.svg";
}
