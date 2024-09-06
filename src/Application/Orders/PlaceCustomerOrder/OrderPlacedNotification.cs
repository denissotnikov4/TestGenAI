using Newtonsoft.Json;
using Application.Configuration.DomainEvents;
using Domain.Customers;
using Domain.Customers.Orders;
using Domain.Customers.Orders.Events;

namespace Application.Orders.PlaceCustomerOrder
{
    public class OrderPlacedNotification : DomainNotificationBase<OrderPlacedEvent>
    {
        public OrderId OrderId { get; }
        public CustomerId CustomerId { get; }

        public OrderPlacedNotification(OrderPlacedEvent domainEvent) : base(domainEvent)
        {
            this.OrderId = domainEvent.OrderId;
            this.CustomerId = domainEvent.CustomerId;
        }

        [JsonConstructor]
        public OrderPlacedNotification(OrderId orderId, CustomerId customerId) : base(null)
        {
            this.OrderId = orderId;
            this.CustomerId = customerId;
        }
    }
}