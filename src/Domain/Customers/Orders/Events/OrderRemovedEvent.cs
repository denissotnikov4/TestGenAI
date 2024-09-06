using Domain.SeedWork;

namespace Domain.Customers.Orders.Events
{
    public class OrderRemovedEvent : DomainEventBase
    {
        public OrderId OrderId { get; }

        public OrderRemovedEvent(OrderId orderId)
        {
            this.OrderId = orderId;
        }
    }
}