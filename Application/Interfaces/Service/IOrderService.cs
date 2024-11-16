using Application.DTO;

namespace Application.Interfaces.Service
{
  public interface IOrderService
  {
    Task<IEnumerable<OrderDTO>> GetAllOrders(bool trackChanges);
    Task<OrderDTO> GetOrderById(Guid Id, bool trackChanges);
    Task<OrderDTO> CreateOrder(CreateOrderDTO createOrder);
    Task UpdateOrder(Guid Id, UpdateOrderDTO updateOrder, bool trackChanges);
    Task DeleteOrder(Guid Id, bool trackChanges);
  }
}
