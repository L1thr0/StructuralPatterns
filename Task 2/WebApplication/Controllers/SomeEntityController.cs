using Microsoft.AspNetCore.Mvc;
using WebApplication.Models.Entities;
using WebApplication.Services;

namespace WebApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SomeEntityController : ControllerBase
{
    private readonly SomeEntityService _service;

    public SomeEntityController(SomeEntityService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] SomeEntity entity)
    {
        var created = await _service.Create(entity);
        return Ok(created);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] SomeEntity entity)
    {
        var updated = await _service.Update(entity);
        return Ok(updated);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var entity = await _service.Get(id);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetMany()
    {
        var entities = await _service.GetAll();
        return Ok(entities);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetByFilter([FromQuery] string? status)
    {
        var filtered = await _service.GetByStatus(status);
        return Ok(filtered);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return Ok();
    }

    [HttpPost("delete-many")]
    public async Task<IActionResult> DeleteMany([FromBody] List<int> ids)
    {
        await _service.DeleteMany(ids);
        return Ok();
    }

    [HttpGet("print/{id}")]
    public async Task<IActionResult> Print(int id)
    {
        var entity = await _service.Get(id);
        return entity is null
            ? NotFound()
            : Ok($"Entity {entity.Id}: {entity.Name} — {entity.Description} (Status: {entity.Status})");
    }

    [HttpGet("print-all")]
    public async Task<IActionResult> PrintMany()
    {
        var entities = await _service.GetAll();
        var lines = entities.Select(e => $"Entity {e.Id}: {e.Name} — {e.Description} (Status: {e.Status})");
        return Ok(lines);
    }

    [HttpPost("set-status")]
    public async Task<IActionResult> SetStatus([FromQuery] int id, [FromQuery] string status)
    {
        var entity = await _service.Get(id);
        if (entity is null) return NotFound();

        entity.Status = status;
        await _service.Update(entity);
        return Ok(entity);
    }

    [HttpPost("deactivate/{id}")]
    public async Task<IActionResult> Deactivate(int id)
    {
        return await SetStatusInternal(id, "Inactive");
    }

    [HttpPost("activate/{id}")]
    public async Task<IActionResult> Activate(int id)
    {
        return await SetStatusInternal(id, "Active");
    }

    private async Task<IActionResult> SetStatusInternal(int id, string status)
    {
        var entity = await _service.Get(id);
        if (entity is null) return NotFound();

        entity.Status = status;
        await _service.Update(entity);
        return Ok(entity);
    }
}
