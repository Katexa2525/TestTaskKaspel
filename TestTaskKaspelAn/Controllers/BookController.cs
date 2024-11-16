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

    [HttpGet]
    public async Task<ActionResult> GetAllBooks([FromQuery] bool trackChanges = false)
    {
      var books = await _serviceManager.BookService.GetAllBooks(trackChanges);
      return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(Guid Id, [FromQuery] bool trackChanges = false)
    {
        var book = await _serviceManager.BookService.GetBookById(Id, trackChanges);
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookDTO createBook, bool trackChanges = false)
    {
      var createdBook = await _serviceManager.BookService.CreateBook(createBook, trackChanges);
      return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteBook(Guid Id)
    {
      await _serviceManager.BookService.DeleteBook(Id, trackChanges: false);
      return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(Guid Id, [FromBody] UpdateBookDTO updateBook)
    {
      if (updateBook == null)
        return BadRequest("Book data is null.");
      await _serviceManager.BookService.UpdateBook(Id, updateBook, trackChanges: true);
      return NoContent();
    }
  }
}
