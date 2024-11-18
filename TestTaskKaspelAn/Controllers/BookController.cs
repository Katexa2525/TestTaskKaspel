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
      //if (updateBook == null)
      //  return BadRequest("Book data is null.");
      await _serviceManager.BookService.UpdateBook(Id, updateBook, trackChanges: true);
      return NoContent();
    }

    //[HttpPost("{orderId}")]
    //public async Task<IActionResult> CreateBookForOrder(Guid orderId, [FromBody] CreateBookDTO createBook)
    //{
    //  //if (createBook == null)
    //  //  return BadRequest("BookForCreationDTO object is null.");
    //  var createdBook = await _serviceManager.BookService.CreateBookForOrder(orderId, createBook);
    //  return CreatedAtRoute("GetBookByIdForOrder", new { orderId = orderId, bookId = createdBook.Id }, createdBook);
    //}

    //[HttpDelete("{orderId:Guid}/{bookId:Guid}")]
    //public async Task<IActionResult> DeleteBookForOrder(Guid orderId, Guid bookId)
    //{
    //  await _serviceManager.BookService.DeleteBookForOrder(orderId, bookId);
    //  return NoContent();
    //}

    //[HttpPut("{orderId:Guid}/{bookId:Guid}")]
    //public async Task<IActionResult> UpdateBookForOrder(Guid orderId, Guid bookId, [FromBody] UpdateBookDTO updateBook)
    //{
    //  //if (updateBook == null)
    //  //  return BadRequest("UpdateBookDTO object is null.");
    //  var updatedBook = await _serviceManager.BookService.UpdateBookForOrder(orderId, bookId, updateBook);
    //  return Ok(updatedBook);
    //}
  }
}
