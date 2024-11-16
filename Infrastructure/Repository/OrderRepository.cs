using Application.Interfaces.Repository;
using Domain.Models;

namespace Infrastructure.Repository
{
  public class OrderRepository : RepositoryBase<Order>, IOrderRepository
  {
    public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateBook(Order order)
    {
      Create(order);
    }

    public void DeleteBook(Order order)
    {
      Delete(order);
    }
  }
}
