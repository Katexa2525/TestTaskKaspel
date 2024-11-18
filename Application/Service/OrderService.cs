using Application.DTO;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Service
{
  internal sealed class OrderService : IOrderService
  {
    private readonly IRepositoryManager _repository;

    public OrderService(IRepositoryManager repository)
    {
      _repository = repository;
    }

    public async Task<OrderDTO> CreateOrder(CreateOrderDTO createOrder)
    {
      var order = createOrder.Adapt<Order>();
      order.Id = Guid.NewGuid();
      if (createOrder.BookIds != null && createOrder.BookIds.Any())
      {
        var books = await _repository.Book.GetBooksByIds(createOrder.BookIds, trackChanges: true);
        order.OrdBooks = new List<OrdBook>();
        foreach (var book in books) 
        {
          OrdBook ordBook = new OrdBook()
          {
            Id = Guid.NewGuid(),
            OrderId = order.Id,
            BookId = book.Id,
          };  
          order.OrdBooks.Add(ordBook);
        }
      }
      _repository.Order.CreateOrder(order);
      _repository.Save();
      return order.Adapt<OrderDTO>();
    }

    public async Task DeleteOrder(Guid Id, bool trackChanges)
    {
      var order = await _repository.Order.GetOrderById(Id, trackChanges);
      if (order == null)
        throw new KeyNotFoundException($"Order with id {Id} not found.");
      _repository.Order.DeleteOrder(order);
      _repository.Save();
    }

    public async Task<IEnumerable<OrderDTO>> GetAllOrders(string? name, DateTime? orderDate, bool trackChanges)
    {
      var orders = await _repository.Order.GetAllOrders(name, orderDate, trackChanges);
      return orders.Adapt<IEnumerable<OrderDTO>>();
    }
    public async Task<OrderDTO> GetOrderById(Guid Id, bool trackChanges)
    {
      var order = await _repository.Order.GetOrderById(Id, trackChanges);
      if (order == null)
        throw new KeyNotFoundException($"Order with id {Id} not found.");
      return order.Adapt<OrderDTO>();
    }

    public async Task UpdateOrder(Guid Id, UpdateOrderDTO updateOrder, bool trackChanges)
    {
      var order = await _repository.Order.GetOrderById(Id, trackChanges);
      if (order == null)
        throw new KeyNotFoundException($"Order with id {Id} not found.");
      updateOrder.Adapt(order);
      _repository.Order.UpdateOrder(order);
      _repository.Save();
    }
  }
}
