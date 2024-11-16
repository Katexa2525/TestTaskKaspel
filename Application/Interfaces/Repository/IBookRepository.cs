using Domain.Models;

namespace Application.Interfaces.Repository
{
  public interface IBookRepository
  {
    Task<IEnumerable<Book>> GetAllBooks(bool trackChanges);
    Task<Book> GetBookById(Guid Id, bool trackChanges);
    void DeleteBook(Book book);
    void CreateBook(Book book);
    void UpdateBook(Book book);
  }
}
