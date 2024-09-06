using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Configuration.Commands;
using Domain.Customers.Orders;

namespace Application.Customers.IntegrationHandlers
{
    public class MarkCustomerAsWelcomedCommandHandler : ICommandHandler<MarkCustomerAsWelcomedCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public MarkCustomerAsWelcomedCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(MarkCustomerAsWelcomedCommand command, CancellationToken cancellationToken)
        {
            var customer = await this._customerRepository.GetByIdAsync(command.CustomerId);

            customer.MarkAsWelcomedByEmail();

            return Unit.Value;
        }
    }
}