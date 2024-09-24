using System;

namespace SampleProject.Application.Users.RegisterUser.Dto.Responses;

public record struct RegisterUserResponse
{
    public required string Id { get; init; }

    public required string Token { get; init; }
}