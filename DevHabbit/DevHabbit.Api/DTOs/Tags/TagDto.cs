﻿namespace DevHabbit.Api.DTOs.Tags
{
    public sealed record TagDto
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public DateTime CreatedAtUtc { get; init; }
        public DateTime? UpdatedAtUtc { get; init; }
    }
}
