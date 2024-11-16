using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<Book>> GetAllBooks(bool trackChanges) => await FindAll(trackChanges).OrderBy(c=>c.Name).ToListAsync();

    public async Task<Book> GetBookById(Guid Id, bool trackChanges) => await FindByCondition(book => book.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();
  }
}
