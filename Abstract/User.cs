namespace _2024_b1_individueel.Abstract;

/// <summary>
/// Represents a basic user of the application.
/// </summary>
public abstract class User : Entity
{
    /// <summary>
    /// The first name of this user
    /// </summary>
    public required string Firstname { get; set; }

    /// <summary>
    /// The surname of this user.
    /// </summary>
    public required string Surname { get; set; }

    /// <summary>
    /// The full name of this user.
    /// </summary>
    public string FullName => $"{Firstname} {Surname}";
}
