using System;
using System.ComponentModel.DataAnnotations;

namespace SampleProject.Application.Users.UpdateUser.Dto.Requests;

public record struct UpdateUserRequest
{
    public required string Username { get; init; }

    public required string Password { get; init; }

    public required string Email { get; init; }
}