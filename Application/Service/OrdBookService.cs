using Application.DTO;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Service
{
  internal sealed class OrdBookService: IOrdBookService
  {
    private readonly IRepositoryManager _repository;

    public OrdBookService(IRepositoryManager repository)
    {
      _repository = repository;
    }

    public async Task<OrdBookDTO> Create(CreateOrdBookDTO createOrdBook, bool trackChanges)
    {
      var ordBook = createOrdBook.Adapt<OrdBook>();
      ordBook.Id = Guid.NewGuid();
      _repository.OrdBook.CreateOrdBook(ordBook);
      _repository.Save();
      return ordBook.Adapt<OrdBookDTO>();
    }

    public async Task Delete(Guid Id, bool trackChanges)
    {
      var ordBook = await _repository.OrdBook.GetById(Id, trackChanges);
      if (ordBook == null)
        throw new Exception("OrdBook not found");
      _repository.OrdBook.DeleteOrdBook(ordBook);
      _repository.Save();
    }

    public async Task<IEnumerable<OrdBookDTO>> GetAll(bool trackChanges)
    {
      var ordBooks = await _repository.OrdBook.GetAll(trackChanges);
      return ordBooks.Adapt<IEnumerable<OrdBookDTO>>();
    }

    public async Task<OrdBookDTO> GetById(Guid Id, bool trackChanges)
    {
      var ordBook = await _repository.OrdBook.GetById(Id, trackChanges);
      if (ordBook == null)
        throw new Exception("OrdBook not found");
      return ordBook.Adapt<OrdBookDTO>();
    }

    public async Task Update(Guid Id, CreateOrdBookDTO createOrdBook, bool trackChanges)
    {
      var existingOrdBook = await _repository.OrdBook.GetById(Id, trackChanges);
      if (existingOrdBook == null)
        throw new Exception("OrdBook not found");
      createOrdBook.Adapt(existingOrdBook);
      _repository.Save();
    }
  }
}
