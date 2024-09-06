using System;
using Domain.SeedWork;

namespace Domain.Payments
{
    public class PaymentId : TypedIdValueBase
    {
        public PaymentId(Guid value) : base(value)
        {
        }
    }
}