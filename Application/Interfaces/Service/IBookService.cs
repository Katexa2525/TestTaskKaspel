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
  }
}
