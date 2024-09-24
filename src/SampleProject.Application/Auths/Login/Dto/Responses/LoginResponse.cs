namespace SampleProject.Application.Auths.Login.Dto.Responses;

public record struct LoginResponse
{
    public required string Username { get; set; }
    
    public required string Token { get; set; }
}