namespace DevHabbit.Api.DTOs.Habbits;

public sealed record HabbitsCollectionDto
{
    public List<HabbitDto> Data { get; init; }
}