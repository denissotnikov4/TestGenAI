using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleProject.Application.Users.GetUser.Dto.Responses;
using SampleProject.Domain.Users;

namespace SampleProject.Application.Users.GetUser;

public class GetUserCommandHandler : IRequestHandler<GetUserCommand, GetUserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserResponse> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        return new GetUserResponse
        {
            Username = user.Username,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
    }
}