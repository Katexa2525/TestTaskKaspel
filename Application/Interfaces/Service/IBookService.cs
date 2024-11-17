using Application.DTO;

namespace Application.Interfaces.Service
{
  public interface IBookService
  {
    Task<IEnumerable<BookDTO>> GetAllBooks(bool trackChanges);
    Task<BookDTO> GetBookById(Guid Id, bool trackChanges);
    Task<BookDTO> CreateBook(CreateBookDTO createBook, bool trackchanges);
    Task DeleteBook(Guid Id, bool trackChanges);
    Task UpdateBook(Guid Id, UpdateBookDTO updateBook, bool trackChanges);
    Task<BookDTO> CreateBookForOrder(Guid orderId, CreateBookDTO createBook);
    Task<BookDTO> UpdateBookForOrder(Guid orderId, Guid bookId, UpdateBookDTO updateBook);
    Task DeleteBookForOrder(Guid orderId, Guid bookId);
  }
}
