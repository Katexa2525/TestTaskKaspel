using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
  public class OrderRepository : RepositoryBase<Order>, IOrderRepository
  {
    public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateOrder(Order order)
    {
      Create(order);
    }

    public void DeleteOrder(Order order)
    {
      Delete(order);
    }

    public async Task<IEnumerable<Order>> GetAllOrders(bool trackChanges)
    {
      return await FindAll(trackChanges).Include(o => o.Books).ToListAsync();
    }

    public async Task<Order> GetOrderById(Guid Id, bool trackChanges)
    {
      return await FindByCondition(o => o.Id == Id, trackChanges).Include(o => o.Books).SingleOrDefaultAsync();
    }

    public void UpdateOrder(Order order)
    {
      Update(order);
    }
  }
}
