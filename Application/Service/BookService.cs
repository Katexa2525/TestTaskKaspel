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

    public async Task<BookDTO> CreateBook(CreateBookDTO createBook, bool trackChanges)
    {
      var book = createBook.Adapt<Book>();
      _repository.Book.CreateBook(book);
      _repository.Save();
      return book.Adapt<BookDTO>();
    }

    public async Task DeleteBook(Guid Id, bool trackChanges)
    {
      var book = await _repository.Book.GetBookById(Id, trackChanges);
      if (book == null)
        throw new KeyNotFoundException($"Book with id {Id} not found.");
      _repository.Book.DeleteBook(book);
      _repository.Save();
    }

    public async Task<IEnumerable<BookDTO>> GetAllBooks(string? name, int? year, bool trackChanges)
    {
      var books = await _repository.Book.GetAllBooks(name, year, trackChanges);
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
      _repository.Save();
    }
  }
}
