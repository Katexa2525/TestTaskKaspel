using Application.Interfaces.Repository;
using Application.Interfaces.Service;

namespace Application.Service
{
  public sealed class ServiceManager : IServiceManager
  {

    private readonly Lazy<IBookService> _bookService;
    private readonly Lazy<IOrderService> _orderService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
      _bookService = new Lazy<IBookService>(() => new BookService(repositoryManager));
      _orderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager));
    }

    public IBookService BookService => _bookService.Value;
    public IOrderService OrderService => _orderService.Value;
  }
}
