using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.FileService;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.User.Mappers;
using WebAPI.Moduls.User.ViewModels;

namespace WebAPI.Moduls.User.Handlers.CommandHandler;

public class DeleteUserHandler(IUnitOfWork<Entities.User> unitOfWork,IFileService fileService) : IRequestHandler<UserDelete,BaseResult>
{
    public async Task<BaseResult> Handle(UserDelete request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<Entities.User> repository = unitOfWork.UserDeleteRepository;
        IGenericFindRepository<Entities.User> findRepository = unitOfWork.UserFindRepository;

        Entities.User? user = await findRepository.GetByIdAsync(request.Id);
        if(user is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));

        await repository.RemoveAsync(user.ToDeleted(fileService));
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops! Data is not deleted🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}