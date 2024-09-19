using System.ComponentModel.DataAnnotations;

namespace _2024_b1_individueel.Abstract;

/// <summary>
/// Base entity to extend all other entities from.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Unique identifier for this entity.
    /// </summary>
    [Key]
    public readonly string Identifier = Guid.NewGuid().ToString("N");
}
