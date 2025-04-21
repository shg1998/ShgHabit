namespace DevHabbit.Api.Entities
{
    public sealed class HabbitTag
    {
        public string HabbitId { get; set; }
        public string TagId { get; set; }

        public DateTime CreatedAtUtc { get; set; }
    }
}
