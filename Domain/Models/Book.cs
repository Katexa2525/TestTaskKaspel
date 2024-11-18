namespace Domain.Models
{
  public class Book
  {
    public Guid Id { get; set; }
    public string ISBN { get; set; }
    public string Name { get; set; }
    public string Jenre { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    //public ICollection<OrdBook> OrdBooks { get; set; }

    //public Guid OrderId { get; set; } // Внешний ключ
    //public Order Order { get; set; }
  }
}
