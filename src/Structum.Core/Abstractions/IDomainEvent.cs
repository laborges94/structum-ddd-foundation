namespace Structum.Core.Abstractions;

public interface IDomainEvent
{
    /// <summary>
    /// Gets the timestamp when the domain event occurred.
    /// </summary>
    DateTime OccurredOn { get; }
}