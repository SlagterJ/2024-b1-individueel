using _2024_b1_individueel.Abstract;

namespace _2024_b1_individueel.Models;

/// <summary>
/// Represents a country's flag.
/// </summary>
/// <param name="_correctAnswers"></param>
public class Flag(string countryCode, Lst<string> correctAnswers) : Entity
{
    /// <summary>
    /// Country code for this flag, also used to generate the svg url.
    /// </summary>
    public readonly string CountryCode = countryCode;

    /// <summary>
    /// A list of correct answers for this flag.
    /// </summary>
    public readonly Lst<string> CorrectAnswers = correctAnswers;

    /// <summary>
    /// The URL for the SVG file of this flag (from flagcdn.com).
    /// </summary>
    public string ImageURL => $"https://flagcdn.com/{CountryCode}.svg";
}
