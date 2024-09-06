using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Configuration.Processing;
using MediatR;
using Application.Payments.SendEmailAfterPayment;

namespace Application.Payments
{
    public class PaymentCreatedNotificationHandler : INotificationHandler<PaymentCreatedNotification>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        public PaymentCreatedNotificationHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Handle(PaymentCreatedNotification request, CancellationToken cancellationToken)
        {
            await _commandsScheduler.EnqueueAsync(
                new SendEmailAfterPaymentCommand(Guid.NewGuid(), request.PaymentId));
        }
    }
}