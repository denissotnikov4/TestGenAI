using System;
using Domain.SeedWork;

namespace Domain.Customers.Orders
{
    public class OrderId : TypedIdValueBase
    {
        public OrderId(Guid value) : base(value)
        {
        }
    }
}