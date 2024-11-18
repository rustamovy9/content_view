using Microsoft.EntityFrameworkCore;

namespace WebAPI.Common.DataAccess;

public sealed class AppQueryDbContext(DbContextOptions<BaseDbContext> options) : BaseDbContext(options);