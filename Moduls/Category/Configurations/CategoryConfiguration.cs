using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI.Moduls.Category.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category.Entities.Category>
    {
        public void Configure(EntityTypeBuilder<Category.Entities.Category> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()  
                .HasMaxLength(200); 

            builder.HasMany(c => c.Videos)
                .WithOne(v => v.Category) 
                .HasForeignKey(v => v.CategoryId);  

            builder.HasAlternateKey(c => c.Name); 
        }
    }
}