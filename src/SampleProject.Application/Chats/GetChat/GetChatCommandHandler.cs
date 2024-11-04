using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleProject.Application.Chats.GetChat.Dto.Responses;
using SampleProject.Application.Exceptions;
using SampleProject.Domain.Chats;

namespace SampleProject.Application.Chats.GetChat;

public class GetChatCommandHandler : IRequestHandler<GetChatCommand, GetChatResponse>
{
    private readonly IChatRepository _chatRepository;

    public GetChatCommandHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<GetChatResponse> Handle(GetChatCommand request, CancellationToken cancellationToken)
    {
        var chat = await _chatRepository.GetByIdAsync(request.ChatId);

        if (chat is null)
        {
            throw new EntityNotFoundException($"Chat with id '{request.ChatId}' not found");
        }

        return new GetChatResponse
        {
            Name = chat.Name,
            CreatedAt = chat.CreatedAt
        };

    }
}