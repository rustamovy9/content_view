using WebAPI.Common.Base;
using WebAPI.Common.Base.BaseEntity;
using WebAPI.Common.DataAccess;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Moduls.Category.Entities;
using WebAPI.Moduls.Payment.Entities;
using WebAPI.Moduls.User.Entities;
using WebAPI.Moduls.Video.Entities;

namespace WebAPI.Common.UOW;

public class UnitOfWork<T> : IUnitOfWork<T> where T : BaseEntity
{
    private readonly AppCommandDbContext _appCommand;
    private readonly AppQueryDbContext _queryContext;
    
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


    public UnitOfWork(
            AppCommandDbContext appCommand,
            AppQueryDbContext queryContext, 
            
            IGenericUpdateRepository<User> userUpdateRepository, 
            IGenericDeleteRepository<User> userDeleteRepository, 
            IGenericFindRepository<User> userFindRepository, 
            IGenericAddRepository<User> userAddRepository,
            
            IGenericUpdateRepository<Payment> paymentUpdateRepository, 
            IGenericDeleteRepository<Payment> paymentDeleteRepository, 
            IGenericFindRepository<Payment> paymentFindRepository, 
            IGenericAddRepository<Payment> paymentAddRepository,
            
            IGenericUpdateRepository<Category> categoryUpdateRepository, 
            IGenericDeleteRepository<Category> categoryDeleteRepository, 
            IGenericFindRepository<Category> categoryFindRepository, 
            IGenericAddRepository<Category> categoryAddRepository,
            
            IGenericUpdateRepository<Video> videoUpdateRepository, 
            IGenericDeleteRepository<Video> videoDeleteRepository, 
            IGenericFindRepository<Video> videoFindRepository, 
            IGenericAddRepository<Video> videoAddRepository)  
    {
        _appCommand = appCommand;
        _queryContext = queryContext;
        
        UserUpdateRepository = userUpdateRepository;
        UserDeleteRepository = userDeleteRepository;
        UserFindRepository = userFindRepository;
        UserAddRepository = userAddRepository;
        
        CategoryUpdateRepository = categoryUpdateRepository;
        CategoryDeleteRepository = categoryDeleteRepository;
        CategoryFindRepository = categoryFindRepository;
        CategoryAddRepository = categoryAddRepository;
        
        PaymentUpdateRepository = paymentUpdateRepository;
        PaymentDeleteRepository = paymentDeleteRepository;
        PaymentFindRepository = paymentFindRepository;
        PaymentAddRepository = paymentAddRepository;
        
        VideoUpdateRepository = videoUpdateRepository;
        VideoDeleteRepository = videoDeleteRepository;
        VideoFindRepository = videoFindRepository;
        VideoAddRepository = videoAddRepository;
    }


    public async Task<int> Complete()
    {
        return await _appCommand.SaveChangesAsync();
    }

    public void Dispose()
    {
        _appCommand.Dispose();
        _queryContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _appCommand.DisposeAsync();
        await _queryContext.DisposeAsync();
    }
}
