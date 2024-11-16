using Domain.Models;

namespace Application.Interfaces.Repository
{
  public interface IOrderRepository
  {
    void DeleteBook(Order order);
    void CreateBook(Order order);
  }
}
