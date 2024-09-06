using System.Threading;
using System.Threading.Tasks;
using Application.Configuration.Commands;
using MediatR;
using Domain.Customers;
using Domain.Customers.Orders;

namespace Application.Orders.RemoveCustomerOrder
{
    public class RemoveCustomerOrderCommandHandler : ICommandHandler<RemoveCustomerOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public RemoveCustomerOrderCommandHandler(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(RemoveCustomerOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await this._customerRepository.GetByIdAsync(new CustomerId(request.CustomerId));

            customer.RemoveOrder(new OrderId(request.OrderId));

            return Unit.Value;
        }
    }
}