using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Common.Constants;

namespace WebAPI.Moduls.User.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Entities.User>
    {
        public void Configure(EntityTypeBuilder<Entities.User> builder)
        {
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(255); 

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(20); 

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.AvatarPath)
                .HasDefaultValue(ImageName.Default);

            builder.HasMany(u => u.Payments)
                .WithOne()
                .HasForeignKey(p => p.UserId) 
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}