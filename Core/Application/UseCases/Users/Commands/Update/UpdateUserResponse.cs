﻿namespace Application.UseCases.Users.Commands.Update;
public sealed record UpdateUserResponse
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}