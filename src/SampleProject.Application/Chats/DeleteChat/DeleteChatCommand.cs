using System;
using SampleProject.Application.Configuration.Commands;

namespace SampleProject.Application.Chats.DeleteChat;

public class DeleteChatCommand : CommandBase
{
    public Guid ChatId { get; set; }

    public DeleteChatCommand(Guid chatId)
    {
        ChatId = chatId;
    }
}