using DevHabbit.Api.Database;
using DevHabbit.Api.DTOs.Tags;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHabbit.Api.Controllers;

[ApiController]
[Route("tags")]
public sealed class TagsController(ApplicationDbContext dbContext): ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<TagsCollectionDto>> GetTags()
    {
        var tags = await dbContext.Tags.AsNoTracking().Select(TagQueries.ProjectToDto()).ToListAsync();
        return Ok(new TagsCollectionDto
        {
            Data = tags
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TagDto>> GetTag(string id)
    {
        var Tag = await dbContext.Tags.AsNoTracking().Where(s => s.Id.Equals(id)).Select(TagQueries.ProjectToDto()).FirstOrDefaultAsync();

        if (Tag is null)
            return NotFound();

        return Ok(Tag);
    }

    [HttpPost]
    public async Task<ActionResult<TagDto>> CreateTag(CreateTagDto TagDto)
    {
        var Tag = TagDto.ToEntity();

        dbContext.Tags.Add(Tag);

        await dbContext.SaveChangesAsync();

        var TagReturnDto = Tag.ToDto();

        return CreatedAtAction(nameof(GetTag), new { id = TagReturnDto.Id }, TagReturnDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTag(string id, UpdateTagDto dto)
    {
        var tag = await dbContext.Tags.FirstOrDefaultAsync(h => h.Id == id);

        if (tag is null)
            return NotFound();

        tag.UpdateFromDto(dto);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }


    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchTag(string id, JsonPatchDocument<TagDto> patchDoc)
    {
        var Tag = await dbContext.Tags.FirstOrDefaultAsync(h => h.Id == id);

        if (Tag is null) return NotFound();

        var TagDto = Tag.ToDto();

        patchDoc.ApplyTo(TagDto, ModelState);

        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        Tag.Name = TagDto.Name;
        Tag.Description = TagDto.Description;
        Tag.UpdatedAtUtc = DateTime.UtcNow;

        await dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTag(string id)
    {
        var Tag = await dbContext.Tags.FirstOrDefaultAsync(d => d.Id == id);
        if (Tag is null) return StatusCode(StatusCodes.Status410Gone);
        dbContext.Tags.Remove(Tag);

        await dbContext.SaveChangesAsync();
        return NoContent();
    }
}