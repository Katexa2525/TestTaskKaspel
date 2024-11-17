namespace Domain.Models
{
  public class Order
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
    public DateTime OrderDate { get; set; }


    public ICollection<Book> Books { get; set; }
  }
}
