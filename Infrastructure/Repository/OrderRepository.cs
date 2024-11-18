﻿using Application.Interfaces.Repository;
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

    public async Task<IEnumerable<Order>> GetAllOrders(string? name, DateTime? orderDate, bool trackChanges)
    {
      var query = FindAll(trackChanges);

      if (!string.IsNullOrWhiteSpace(name))
        query = query.Where(order => order.Name.Contains(name));

      if (orderDate.HasValue)
        query = query.Where(order => order.OrderDate.Date == orderDate.Value.Date);

      return await query.ToListAsync();
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
