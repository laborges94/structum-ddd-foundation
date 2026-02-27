using Structum.Core.Abstractions;
using Structum.Core.Audition;
using Structum.Core.Entities;
using Structum.Core.SoftDeletion;

namespace Structum.Core.Models;

/// <summary>
/// Base class for domain entities identified by a <see cref="Guid"/>.
/// Provides built-in support for auditing (<see cref="IAuditable"/>) 
/// and soft deletion (<see cref="ISoftDeletable"/>).
/// </summary>
public abstract class EntityBase : 
    EntityBase<Guid>, 
    IAuditable,
    ISoftDeletable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityBase"/> class with a new <see cref="Guid"/> identifier.
    /// </summary>
    protected EntityBase() => Id = Guid.NewGuid();

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityBase"/> class with the specified <see cref="Guid"/> identifier.
    /// </summary>
    protected EntityBase(Guid id) : base(id) { }

    /// <summary>
    /// Gets the audit information for the entity.
    /// </summary>
    public AuditInfo AuditInfo { get; protected set; } = AuditInfo.Create();

    /// <summary>
    /// Gets the soft delete metadata for the entity.
    /// </summary>
    public SoftDeleteInfo SoftDeleteInfo { get; protected set; } = SoftDeleteInfo.Create();

    /// <summary>
    /// Marks the entity as created by the specified user.
    /// Resets the audit information with creation metadata.
    /// </summary>
    /// <param name="createdBy">The user responsible for creating the entity.</param>
    public void MarkAsCreated(string createdBy) => 
        AuditInfo = AuditInfo.Create(createdBy);

    /// <summary>
    /// Marks the entity as soft-deleted by the specified user.
    /// </summary>
    /// <param name="deletedBy">The user responsible for deleting the entity.</param>
    public void MarkAsDeleted(string deletedBy) => 
        SoftDeleteInfo = SoftDeleteInfo.Create(deletedBy);

    /// <summary>
    /// Marks the entity as updated with the specified user.
    /// </summary>
    /// <param name="updatedBy">The user who updated the entity.</param>
    public void MarkAsUpdated(string updatedBy) =>
        AuditInfo = AuditInfo.WithUpdated(updatedBy);
}