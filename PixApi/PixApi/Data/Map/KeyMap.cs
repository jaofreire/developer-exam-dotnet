using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PixApi.Models;

namespace PixApi.Data.Map
{
    public class KeyMap : IEntityTypeConfiguration<KeyModel>
    {
        public void Configure(EntityTypeBuilder<KeyModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TypeKey).IsRequired();
            builder.Property(x => x.Key).IsRequired();
        }
    }
}
