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
      await _repository.SaveAsync();
      return book.Adapt<BookDTO>();
    }

    public async Task<BookDTO> CreateBookForOrder(Guid orderId, CreateBookDTO createBook)
    {
      var order = await _repository.Order.GetOrderById(orderId, trackChanges: false);
      if (order == null)
        throw new Exception($"Order with id {orderId} does not exist.");
      var book = createBook.Adapt<Book>();
      _repository.Book.CreateBookForOrder(orderId, book);
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

    public async Task DeleteBookForOrder(Guid orderId, Guid bookId)
    {
      var book = await _repository.Book.GetBookByOrderIdBookId(orderId, bookId, trackChanges: false);
      if (book == null)
        throw new Exception($"Book with id {bookId} does not exist in Order with id {orderId}.");
      _repository.Book.DeleteBook(book);
      await _repository.SaveAsync();
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
      await _repository.SaveAsync();
    }

    public async Task<BookDTO> UpdateBookForOrder(Guid orderId, Guid bookId, UpdateBookDTO updateBook)
    {
      var book = await _repository.Book.GetBookByOrderIdBookId(orderId, bookId, trackChanges: true);
      if (book == null)
        throw new Exception($"Book with id {bookId} does not exist in Order with id {orderId}.");
      updateBook.Adapt(book);
      await _repository.SaveAsync();
      return book.Adapt<BookDTO>();
    }
  }
}
