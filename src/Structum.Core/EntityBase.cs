namespace Structum.Core;

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

/// <summary>
/// Base class for domain entities with a generic identifier type.
/// Provides identity-based equality semantics.
/// </summary>
/// <typeparam name="TId">The type of the entity identifier.</typeparam>
public abstract class EntityBase<TId>
{
    /// <summary>
    /// Gets the identifier of the entity.
    /// </summary>
    public TId Id { get; protected set; } = default!;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityBase{TId}"/> class.
    /// </summary>
    protected EntityBase() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityBase{TId}"/> class with the specified identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    protected EntityBase(TId id) => Id = id;

    /// <summary>
    /// Determines whether the specified object is equal to the current entity.
    /// Two entities are considered equal if they share the same identifier value.
    /// </summary>
    /// <param name="obj">The object to compare with the current entity.</param>
    /// <returns><c>true</c> if the specified object is equal to the current entity; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not EntityBase<TId> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (EqualityComparer<TId>.Default.Equals(Id, default))
            return false;

        return EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    /// <summary>
    /// Returns a hash code based on the entity identifier.
    /// </summary>
    public override int GetHashCode() => EqualityComparer<TId>.Default.GetHashCode(Id!);

    /// <summary>
    /// Determines whether two specified instances of <see cref="EntityBase{TId}"/> are equal.
    /// </summary>
    /// <param name="a">The first entity.</param>
    /// <param name="b">The second entity.</param>
    /// <returns><c>true</c> if the two entities are equal; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// Equality is determined by comparing the entity identifiers.
    /// This operator delegates to <see cref="Equals(object?)"/>.
    /// </remarks>
    /// <seealso cref="Equals(object?)"/>
    public static bool operator ==(EntityBase<TId>? a, EntityBase<TId>? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    /// <summary>
    /// Determines whether two specified instances of <see cref="EntityBase{TId}"/> are not equal.
    /// </summary>
    /// <param name="a">The first entity.</param>
    /// <param name="b">The second entity.</param>
    /// <returns><c>true</c> if the two entities are not equal; otherwise, <c>false</c>.</returns>
    /// <remarks> This operator returns the negation of the equality operator. </remarks>
    /// <seealso cref="operator ==(EntityBase{TId}?, EntityBase{TId}?)"/>
    public static bool operator !=(EntityBase<TId>? a, EntityBase<TId>? b) => !(a == b);
}
