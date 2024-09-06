using System;
using MediatR;
using Newtonsoft.Json;
using Application.Configuration.Commands;
using Domain.Payments;

namespace Application.Payments.SendEmailAfterPayment
{
    public class SendEmailAfterPaymentCommand : InternalCommandBase<Unit>
    {
        public PaymentId PaymentId { get; }

        [JsonConstructor]
        public SendEmailAfterPaymentCommand(Guid id, PaymentId paymentId) : base(id)
        {
            this.PaymentId = paymentId;
        }
    }
}