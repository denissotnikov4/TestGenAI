using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SampleProject.Application.Configuration.Rule;
using SampleProject.Application.Tokens;
using SampleProject.Application.Users.RegisterUser.Dto.Responses;
using SampleProject.Domain.Users;
using SampleProject.Domain.Users.Rules;

namespace SampleProject.Application.Users.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IRuleChecker _ruleChecker;
    private readonly IUsernameUniquenessChecker _usernameUniquenessChecker;
    private readonly IUserRepository _userRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IJwtGenerator _jwtGenerator;

    public RegisterUserCommandHandler(
        IPasswordHasher<User> passwordHasher, 
        IRuleChecker ruleChecker, 
        IUsernameUniquenessChecker usernameUniquenessChecker, 
        IUserRepository userRepository, 
        UserManager<IdentityUser> userManager, 
        IJwtGenerator jwtGenerator)
    {
        _passwordHasher = passwordHasher;
        _ruleChecker = ruleChecker;
        _usernameUniquenessChecker = usernameUniquenessChecker;
        _userRepository = userRepository;
        _userManager = userManager;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        // TODO сделать правила что username должен быть уникальным

        var user = new IdentityUser
        {
            UserName = request.Username
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            return new RegisterUserResponse
            {
                Id = user.Id,
                Token = _jwtGenerator.CreateToken(user)
            };
        }

        // TODO сделать (RuleCheck) обработку на то, чтобы пароль был безопасный
        throw new Exception("Client creation failed");

        /*_ruleChecker.CheckRule(new UsernameMustBeUniqueRule(request.Username, _usernameUniquenessChecker));

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            CreatedAt = DateTime.UtcNow,
            Role = Role.User
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

        var createdUserId = await _userRepository.AddAsync(user);

        return new RegisterUserResponse { Id = createdUserId };*/
    }
}