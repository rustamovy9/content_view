using WebAPI.Common.Base;
using WebAPI.Common.Base.BaseEntity;

namespace WebAPI.Common.Repositories.BaseRepository;

public interface IGenericUpdateRepository<T> where T : BaseEntity
{
    Task UpdateAsync(T value);
    Task UpdateRangeAsync(IEnumerable<T> value);
}