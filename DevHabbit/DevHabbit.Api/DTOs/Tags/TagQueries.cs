using DevHabbit.Api.Entities;
using System.Linq.Expressions;

namespace DevHabbit.Api.DTOs.Tags
{
    public static class TagQueries
    {
        public static Expression<Func<Tag, TagDto>> ProjectToDto()
        {
            return h => new TagDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                CreatedAtUtc = h.CreatedAtUtc,
                UpdatedAtUtc = h.UpdatedAtUtc,
            };
        }
    }
}
