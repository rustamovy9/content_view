using Microsoft.EntityFrameworkCore;

namespace WebAPI.Common.DataAccess;

public sealed class AppCommandDbContext(DbContextOptions<BaseDbContext> options) : BaseDbContext(options);