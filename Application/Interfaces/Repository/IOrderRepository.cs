using Domain.Models;

namespace Application.Interfaces.Repository
{
  public interface IOrderRepository
  {
    Task<IEnumerable<Order>> GetAllOrders(bool trackChanges);
    Task<Order> GetOrderById(Guid Id, bool trackChanges);
    void CreateOrder(Order order);
    void UpdateOrder(Order order);
    void DeleteOrder(Order order);
  }
}
