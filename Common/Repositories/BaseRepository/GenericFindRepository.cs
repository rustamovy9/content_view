using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebAPI.Common.Base;
using WebAPI.Common.Base.BaseEntity;
using WebAPI.Common.DataAccess;

namespace WebAPI.Common.Repositories.BaseRepository;

public class GenericFindRepository<T>(AppQueryDbContext dbContext) : IGenericFindRepository<T> where T : BaseEntity
{
    public async Task<T?> GetByIdAsync(int id)
    {
        return await dbContext.Set<T>().Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
    {
        return await dbContext.Set<T>().Where(x => !x.IsDeleted).Where(expression).ToListAsync();
    }
}