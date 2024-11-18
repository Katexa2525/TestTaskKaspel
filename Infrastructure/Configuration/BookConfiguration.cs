using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
  public class BookConfiguration : IEntityTypeConfiguration<Book>
  {
    public void Configure(EntityTypeBuilder<Book> builder)
    {
      builder.HasData
      (
      new Book
      {
        Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
        Name = "Neil Gaiman: Neverwhere. The Illustrated Edition",
        ISBN = "978-1-4722-3435-3",
        Author = "Gaiman Neil",
        Jenre = "Fentasy",
        Year = 2017,
        OrderId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
      },
      new Book
      {
        Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
        Name = "Джефф Хокинс: 1000 мозгов. Новая теория интеллекта.",
        ISBN = "978-5-907473-58-4",
        Author = "Хокинс Джефф",
        Jenre = "Science",
        Year = 2015,
        OrderId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
      }
      );
    }
  }
}
