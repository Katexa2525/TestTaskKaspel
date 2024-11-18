using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Infrastructure.Repository
{
  public class BookRepository : RepositoryBase<Book>, IBookRepository
  {
    public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateBook(Book book)
    {
      Create(book);
    }

    public void DeleteBook(Book book)
    {
      Delete(book);
    }

    public void UpdateBook(Book book)
    {
      Update(book);
    }

    public async Task<IEnumerable<Book>> GetAllBooks(string? name, int? year, bool trackChanges)
    {
      var query = FindAll(trackChanges);

      if (!string.IsNullOrWhiteSpace(name))
        query = query.Where(book => book.Name.Contains(name));

      if (year.HasValue)
        query = query.Where(book => book.Year == year.Value);

      return await query.ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksByIds(IEnumerable<Guid> bookIds, bool trackChanges)
    {
      var query = FindAll(trackChanges);
      if (bookIds != null && bookIds.Any())
      {
        query = query.Where(book => bookIds.Contains(book.Id));
      }
      return await query.ToListAsync();
    }

    public async Task<Book> GetBookById(Guid Id, bool trackChanges) => await FindByCondition(book => book.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();

    //public void CreateBookForOrder(Guid orderId, Book book)
    //{
    //  book.OrderId = orderId; // связь
    //  Create(book);
    //}

    //public async Task<Book> GetBookByOrderIdBookId(Guid orderId, Guid bookId, bool trackChanges) =>
    //    await FindByCondition(b => b.OrderId == orderId && b.Id == bookId, trackChanges).SingleOrDefaultAsync();
  }
}
