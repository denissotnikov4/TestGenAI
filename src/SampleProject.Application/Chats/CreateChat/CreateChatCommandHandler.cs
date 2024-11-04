using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleProject.Application.Chats.CreateChat.Dto.Responses;
using SampleProject.Domain.Chats;

namespace SampleProject.Application.Chats.CreateChat;

public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, CreateChatResponse>
{
    private readonly IChatRepository _chatRepository;

    public CreateChatCommandHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }
    
    public async Task<CreateChatResponse> Handle(CreateChatCommand request, CancellationToken cancellationToken)
    {
        var chat = new Chat
        {
            ChatId = Guid.NewGuid(),
            Name = request.Name,
            CreatedAt = DateTime.UtcNow
        };

        await _chatRepository.AddAsync(chat);

        return new CreateChatResponse
        {
            ChatId = chat.ChatId,
        };
    }
}