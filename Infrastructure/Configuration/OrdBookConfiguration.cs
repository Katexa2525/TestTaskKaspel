using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
  public class OrdBookConfiguration : IEntityTypeConfiguration<OrdBook>
  {
    public void Configure(EntityTypeBuilder<OrdBook> builder)
    {
      builder.HasData
      (
      new OrdBook
      {
        Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
         OrderId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
          BookId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")

      },
      new OrdBook
      {
        Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
         OrderId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
         BookId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
      }
      );
    }
  }
}
