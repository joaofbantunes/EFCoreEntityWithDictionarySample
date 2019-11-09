using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEntityWithDictionarySample
{
    public class SomethingConfiguration : IEntityTypeConfiguration<Something>
    {
        public void Configure(EntityTypeBuilder<Something> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Ignore(s => s.Things);

            builder
                .HasMany<AnotherThing>("EfTargetThings");

            builder
                .Metadata
                .FindNavigation("EfTargetThings")
                .SetPropertyAccessMode(PropertyAccessMode.Property);            
        }
    }
}
