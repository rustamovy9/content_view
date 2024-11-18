using WebAPI.Common.Base;
using WebAPI.Common.Base.BaseEntity;
using WebAPI.Common.DataAccess;

namespace WebAPI.Common.Repositories.BaseRepository;

public class GenericAddRepository<T>(AppCommandDbContext dbContext) : IGenericAddRepository<T> where T : BaseEntity
{
    public async Task AddAsync(T value)
    {
        await dbContext.Set<T>().AddAsync(value);
    }

    public async Task AddRangeAsync(IEnumerable<T> value)
    {
        await dbContext.Set<T>().AddRangeAsync(value);
    }
}