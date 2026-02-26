namespace Structum.Core;

/// <summary>
/// Base class for aggregate roots identified by a <see cref="Guid"/>.
/// Inherits identity, auditing, and soft deletion support from <see cref="EntityBase"/>.
/// </summary>
public abstract class AggregateRoot :
    EntityBase,
    IAggregateRoot
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
    /// </summary>
    protected AggregateRoot() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot"/> class
    /// with the specified identifier.
    /// </summary>
    /// <param name="id">The aggregate root identifier.</param>
    protected AggregateRoot(Guid id) : base(id) { }
}

/// <summary>
/// Base class for aggregate roots with a generic identifier type.
/// Provides identity-based equality semantics through <see cref="EntityBase{TId}"/>.
/// </summary>
/// <typeparam name="TId">
/// The type of the aggregate root identifier.
/// Ensures that the aggregate root identifier cannot be null.
/// </typeparam>
public abstract class AggregateRoot<TId> :
    EntityBase<TId>,
    IAggregateRoot
    where TId : notnull
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{TId}"/> class.
    /// </summary>
    protected AggregateRoot() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{TId}"/> class
    /// with the specified identifier.
    /// </summary>
    /// <param name="id">The aggregate root identifier.</param>
    protected AggregateRoot(TId id) : base(id) { }
}