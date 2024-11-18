using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI.Moduls.Payment.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Entities.Payment>
{
    public void Configure(EntityTypeBuilder<Entities.Payment> builder)
    {


        builder.Property(p => p.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.PaymentDate)
            .IsRequired();

        builder.Property(p => p.IsSuccessful)
            .IsRequired();

        builder.HasOne(p => p.User)
            .WithMany(u => u.Payments) 
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Video)
            .WithMany(v => v.Payments) 
            .HasForeignKey(p => p.VideoId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}