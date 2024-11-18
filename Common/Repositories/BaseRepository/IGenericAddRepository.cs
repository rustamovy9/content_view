using WebAPI.Common.Base;
using WebAPI.Common.Base.BaseEntity;

namespace WebAPI.Common.Repositories.BaseRepository;

public interface IGenericAddRepository<T> where T : BaseEntity
{
    Task AddAsync(T value);
    Task AddRangeAsync(IEnumerable<T> value);
}