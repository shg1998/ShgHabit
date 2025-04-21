namespace DevHabbit.Api.DTOs.Tags
{
    public sealed record CreateTagDto
    {
        public required string Name { get; set; }
        public required string? Description { get; set; }
    }
}
