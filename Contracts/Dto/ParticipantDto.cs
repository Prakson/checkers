﻿namespace Contracts.Dto;

public record ParticipantDto
{
    public required string Id { get; init; }
    public required bool Bot { get; init; }
    public required ColorDto Color { get; init; }
}