using System.Linq.Expressions;
using DevHabbit.Api.Database;
using DevHabbit.Api.DTOs.Habbits;
using DevHabbit.Api.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHabbit.Api.Controllers
{
    [ApiController]
    [Route("habits")]
    public sealed class HabbitsController(ApplicationDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<HabbitsCollectionDto>> GetHabbits()
        {
            var habbits = await dbContext.Habbits.AsNoTracking().Select(HabbitQueries.ProjectToDto()).ToListAsync();
            return Ok(new HabbitsCollectionDto
            {
                Data = habbits
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HabbitDto>> GetHabbit(string id)
        {
            var habbit = await dbContext.Habbits.AsNoTracking().Where(s => s.Id.Equals(id)).Select(HabbitQueries.ProjectToDto()).FirstOrDefaultAsync();

            if (habbit is null)
                return NotFound();

            return Ok(habbit);
        }

        [HttpPost]
        public async Task<ActionResult<HabbitDto>> CreateHabbit(CreateHabbitDto habbitDto)
        {
            var habbit = habbitDto.ToEntity();

            dbContext.Habbits.Add(habbit);

            await dbContext.SaveChangesAsync();

            var habbitReturnDto = habbit.ToDto();

            return CreatedAtAction(nameof(GetHabbit), new { id = habbitReturnDto.Id }, habbitReturnDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHabbit(string id, UpdateHabbitDto dto)
        {
            var habbit = await dbContext.Habbits.FirstOrDefaultAsync(h => h.Id == id);

            if (habbit is null)
                return NotFound();

            habbit.UpdateFromDto(dto);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchHabbit(string id, JsonPatchDocument<HabbitDto> patchDoc)
        {
            var habbit = await dbContext.Habbits.FirstOrDefaultAsync(h => h.Id == id);

            if (habbit is null) return NotFound();

            var habbitDto = habbit.ToDto();

            patchDoc.ApplyTo(habbitDto, ModelState);

            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            habbit.Name = habbitDto.Name;
            habbit.Description = habbitDto.Description;
            habbit.UpdatedAtUtc = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHabbit(string id)
        {
            var habbit = await dbContext.Habbits.FirstOrDefaultAsync(d => d.Id == id);
            if (habbit is null) return StatusCode(StatusCodes.Status410Gone);
            dbContext.Habbits.Remove(habbit);

            await dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
