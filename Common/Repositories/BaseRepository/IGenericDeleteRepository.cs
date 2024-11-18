using WebAPI.Common.Base;
using WebAPI.Common.Base.BaseEntity;

namespace WebAPI.Common.Repositories.BaseRepository;

public interface IGenericDeleteRepository<T> where T : BaseEntity
{
    Task RemoveAsync(T value);
    Task RemoveRangeAsync(IEnumerable<T> value);
}