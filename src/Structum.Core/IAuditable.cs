namespace Structum.Core;

/// <summary>
/// Defines an interface for auditable entities, providing properties and methods for tracking creation, update, and deletion information.
/// </summary>
public interface IAuditable
{
    /// <summary>
    /// Gets the audit information for the entity.
    /// </summary>
    AuditInfo AuditInfo { get; }

    /// <summary>
    /// Marks the entity as updated with the specified user.
    /// </summary>
    /// <param name="updatedBy">The user who updated the entity.</param>
    void MarkAsUpdated(string updatedBy);

    /// <summary>
    /// Marks the entity as deleted with the specified user.
    /// </summary>
    /// <param name="deletedBy">The user who deleted the entity.</param>
    void MarkAsDeleted(string deletedBy);
}