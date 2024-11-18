using Application.DTO;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace TestTaskKaspelAn.Controllers
{
  [Route("api/ordbooks")]
  [ApiController]
  public class OrdBookController : Controller
  {
    private readonly IServiceManager _serviceManager;
    public OrdBookController(IServiceManager serviceManager)
    {
      _serviceManager = serviceManager;
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Update(Guid Id, [FromBody] CreateOrdBookDTO updateOrdBookDTO)
    {
        await _serviceManager.OrdBookService.Update(Id, updateOrdBookDTO, trackChanges: true);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var ordBooks = await _serviceManager.OrdBookService.GetAll(trackChanges: true);
      return Ok(ordBooks);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(Guid Id)
    {
      var ordBook = await _serviceManager.OrdBookService.GetById(Id, trackChanges: true);
      if (ordBook == null)
        return NotFound();
      return Ok(ordBook);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrdBookDTO createOrdBookDTO)
    {
      var createdOrdBook = await _serviceManager.OrdBookService.Create(createOrdBookDTO, trackChanges: true);
      return CreatedAtAction(nameof(GetById), new { id = createdOrdBook.Id }, createdOrdBook);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(Guid Id)
    {
      await _serviceManager.OrdBookService.Delete(Id, trackChanges: true);
      return NoContent();
    }
  }
}
