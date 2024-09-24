using System.ComponentModel.DataAnnotations;

namespace SampleProject.Application.Auths.Login.Dto.Requests;

public record struct LoginRequest
{
    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }
}