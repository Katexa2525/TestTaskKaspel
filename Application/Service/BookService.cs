using Application.DTO;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Service
{
  internal sealed class BookService : IBookService
  {
    private readonly IRepositoryManager _repository;

    public BookService(IRepositoryManager repository)
    {
      _repository = repository;
    }

    public async Task<BookDTO> CreateBook(CreateBookDTO createBook, bool trackchanges)
    {
      var book = createBook.Adapt<Book>();
      _repository.Book.CreateBook(book);
      await _repository.SaveAsync();
      return book.Adapt<BookDTO>();
    }

    public async Task DeleteBook(Guid Id, bool trackChanges)
    {
      var book = await _repository.Book.GetBookById(Id, trackChanges);
      if (book == null)
        throw new KeyNotFoundException($"Book with id {Id} not found.");
      _repository.Book.DeleteBook(book);
      await _repository.SaveAsync();
    }

    public async Task<IEnumerable<BookDTO>> GetAllBooks(bool trackChanges)
    {
      var books = await _repository.Book.GetAllBooks(trackChanges);
      return books.Adapt<IEnumerable<BookDTO>>();
    }

    public async Task<BookDTO> GetBookById(Guid Id, bool trackChanges)
    {
      var book = await _repository.Book.GetBookById(Id, trackChanges);

      if (book == null)
        throw new KeyNotFoundException($"Book with id {Id} not found.");

      return book.Adapt<BookDTO>();
    }

    public async Task UpdateBook(Guid Id, UpdateBookDTO updateBook, bool trackChanges)
    {
      var book = await _repository.Book.GetBookById(Id, trackChanges);
      if (book == null)
        throw new KeyNotFoundException($"Book with id {Id} not found.");
      updateBook.Adapt(book);
      _repository.Book.UpdateBook(book);
      await _repository.SaveAsync();
    }
  }
}
