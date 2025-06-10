using Microsoft.AspNetCore.Mvc;
using WebApplication.Interfaces;
using WebApplication.Models.Entities;

namespace WebApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SomeImageEntityController : ControllerBase
{
    private readonly ISomeImageEntityRepository _repo;

    public SomeImageEntityController(ISomeImageEntityRepository repo)
    {
        _repo = repo;
    }

    [HttpPost("set-image")]
    public async Task<IActionResult> SetImage([FromBody] SomeImageEntity entity)
    {
        var created = await _repo.CreateAsync(entity);
        return Ok(created);
    }

    [HttpGet("get-image/{id}")]
    public async Task<IActionResult> GetImage(int id)
    {
        var image = await _repo.GetByIdAsync(id);
        return image is null ? NotFound() : Ok(image);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetEntitiesByFilter([FromQuery] string? status)
    {
        var result = await _repo.GetByFilterAsync(status);
        return Ok(result);
    }
}
