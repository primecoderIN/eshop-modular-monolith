using MediatR;
namespace Shared.DDD;

public interface IDomainEvent : INotification //Comes from MediatR, we will use it to publish domain events
{
     Guid EventId => Guid.NewGuid();

    public DateTime OccuredOn => DateTime.Now;

    public string EventType => GetType().AssemblyQualifiedName!;
}
