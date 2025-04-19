using DevHabbit.Api.Entities;

namespace DevHabbit.Api.DTOs.Habbits;

internal static class HabbitMappings
{
    public static HabbitDto ToDto(this Habbit h)
    {
        return new HabbitDto
        {
            Id = h.Id,
            Name = h.Name,
            Description = h.Description,
            Type = h.Type,
            Frequency = new FrequencyDto
            {
                Type = h.Frequency.Type,
                TimesPerPeriod = h.Frequency.TimesPerPeriod
            },
            Target = new TargetDto
            {
                Value = h.Target.Value,
                Unit = h.Target.Unit
            },
            Statue = h.Statue,
            IsArchived = h.IsArchived,
            EndDate = h.EndDate,
            Milestone = h.Milestone == null ? null : new MilestoneDto
            {
                Target = h.Milestone.Target,
                Current = h.Milestone.Current
            },
            CreatedAtUtc = h.CreatedAtUtc,
            UpdatedAtUtc = h.UpdatedAtUtc,
            LastCompletedAtUtc = h.LastCompletedAtUtc
        };
    }

    public static Habbit ToEntity(this CreateHabbitDto dto)
    {
        var habbit = new Habbit
        {
            Id = $"h_${Guid.NewGuid()}",
            Name = dto.Name,
            Description = dto.Description,
            Type = dto.Type,
            Frequency = new Frequency
            {
                Type = dto.Frequency.Type,
                TimesPerPeriod = dto.Frequency.TimesPerPeriod
            },
            Target = new Target
            {
                Value = dto.Target.Value,
                Unit = dto.Target.Unit,
            },
            Statue = HabbitStatus.Ongoing,
            IsArchived = false,
            EndDate = dto.EndDate,
            Milestone = dto.Milestone is not null ? new Milestone
            {
                Target = dto.Milestone.Target,
                Current = 0
            } : null,
            CreatedAtUtc = DateTime.UtcNow
        };
        return habbit;
    }
}