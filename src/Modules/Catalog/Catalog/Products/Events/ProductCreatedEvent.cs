namespace Catalog.Products.Events;

public record ProductCreatedEvent(Product Product) : IDomainEvent;



//Records are preferred because 
//1. They are immutable by default, which is a good fit for events that should not change after they are created.
//2. They provide built-in value-based equality, which means that two events with the same data will be considered equal, making it easier to compare and test events.