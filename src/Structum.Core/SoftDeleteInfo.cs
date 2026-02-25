namespace Structum.Core;

/// <summary>
/// Represents immutable soft deletion metadata for an entity.
/// Indicates whether the entity has been logically deleted,
/// preserving its data while marking it as removed.
/// </summary>
public sealed record SoftDeleteInfo
{
    /// <summary>
    /// Gets the date and time when the entity was soft-deleted.
    /// </summary>
    public DateTime? DeletedAt { get; private init; }
    /// <summary>
    /// Gets the user responsible for soft-deleting the entity.
    /// </summary>
    public string? DeletedBy { get; private init; }
    /// <summary>
    /// Gets a value indicating whether the entity has been soft-deleted.
    /// </summary>
    public bool IsDeleted => DeletedAt.HasValue;

    /// <summary>
    /// Initializes a new immutable <see cref="SoftDeleteInfo"/> instance.
    /// Intended to be used internally by factory methods.
    /// </summary>
    private SoftDeleteInfo(
        DateTime? deletedAt = null,
        string? deletedBy = null)
    {
        DeletedAt = deletedAt;
        DeletedBy = deletedBy;
    }

    /// <summary>
    /// Creates a new <see cref="SoftDeleteInfo"/> instance,
    /// setting the deletion timestamp to <see cref="DateTime.UtcNow"/>.
    /// </summary>
    /// <param name="deletedBy">The user responsible for the deletion.</param>
    /// <returns>A new immutable <see cref="SoftDeleteInfo"/> instance.</returns>
    public static SoftDeleteInfo Create(string? deletedBy = null)
        => new(DateTime.UtcNow, deletedBy);
}