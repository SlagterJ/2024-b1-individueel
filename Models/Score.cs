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
    public required Pupil AchievedBy { get; set; }

    /// <summary>
    /// The score that this pupil achieved.
    /// </summary>
    public required int AchievedScore { get; set; }

    /// <summary>
    /// The flag deck on which this score was achieved.
    /// </summary>
    public required FlagDeck FlagDeck { get; set; }
}
