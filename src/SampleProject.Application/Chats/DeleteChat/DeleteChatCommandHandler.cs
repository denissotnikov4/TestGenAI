using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleProject.Domain.Chats;

namespace SampleProject.Application.Chats.DeleteChat;

public class DeleteChatCommandHandler : IRequestHandler<DeleteChatCommand, Unit>
{
    private readonly IChatRepository _chatRepository;

    public DeleteChatCommandHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<Unit> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
    {
        await _chatRepository.DeleteAsync(request.ChatId);
        
        return Unit.Value;
    }
}