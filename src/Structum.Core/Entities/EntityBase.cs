namespace Structum.Core.Entities;

/// <summary>
/// Base class for domain entities with a generic identifier type.
/// Provides identity-based equality semantics.
/// </summary>
/// <typeparam name="TId">
/// The type of the entity identifier.
/// Ensures that the entity identifier cannot be null.
/// </typeparam>
public abstract class EntityBase<TId> where TId : notnull
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
