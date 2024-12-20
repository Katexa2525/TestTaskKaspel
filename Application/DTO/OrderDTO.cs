﻿namespace Application.DTO
{
  public class OrderDTO
  {
    public Guid Id { get; set; } 
    public string Name { get; set; }
    public int Number { get; set; }
    public DateTime OrderDate { get; set; }

    public IEnumerable<OrdBookDTO> OrdBooks { get; set; }
  }
}
