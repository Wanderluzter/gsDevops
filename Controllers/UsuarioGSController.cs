using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsuarioGSController : ControllerBase
{
    private readonly UsuarioGSService _service;

    public UsuarioGSController(UsuarioGSService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpPost]
    public IActionResult Create([FromBody] UsuarioGSCreateDTO dto)
    {
        _service.Create(dto);
        return CreatedAtAction(nameof(GetAll), null);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UsuarioGSCreateDTO dto)
    {
        var updated = _service.Update(id, dto);
        if (!updated)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}
