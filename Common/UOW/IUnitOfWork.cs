using WebAPI.Common.Base;
using WebAPI.Common.Base.BaseEntity;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Moduls.Category.Entities;
using WebAPI.Moduls.Payment.Entities;
using WebAPI.Moduls.User.Entities;
using WebAPI.Moduls.Video.Entities;

namespace WebAPI.Common.UOW;

public interface IUnitOfWork<T> : IDisposable,IAsyncDisposable where T : BaseEntity
{
    public IGenericUpdateRepository<User> UserUpdateRepository { get; }
    public IGenericDeleteRepository<User> UserDeleteRepository { get; }
    public IGenericFindRepository<User> UserFindRepository { get; }
    public IGenericAddRepository<User> UserAddRepository { get; }
    
    public IGenericUpdateRepository<Category> CategoryUpdateRepository { get; }
    public IGenericDeleteRepository<Category> CategoryDeleteRepository { get; }
    public IGenericFindRepository<Category> CategoryFindRepository { get; }
    public IGenericAddRepository<Category> CategoryAddRepository { get; }
    
    
    public IGenericUpdateRepository<Payment> PaymentUpdateRepository { get; }
    public IGenericDeleteRepository<Payment> PaymentDeleteRepository { get; }
    public IGenericFindRepository<Payment> PaymentFindRepository { get; }
    public IGenericAddRepository<Payment> PaymentAddRepository { get; }
    
    public IGenericUpdateRepository<Video> VideoUpdateRepository { get; }
    public IGenericDeleteRepository<Video> VideoDeleteRepository { get; }
    public IGenericFindRepository<Video> VideoFindRepository { get; }
    public IGenericAddRepository<Video> VideoAddRepository { get; }

   
    Task<int> Complete();
}