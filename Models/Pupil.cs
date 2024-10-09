using _2024_b1_individueel.Abstract;

namespace _2024_b1_individueel.Models;

/// <summary>
/// Represents a pupil that has a tutor.
/// </summary>
public class Pupil : User
{
    /// <summary>
    /// This pupil's tutor.
    /// </summary>
    public required Tutor Tutor { get; set; }

    /// <summary>
    /// The scores achieved by this pupil.
    /// </summary>
    public List<Score> Scores { get; set; } = [];
}
