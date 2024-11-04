using System;

namespace SampleProject.Domain.Chats;

public class Chat
{
    public Guid ChatId { get; set; }

    public string Name { get; set; }
    
    public DateTime CreatedAt { get; set; }
}