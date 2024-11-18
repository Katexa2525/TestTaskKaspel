namespace Application.DTO
{
  public class CreateBookDTO
  {
    public string ISBN { get; set; }
    public string Name { get; set; }
    public string Jenre { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
  }
}
