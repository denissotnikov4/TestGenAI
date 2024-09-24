using Microsoft.AspNetCore.Identity;

namespace SampleProject.Application.Tokens;

public interface IJwtGenerator
{
    string CreateToken(IdentityUser user);
}