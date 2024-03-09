using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PixApi.Models;

namespace PixApi.Data.Map
{
    public class TransitionMap : IEntityTypeConfiguration<Transition>
    {
        public void Configure(EntityTypeBuilder<Transition> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IssuerClient).IsRequired();
            builder.Property(x => x.IssuerClientKey).IsRequired();
            builder.Property(x => x.ReceiverClient).IsRequired();
            builder.Property(x => x.ReceiverClientKey).IsRequired();
            builder.Property(x => x.DepositValue);
        }
    }
}
