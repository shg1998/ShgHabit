using DevHabbit.Api.Entities;

namespace DevHabbit.Api.DTOs.Habbits;

public sealed record HabbitDto
{
    public required string Id { get; init; }

    public required string Name { get; init; }

    public string? Description { get; init; }

    public required HabbitType Type { get; init; }

    public required FrequencyDto Frequency { get; init; }

    public required TargetDto Target { get; init; }

    public required HabbitStatus Statue { get; init; }

    public required bool IsArchived { get; init; }

    public DateOnly? EndDate { get; init; }

    public MilestoneDto? Milestone { get; init; }

    public required DateTime CreatedAtUtc { get; init; }

    public DateTime? UpdatedAtUtc { get; init; }

    public DateTime? LastCompletedAtUtc { get; init; }
}