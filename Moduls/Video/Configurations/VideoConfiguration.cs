using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Common.Constants;

namespace WebAPI.Moduls.Video.Configurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Entities.Video>
    {

        public void Configure(EntityTypeBuilder<Entities.Video> builder)
        {
            builder.Property(v => v.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(v => v.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(v => v.FilePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(v => v.Price)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0) 
                .IsRequired();

            builder.Property(v => v.IsPaid)
                .IsRequired();

            builder.Property(v => v.CategoryId)
                .IsRequired();

            builder.HasOne(v => v.Category)
                .WithMany(c => c.Videos)
                .HasForeignKey(v => v.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.Payments)
                .WithOne(p => p.Video)
                .HasForeignKey(p => p.VideoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}