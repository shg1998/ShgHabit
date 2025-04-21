using DevHabbit.Api.Entities;

namespace DevHabbit.Api.DTOs.Habbits;

public sealed record UpdateHabbitDto
{
    public required string Name { get; init; }

    public string? Description { get; init; }

    public required HabbitType Type { get; init; }

    public required FrequencyDto Frequency { get; init; }

    public required TargetDto Target { get; init; }

    public DateOnly? EndDate { get; init; }

    public UpdateMilestoneDto? Milestone { get; init; }
}

public sealed record UpdateMilestoneDto
{
    public required int Target { get; init; }
}