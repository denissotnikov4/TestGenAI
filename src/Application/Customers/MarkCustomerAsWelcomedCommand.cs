using System;
using Application.Configuration.Commands;
using MediatR;
using Newtonsoft.Json;
using Domain.Customers;

namespace Application.Customers
{
    public class MarkCustomerAsWelcomedCommand : InternalCommandBase<Unit>
    {
        [JsonConstructor]
        public MarkCustomerAsWelcomedCommand(Guid id, CustomerId customerId) : base(id)
        {
            CustomerId = customerId;
        }

        public CustomerId CustomerId { get; }
    }
}