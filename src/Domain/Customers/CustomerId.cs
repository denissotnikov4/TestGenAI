using System;
using Domain.SeedWork;

namespace Domain.Customers
{
    public class CustomerId : TypedIdValueBase
    {
        public CustomerId(Guid value) : base(value)
        {
        }
    }
}