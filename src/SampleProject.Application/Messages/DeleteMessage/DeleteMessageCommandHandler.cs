using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleProject.Application.Exceptions;
using SampleProject.Application.Messages.Constants;
using SampleProject.Domain.Messages;

namespace SampleProject.Application.Messages.DeleteMessage;

public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, Unit>
{
    private readonly IMessageRepository _messageRepository;

    public DeleteMessageCommandHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
    {
        var message = await _messageRepository.GetByIdAsync(request.MessageId);

        if (message == null)
        {
            throw new EntityNotFoundException($"Message with id '{request.MessageId}' not found");
        }

        if (message.Role == LlamaMessageRole.Assistant)
        {
            throw new ForbiddenException($"Forbidden to delete the message with role '{LlamaMessageRole.Assistant}'");
        }

        await _messageRepository.DeleteAsync(request.MessageId);
        
        return Unit.Value;
    }
}