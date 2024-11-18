using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.FileService;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.User.Mappers;
using WebAPI.Moduls.User.ViewModels;

namespace WebAPI.Moduls.User.Handlers.CommandHandler;

public class UpdateUserHandler(IUnitOfWork<Entities.User> unitOfWork,IFileService fileService) : IRequestHandler<UserUpdateInfo,BaseResult>
{
    public async Task<BaseResult> Handle(UserUpdateInfo request, CancellationToken cancellationToken)
    {
        IGenericUpdateRepository<Entities.User> repository = unitOfWork.UserUpdateRepository;
        IGenericFindRepository<Entities.User> findRepository = unitOfWork.UserFindRepository;
        
        Entities.User? user = await findRepository.GetByIdAsync(request.Id);
        if(user is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));;
        
        
        bool conflict = (await findRepository.FindAsync(x =>
            x.UserName.ToLower().
                Contains(request.UserName.ToLower()) || 
            x.Email.ToLower().Contains(request.Email.ToLower()) || 
            x.Phone.ToLower().Contains(request.Phone))).Any();
        if(conflict)
            return BaseResult.Failure(Error.AlreadyExist("ooops! conflict🤷‍♂️🤷‍♂️"));

        
        await repository.UpdateAsync(await user.ToUpdate(request,fileService));
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("oops...!!! Data is not updated🤷‍♂️🤷‍♂️"))
             : BaseResult.Success();
    }
}