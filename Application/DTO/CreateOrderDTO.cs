namespace Application.DTO
{
  public class CreateOrderDTO
  {
    public string Name { get; set; }
    public int Number { get; set; }
    public DateTime OrderDate { get; set; }
    public IEnumerable<Guid> BookIds { get; set; }
  }
}
