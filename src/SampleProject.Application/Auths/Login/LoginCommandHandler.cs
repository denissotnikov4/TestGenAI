using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SampleProject.Application.Auths.Login.Dto.Responses;
using SampleProject.Application.Tokens;

namespace SampleProject.Application.Auths.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IJwtGenerator _jwtGenerator;

    public LoginCommandHandler(
        UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager, 
        IJwtGenerator jwtGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Username);

        if (user is null)
        {
            // TODO кинуть ошибку
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return new LoginResponse
            {
                Username = user.UserName,
                Token = _jwtGenerator.CreateToken(user)
            };
        }

        throw new UnauthorizedAccessException();
    }
}