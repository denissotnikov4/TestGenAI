using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleProject.Application.Exceptions;
using SampleProject.Domain.Chats;

namespace SampleProject.Application.Chats.UpdateChat;

public class UpdateChatCommandHandler : IRequestHandler<UpdateChatCommand>
{
    private readonly IChatRepository _chatRepository;

    public UpdateChatCommandHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<Unit> Handle(UpdateChatCommand request, CancellationToken cancellationToken)
    {
        var existingChat = await _chatRepository.GetByIdAsync(request.ChatId);

        if (existingChat is null)
        {
            throw new EntityNotFoundException($"Chat with id '{request.ChatId}' not found");
        }

        var chat = new Chat
        {
            ChatId = existingChat.ChatId,
            Name = request.Name,
            CreatedAt = existingChat.CreatedAt
        };

        await _chatRepository.UpdateAsync(chat);
        
        return Unit.Value;
    }
}