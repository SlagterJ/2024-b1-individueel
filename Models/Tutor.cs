using _2024_b1_individueel.Abstract;

namespace _2024_b1_individueel.Models;

/// <summary>
/// Represents a tutor that has many pupils.
/// </summary>
public class Tutor : User
{
    /// <summary>
    /// The 0:n relationship of pupils.
    /// </summary>
    public List<Pupil> Pupils { get; set; } = [];
}
