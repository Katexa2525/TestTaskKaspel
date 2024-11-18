namespace Domain.Models
{
  public class OrdBook
  {
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid BookId { get; set; }
  }
}
