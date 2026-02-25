namespace Structum.Core;

/// <summary>
/// Represents immutable audit metadata for an entity,
/// including creation and last update information.
/// </summary>
public sealed record AuditInfo
{
    /// <summary>
    /// Gets the date and time when the entity was created.
    /// </summary>
    public DateTime? CreatedAt { get; private init; }
    /// <summary>
    /// Gets the user who created the entity.
    /// </summary>
    public string? CreatedBy { get; private init; }
    /// <summary>
    /// Gets the date and time when the entity was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; private init; }
    /// <summary>
    /// Gets the user who last updated the entity.
    /// </summary>
    public string? UpdatedBy { get; private init; }

    /// <summary>
    /// Initializes a new immutable <see cref="AuditInfo"/> instance.
    /// Intended to be used internally by factory methods.
    /// </summary>
    /// <param name="createdAt">The date and time when the entity was created.</param>
    /// <param name="createdBy">The user who created the entity.</param>
    /// <param name="updatedAt">The date and time when the entity was last updated.</param>
    /// <param name="updatedBy">The user who last updated the entity.</param>
    private AuditInfo(
        DateTime? createdAt,
        string? createdBy,
        DateTime? updatedAt = null,
        string? updatedBy = null)
    {
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        UpdatedAt = updatedAt;
        UpdatedBy = updatedBy;
    }

    /// <summary>
    /// Creates a new <see cref="AuditInfo"/> instance,
    /// setting the creation timestamp to <see cref="DateTime.UtcNow"/>.
    /// </summary>
    /// <param name="createdBy">The user responsible for creating the entity.</param>
    /// <returns>A new immutable <see cref="AuditInfo"/> instance.</returns>
    public static AuditInfo Create(string? createdBy = null) =>
        new(DateTime.UtcNow, createdBy);

    /// <summary>
    /// Returns a new <see cref="AuditInfo"/> instance with updated metadata,
    /// setting the update timestamp to <see cref="DateTime.UtcNow"/>.
    /// </summary>
    /// <param name="updatedBy">The user responsible for the update.</param>
    /// <returns>A new immutable <see cref="AuditInfo"/> instance with updated values.</returns>
    public AuditInfo WithUpdated(string? updatedBy = null) =>
        this with { UpdatedAt = DateTime.UtcNow, UpdatedBy = updatedBy };
}