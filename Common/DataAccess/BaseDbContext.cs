using Microsoft.EntityFrameworkCore;
using WebAPI.Common.Extensions.EFCore;
using WebAPI.Moduls.Category.Entities;
using WebAPI.Moduls.Payment.Entities;
using WebAPI.Moduls.User.Entities;
using WebAPI.Moduls.Video.Entities;

namespace WebAPI.Common.DataAccess;

public class BaseDbContext(DbContextOptions<BaseDbContext> options)  : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Video> Videos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        modelBuilder.FilterSoftDeletedProperties();
        base.OnModelCreating(modelBuilder);
    }
}