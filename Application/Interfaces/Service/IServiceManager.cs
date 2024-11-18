namespace Application.Interfaces.Service
{
  public interface IServiceManager
  {
    IBookService BookService { get; }
    IOrderService OrderService { get; }
    IOrdBookService OrdBookService { get; }
  }
}
