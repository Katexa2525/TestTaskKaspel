using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
  public class OrderConfiguration : IEntityTypeConfiguration<Order>
  {
    public void Configure(EntityTypeBuilder<Order> builder)
    {
      builder.HasData
      (
        new Order
        {
          Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
          Name = "1 Заказ",
          Number = 2,
          OrderDate = DateTime.Now,
        }
      );
    }
  }
}
