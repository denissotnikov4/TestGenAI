using System;
using MediatR;
using Application.Configuration.Queries;

namespace Application.Orders.GetCustomerOrderDetails
{
    public class GetCustomerOrderDetailsQuery : IQuery<OrderDetailsDto>
    {
        public Guid OrderId { get; }

        public GetCustomerOrderDetailsQuery(Guid orderId)
        {
            this.OrderId = orderId;
        }
    }
}