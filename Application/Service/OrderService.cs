using Application.Interfaces.Repository;
using Application.Interfaces.Service;

namespace Application.Service
{
  internal sealed class OrderService : IOrderService
  {
    private readonly IRepositoryManager _repository;

    public OrderService(IRepositoryManager repository)
    {
      _repository = repository;
    }
  }
}
