namespace Application.DTO
{
  public class CreateOrderDTO
  {
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public IEnumerable<Guid> BookIds { get; set; }
  }
}
