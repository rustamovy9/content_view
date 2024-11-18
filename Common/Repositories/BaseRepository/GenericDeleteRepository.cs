using WebAPI.Common.Base;
using WebAPI.Common.Base.BaseEntity;
using WebAPI.Common.DataAccess;

namespace WebAPI.Common.Repositories.BaseRepository;

public class GenericDeleteRepository<T>(AppCommandDbContext dbContext) : IGenericDeleteRepository<T> where T : BaseEntity
{
    public async Task RemoveAsync(T value)
    {
        dbContext.Set<T>().Update(value);
    }

    public async Task RemoveRangeAsync(IEnumerable<T> value)
    {
        dbContext.Set<T>().UpdateRange(value);
    }
}