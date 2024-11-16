namespace Application.DTO
{
  public class CreateBookDTO
  {
    public string ISBN { get; set; }
    public string Name { get; set; }
    public string Jenre { get; set; }
    public string Author { get; set; }
    public DateTime Year { get; set; }
    public Guid OrderId { get; set; }
  }
}
