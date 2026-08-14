using Microsoft.AspNetCore.Mvc;
using DemoApp.Models;
using DemoApp.Repositories;

namespace DemoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemRepository _repo;

    public ItemsController(IItemRepository repo) => _repo = repo;

    [HttpGet]
    public ActionResult<IEnumerable<Item>> Get() => Ok(_repo.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Item> Get(Guid id)
    {
        var item = _repo.Get(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public ActionResult<Item> Post([FromBody] ItemCreateDto dto)
    {
        var item = new Item(Guid.NewGuid(), dto.Name, dto.Description);
        _repo.Create(item);
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] ItemUpdateDto dto)
    {
        var item = new Item(id, dto.Name, dto.Description);
        return _repo.Update(id, item) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) => _repo.Delete(id) ? NoContent() : NotFound();
}
