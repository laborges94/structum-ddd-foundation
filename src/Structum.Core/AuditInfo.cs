namespace Structum.Core;

/// <summary>
/// Represents audit information for an entity, including creation, update, and deletion details.
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
    /// Gets the date and time when the entity was deleted.
    /// </summary>
    public DateTime? DeletedAt { get; private init; }
    /// <summary>
    /// Gets the user who deleted the entity.
    /// </summary>
    public string? DeletedBy { get; private init; }
    /// <summary>
    /// Gets a value indicating whether the entity is deleted.
    /// </summary>
    public bool IsDeleted => DeletedAt.HasValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditInfo"/> with the specified audit details.
    /// </summary>
    /// <param name="createdAt">The date and time when the entity was created.</param>
    /// <param name="createdBy">The user who created the entity.</param>
    /// <param name="updatedAt">The date and time when the entity was last updated.</param>
    /// <param name="updatedBy">The user who last updated the entity.</param>
    /// <param name="deletedAt">The date and time when the entity was deleted.</param>
    /// <param name="deletedBy">The user who deleted the entity.</param>
    private AuditInfo(
        DateTime? createdAt, 
        string? createdBy, 
        DateTime? updatedAt = null, 
        string? updatedBy = null,
        DateTime? deletedAt = null,
        string? deletedBy = null)
    {
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        UpdatedAt = updatedAt;
        UpdatedBy = updatedBy;
        DeletedAt = deletedAt;
        DeletedBy = deletedBy;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="AuditInfo"/> with the specified creation details.
    /// </summary>
    /// <param name="createdBy">The user who created the entity.</param>
    /// <returns>A new instance of the <see cref="AuditInfo"/>.</returns>
    public static AuditInfo Create(string? createdBy = null) =>
        new(DateTime.UtcNow, createdBy);

    /// <summary>
    /// Returns a instance of the <see cref="AuditInfo"/> with updated audit details.
    /// </summary>
    /// <param name="updatedBy">The user who last updated the entity.</param>
    /// <returns>A instance of the <see cref="AuditInfo"/> with updated audit details.</returns>
    public AuditInfo WithUpdated(string? updatedBy = null) =>
        this with { UpdatedAt = DateTime.UtcNow, UpdatedBy = updatedBy };

    /// <summary>
    /// Returns a instance of the <see cref="AuditInfo"/> with deleted audit details.
    /// </summary>
    /// <param name="deletedBy">The user who deleted the entity.</param>
    /// <returns>A instance of the <see cref="AuditInfo"/> with deleted audit details.</returns>
    public AuditInfo WithDeleted(string? deletedBy = null) =>
        this with { DeletedAt = DateTime.UtcNow, DeletedBy = deletedBy };
}