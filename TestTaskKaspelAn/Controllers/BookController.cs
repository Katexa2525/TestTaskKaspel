using Application.DTO;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace TestTaskKaspelAn.Controllers
{
  [Route("api/books")]
  [ApiController]
  public class BookController : Controller
  {
    private readonly IServiceManager _serviceManager;
    public BookController(IServiceManager serviceManager)
    {
      _serviceManager = serviceManager;
    }

    [HttpGet("filter")]
    public async Task<ActionResult> GetAllBooks([FromQuery] string? name, [FromQuery] int? year)
    {
      var books = await _serviceManager.BookService.GetAllBooks(name, year, trackChanges: true);
      return Ok(books);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetBookById(Guid Id)
    {
        var book = await _serviceManager.BookService.GetBookById(Id, trackChanges: true);
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookDTO createBook)
    {
      var createdBook = await _serviceManager.BookService.CreateBook(createBook, trackChanges: true);
      return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteBook(Guid Id)
    {
      await _serviceManager.BookService.DeleteBook(Id, trackChanges: true);
      return NoContent();
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateBook(Guid Id, [FromBody] UpdateBookDTO updateBook)
    {
      await _serviceManager.BookService.UpdateBook(Id, updateBook, trackChanges: true);
      return NoContent();
    }
  }
}
