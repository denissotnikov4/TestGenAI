using SampleProject.Application.Users.GetUser.Dto.Responses;
using SampleProject.Application.Users.UpdateUser.Dto.Responses;
using SampleProject.Domain.Users;

namespace SampleProject.Application.Users.Mappings;

public static class UserMappings
{
    public static GetUserResponse ToGetUserResponse(this User user)
    {
        return new GetUserResponse
        {
            Username = user.Username,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
    }

    public static UpdateUserResponse ToUpdateUserResponse(this User user)
    {
        return new UpdateUserResponse
        {
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email
        };
    }
}