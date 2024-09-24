using System;
using SampleProject.Application.Configuration.Commands;

namespace SampleProject.Application.Users.RemoveUser;

public class RemoveUserCommand : CommandBase
{
    public Guid UserId { get; set; }

    public RemoveUserCommand(Guid userId)
    {
        UserId = userId;
    }
}