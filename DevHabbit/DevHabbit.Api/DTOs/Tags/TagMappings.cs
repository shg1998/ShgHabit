using DevHabbit.Api.DTOs.Habbits;
using DevHabbit.Api.Entities;

namespace DevHabbit.Api.DTOs.Tags
{
    internal static class TagMappings
    {
        public static TagDto ToDto(this Tag h)
        {
            return new TagDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                CreatedAtUtc = h.CreatedAtUtc,
                UpdatedAtUtc = h.UpdatedAtUtc,
            };
        }

        public static Tag ToEntity(this CreateTagDto dto)
        {
            var tag = new Tag
            {
                Id = $"h_${Guid.NewGuid()}",
                Name = dto.Name,
                Description = dto.Description,
                CreatedAtUtc = DateTime.UtcNow
            };
            return tag;
        }

        public static void UpdateFromDto(this Tag tag, UpdateTagDto dto)
        {
            tag.Name = dto.Name;
            tag.Description = dto.Description;
            tag.UpdatedAtUtc = DateTime.UtcNow;
        }
    }
}
