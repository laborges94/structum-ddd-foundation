using Structum.Core.Abstractions;

namespace Structum.Core.Models;

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