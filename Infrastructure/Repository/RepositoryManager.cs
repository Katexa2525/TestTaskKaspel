using Application.Interfaces.Repository;

namespace Infrastructure.Repository
{
  public class RepositoryManager : IRepositoryManager
  {
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IBookRepository> _bookRepository;
    private readonly Lazy<IOrderRepository> _orderRepository;
    private readonly Lazy<IOrdBookRepository> _ordBookRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
      _repositoryContext = repositoryContext;
      _ordBookRepository = new Lazy<IOrdBookRepository>(() => new OrdBookRepository(repositoryContext));
      _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(repositoryContext));
      _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
    }

    public IBookRepository Book => _bookRepository.Value;
    public IOrderRepository Order => _orderRepository.Value;
    public IOrdBookRepository OrdBook => _ordBookRepository.Value;

    public async Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    public void Save() => _repositoryContext.SaveChanges();
  }
}
