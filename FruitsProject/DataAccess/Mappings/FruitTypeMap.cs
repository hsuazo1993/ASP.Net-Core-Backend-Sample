using DataAccess.Models;
using DataAccess.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings
{
    public class FruitTypeMap : IEntityTypeConfiguration<FruitType>
    {
        public void Configure(EntityTypeBuilder<FruitType> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.HasData(SeedData.FruitTypesData);
        }
    }
}
