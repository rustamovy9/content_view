using System.Linq.Expressions;
using WebAPI.Common.Base;
using WebAPI.Common.Base.BaseEntity;

namespace WebAPI.Common.Repositories.BaseRepository;

public interface IGenericFindRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
}