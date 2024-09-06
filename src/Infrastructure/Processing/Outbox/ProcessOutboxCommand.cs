using MediatR;
using Application;
using Application.Configuration.Commands;

namespace Infrastructure.Processing.Outbox
{
    public class ProcessOutboxCommand : CommandBase<Unit>, IRecurringCommand
    {

    }
}