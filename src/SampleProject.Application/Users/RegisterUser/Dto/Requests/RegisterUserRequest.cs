using System.ComponentModel.DataAnnotations;

namespace SampleProject.Application.Users.RegisterUser.Dto.Requests;

public record struct RegisterUserRequest
{
    [Required]
    public required string Username { get; init; }

    [Required]
    public required string Password { get; init; }
}