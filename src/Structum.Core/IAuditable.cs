namespace Structum.Core;

/// <summary>
/// Defines a contract for entities that support audit tracking,
/// including creation and update metadata.
/// </summary>
public interface IAuditable
{
    /// <summary>
    /// Gets the audit metadata associated with the entity,
    /// including creation and update information.
    /// </summary>
    AuditInfo AuditInfo { get; }

    /// <summary>
    /// Marks the entity as created by the specified user.
    /// </summary>
    /// <param name="createdBy">The user responsible for creating the entity.</param>
    void MarkAsCreated(string createdBy);

    /// <summary>
    /// Marks the entity as updated with the specified user.
    /// </summary>
    /// <param name="updatedBy">The user who updated the entity.</param>
    void MarkAsUpdated(string updatedBy);
}