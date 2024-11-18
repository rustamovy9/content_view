using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.FileService;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.User.Mappers;
using WebAPI.Moduls.User.ViewModels;

namespace WebAPI.Moduls.User.Handlers.CommandHandler;

public sealed class CreateUserHandler(IUnitOfWork<Entities.User> unitOfWork,IFileService fileService) : IRequestHandler<UserCreateDto,BaseResult>
{
    public async Task<BaseResult> Handle(UserCreateDto request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<Entities.User> repository = unitOfWork.UserAddRepository;
        IGenericFindRepository<Entities.User> findRepository = unitOfWork.UserFindRepository;
        
        bool conflict = (await findRepository.FindAsync(x =>
                x.UserName.ToLower().
                    Contains(request.UserName.ToLower()) || 
                x.Email.ToLower().Contains(request.Email.ToLower()) || 
                x.Phone.ToLower().Contains(request.Phone))).Any();
        if(conflict)
            return BaseResult.Failure(Error.AlreadyExist("ooops! conflict🤷‍♂️🤷‍♂️"));
        

        await repository.AddAsync(await request.ToUser(fileService));
        int res = await unitOfWork.Complete();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops...!!! Data not saved🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}