using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.User.Mappers;
using WebAPI.Moduls.User.ViewModels;

namespace WebAPI.Moduls.User.Handlers.QueryHendler;

public class GetUserByIdHandler(IUnitOfWork<Entities.User> unitOfWork) : IRequestHandler<GetUserByIdVmRequest,Result<UserReadInfo>>
{
    public async Task<Result<UserReadInfo>> Handle(GetUserByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Entities.User>? repository = unitOfWork.UserFindRepository;
        Entities.User? user = await repository.GetByIdAsync(request.Id);
        return user is null
            ? Result<UserReadInfo>.Failure(Error.NotFound())
            : Result<UserReadInfo>.Success(user.ToReadInfo());
    }
}