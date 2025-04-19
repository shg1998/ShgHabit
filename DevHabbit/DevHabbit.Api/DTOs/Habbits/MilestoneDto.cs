namespace DevHabbit.Api.DTOs.Habbits;

public sealed record MilestoneDto
{
    public int Target { get; init; }
    public int Current { get; init; }
}