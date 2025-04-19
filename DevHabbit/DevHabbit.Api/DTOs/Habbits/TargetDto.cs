namespace DevHabbit.Api.DTOs.Habbits;

public sealed record TargetDto
{
    public int Value { get; init; }
    public string Unit { get; init; }
}