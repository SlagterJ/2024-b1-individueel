using _2024_b1_individueel.Abstract;

namespace _2024_b1_individueel.Models;

/// <summary>
/// Represents a score achieved by a pupil.
/// </summary>
public class Score : Entity
{
    /// <summary>
    /// The pupil that achieved this score.
    /// </summary>
    public string? AchievedBy { get; set; }

    /// <summary>
    /// The score that this pupil achieved.
    /// </summary>
    public int? AchievedScore { get; set; }

    /// <summary>
    /// The flag deck on which this score was achieved.
    /// </summary>
    public FlagDeck? FlagDeck { get; set; }

    /// <summary>
    /// The grade achieved for this score
    /// </summary>
    //tex:
    //$ x = \frac{s}{T} \cdot 100 $
    public int? AchievedGrade => (AchievedScore / FlagDeck.Flags.Count) * 10;
}
