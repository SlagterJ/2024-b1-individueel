namespace _2024_b1_individueel.Models;

/// <summary>
/// Represents a pupil that has a tutor.
/// </summary>
public class Pupil
{
    /// <summary>
    /// This pupil's tutor.
    /// </summary>
    public required Tutor Tutor { get; set; }

    /// <summary>
    /// The scores achieved by this pupil.
    /// </summary>
    public required List<Score> Scores { get; set; } = [];
}
