using MediatR;
using Application;
using Application.Configuration.Commands;
using Infrastructure.Processing.Outbox;

namespace Infrastructure.Processing.InternalCommands
{
    internal class ProcessInternalCommandsCommand : CommandBase<Unit>, IRecurringCommand
    {

    }
}