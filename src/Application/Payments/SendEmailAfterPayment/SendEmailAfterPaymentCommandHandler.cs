using System.Threading;
using System.Threading.Tasks;
using Application.Configuration.Emails;
using MediatR;
using Application.Configuration.Commands;
using Application.Configuration.Emails;
using Domain.Payments;

namespace Application.Payments.SendEmailAfterPayment
{
    public class SendEmailAfterPaymentCommandHandler : ICommandHandler<SendEmailAfterPaymentCommand, Unit>
    {
        private readonly IEmailSender _emailSender;
        private readonly IPaymentRepository _paymentRepository;

        public SendEmailAfterPaymentCommandHandler(
            IEmailSender emailSender, 
            IPaymentRepository paymentRepository)
        {
            _emailSender = emailSender;
            _paymentRepository = paymentRepository;
        }

        public async Task<Unit> Handle(SendEmailAfterPaymentCommand request, CancellationToken cancellationToken)
        {
            // Logic of preparing an email. This is only mock.
            var emailMessage = new EmailMessage("from@email.com", "to@email.com", "content");

            await _emailSender.SendEmailAsync(emailMessage);

            var payment = await this._paymentRepository.GetByIdAsync(request.PaymentId);

            payment.MarkEmailNotificationIsSent();

            return Unit.Value;
        }
    }
}