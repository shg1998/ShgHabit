using DevHabbit.Api.Entities;

namespace DevHabbit.Api.DTOs.Habbits;

public sealed record CreateHabbitDto
{
    public required string Name { get; init; }

    public string? Description { get; init; }

    public required HabbitType Type { get; init; }

    public required FrequencyDto Frequency { get; init; }

    public required TargetDto Target { get; init; }

    public DateOnly? EndDate { get; init; }

    public MilestoneDto? Milestone { get; init; }
}