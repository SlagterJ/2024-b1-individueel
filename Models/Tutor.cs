using _2024_b1_individueel.Abstract;

namespace _2024_b1_individueel.Models;

/// <summary>
/// Represents a tutor that has many pupils.
/// </summary>
public class Tutor : User
{
    /// <summary>
    /// The 1:n relationship of pupils.
    /// </summary>
    public required List<Pupil> Pupils { get; set; } = [];
}
