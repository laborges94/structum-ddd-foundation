using Structum.Core.SoftDeletion;

namespace Structum.Core.Abstractions;

/// <summary>
/// Defines a contract for entities that support soft deletion.
/// Soft deletion preserves the entity data while marking it as logically removed.
/// </summary>
public interface ISoftDeletable
{
    /// <summary>
    /// Gets the soft deletion metadata associated with the entity.
    /// </summary>
    SoftDeleteInfo SoftDeleteInfo { get; }

    /// <summary>
    /// Marks the entity as soft-deleted by the specified user.
    /// </summary>
    /// <param name="deletedBy">The user responsible for deleting the entity.</param>
    void MarkAsDeleted(string deletedBy);
}