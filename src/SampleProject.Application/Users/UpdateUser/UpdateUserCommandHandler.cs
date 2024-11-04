using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SampleProject.Application.Exceptions;
using SampleProject.Application.Users.Mappings;
using SampleProject.Application.Users.UpdateUser.Dto.Responses;
using SampleProject.Domain.Users;

namespace SampleProject.Application.Users.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UpdateUserCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.UserId);

        if (existingUser is null)
        {
            throw new EntityNotFoundException($"User with id {request.UserId} not found");
        }

        existingUser.Username = request.Username;
        existingUser.Email = request.Email;

        if (!string.IsNullOrEmpty(request.Password))
        {
            existingUser.PasswordHash = _passwordHasher.HashPassword(existingUser, request.Password);
        }

        await _userRepository.UpdateAsync(existingUser);

        return existingUser.ToUpdateUserResponse();
    }
}