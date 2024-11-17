namespace Application.DTO
{
  public class OrderDTO
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
    public DateTime OrderDate { get; set; }

    public IEnumerable<BookDTO> Books { get; set; }
  }
}
