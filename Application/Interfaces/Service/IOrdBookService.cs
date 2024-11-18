using Application.DTO;

namespace Application.Interfaces.Service
{
  public interface IOrdBookService
  {
    Task<IEnumerable<OrdBookDTO>> GetAll(bool trackChanges);
    Task<OrdBookDTO> GetById(Guid Id, bool trackChanges);
    Task<OrdBookDTO> Create(CreateOrdBookDTO createOrdBook, bool trackChanges);
    Task Delete(Guid Id, bool trackChanges);
    Task Update(Guid Id, CreateOrdBookDTO createOrdBook, bool trackChanges);
  }
}
