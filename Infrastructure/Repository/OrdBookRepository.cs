using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
  public class OrdBookRepository : RepositoryBase<OrdBook>, IOrdBookRepository
  {
    public OrdBookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateOrdBook(OrdBook ordBook)
    {
      Create(ordBook);
    }

    public void DeleteOrdBook(OrdBook ordBook)
    {
      Delete(ordBook);
    }

    public async Task<IEnumerable<OrdBook>> GetAll(bool trackChanges)
    {
      return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<OrdBook> GetById(Guid id, bool trackChanges)
    {
      return await FindByCondition(ob => ob.Id == id, trackChanges).FirstOrDefaultAsync();
    }

    public void UpdateOrdBook(OrdBook ordBook)
    {
      Update(ordBook);
    }
  }
}
