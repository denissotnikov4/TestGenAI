using System.Threading.Tasks;
using Application.Configuration.Commands;

namespace Application.Configuration.Processing
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync<T>(ICommand<T> command);
    }
}