using Domain.Models;

namespace Application.Interfaces.Repository
{
  public interface IOrdBookRepository
  {
    Task<IEnumerable<OrdBook>> GetAll(bool trackChanges);
    Task<OrdBook> GetById(Guid id, bool trackChanges);
    void CreateOrdBook(OrdBook ordBook);
    void DeleteOrdBook(OrdBook ordBook);
    void UpdateOrdBook(OrdBook ordBook);
  }
}
