namespace Domain.Models
{
  public class Order
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }
    public DateTime OrderDate { get; set; }


    public ICollection<OrdBook> OrdBooks { get; set; }
  }
}
