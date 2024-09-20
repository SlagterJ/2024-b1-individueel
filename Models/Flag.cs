using _2024_b1_individueel.Abstract;

namespace _2024_b1_individueel.Models;

/// <summary>
/// Represents a country's flag.
/// </summary>
/// <param name="countryCode">The country code. Check its validity using https://flagcdn.com/.</param>
/// <param name="correctAnswers">The correct answers to this flag.</param>
public class Flag(string countryCode, List<string> correctAnswers) : Entity
{
    /// <summary>
    /// Country code for this flag, also used to generate the SVG URL.
    /// </summary>
    public string CountryCode { get; set; } = countryCode;

    /// <summary>
    /// A list of correct answers for this flag.
    /// </summary>
    public List<string> CorrectAnswers { get; set; } = correctAnswers;

    /// <summary>
    /// The URL for the SVG file of this flag (from flagcdn.com).
    /// </summary>
    public string ImageURL => $"https://flagcdn.com/{CountryCode}.svg";
}
