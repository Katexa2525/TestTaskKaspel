using Domain.Models;

namespace Application.Interfaces.Repository
{
  public interface IBookRepository
  {
    Task<IEnumerable<Book>> GetAllBooks(string? name, int? year, bool trackChanges);
    Task<Book> GetBookById(Guid Id, bool trackChanges);
    void DeleteBook(Book book);
    void CreateBook(Book book);
    void UpdateBook(Book book);
    //void CreateBookForOrder(Guid orderId, Book book);
    //Task<Book> GetBookByOrderIdBookId(Guid orderId, Guid bookId, bool trackChanges);
    Task<IEnumerable<Book>> GetBooksByIds(IEnumerable<Guid> bookIds, bool trackChanges);
  }
}
