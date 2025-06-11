using Microsoft.AspNetCore.Mvc;
using MangaApi.Models;
using MangaApi.Services;

namespace MangaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MangasController : ControllerBase
{
    private readonly IMangaService _service;

    public MangasController(IMangaService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Manga>> Get() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Manga> GetById(int id)
    {
        var manga = _service.GetById(id);
        return manga == null ? NotFound() : Ok(manga);
    }

    [HttpPost]
    public ActionResult<Manga> Create(Manga manga)
    {
        var created = _service.Create(manga);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Manga manga)
    {
        var updated = _service.Update(id, manga);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = _service.Delete(id);
        return success ? NoContent() : NotFound();
    }
}
