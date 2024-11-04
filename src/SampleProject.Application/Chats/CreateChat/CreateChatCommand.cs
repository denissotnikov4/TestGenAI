using SampleProject.Application.Chats.CreateChat.Dto.Responses;
using SampleProject.Application.Configuration.Commands;

namespace SampleProject.Application.Chats.CreateChat;

public class CreateChatCommand : CommandBase<CreateChatResponse>
{
    public string Name { get; set; }

    public CreateChatCommand(string name)
    {
        Name = name;
    }
}