using DevHabbit.Api.Entities;

namespace DevHabbit.Api.DTOs.Habbits;

public sealed record FrequencyDto
{
    public FrequencyType Type { get; init; }

    public int TimesPerPeriod { get; init; }
}