using System;
using SampleProject.Application.Chats.GetChat.Dto.Responses;
using SampleProject.Application.Configuration.Commands;

namespace SampleProject.Application.Chats.GetChat;

public class GetChatCommand : CommandBase<GetChatResponse>
{
    public Guid ChatId { get; set; }

    public GetChatCommand(Guid chatId)
    {
        ChatId = chatId;
    }
}