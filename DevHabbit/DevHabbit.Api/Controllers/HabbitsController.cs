using System.Linq.Expressions;
using DevHabbit.Api.Database;
using DevHabbit.Api.DTOs.Habbits;
using DevHabbit.Api.Entities;
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
            var habbit = await dbContext.Habbits.AsNoTracking().Where(s=>s.Id.Equals(id)).Select(HabbitQueries.ProjectToDto()).FirstOrDefaultAsync();

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

            return CreatedAtAction(nameof(GetHabbit), new {id = habbitReturnDto.Id} , habbitReturnDto);
        }
    }
}
