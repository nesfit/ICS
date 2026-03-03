namespace CookBook.DAL.Repositories;

public sealed class EntityNotFoundException(Type entityType, Guid entityId)
    : KeyNotFoundException($"Entity '{entityType.Name}' with id '{entityId}' was not found.")
{
    public Type EntityType { get; } = entityType;
    public Guid EntityId { get; } = entityId;
}
