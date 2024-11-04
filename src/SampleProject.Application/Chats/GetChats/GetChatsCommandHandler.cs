using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleProject.Application.Chats.GetChats.Dto.Responses;
using SampleProject.Domain.Chats;

namespace SampleProject.Application.Chats.GetChats;

public class GetChatsCommandHandler : IRequestHandler<GetChatsCommand, GetChatsResponse>
{
    private readonly IChatRepository _chatRepository;

    public GetChatsCommandHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<GetChatsResponse> Handle(GetChatsCommand request, CancellationToken cancellationToken)
    {
        var chats = await _chatRepository.GetAllAsync();

        return new GetChatsResponse
        {
            Chats = chats
        };
    }
}