using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEntityWithDictionarySample
{
    public class AnotherThingConfiguration : IEntityTypeConfiguration<AnotherThing>
    {
        public void Configure(EntityTypeBuilder<AnotherThing> builder)
        {
            builder.HasKey(a => a.Id);
        }
    }
}
