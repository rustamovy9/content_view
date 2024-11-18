using System.Linq.Expressions;
using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.Responses;
using WebAPI.Common.UOW;
using WebAPI.Moduls.User.Mappers;
using WebAPI.Moduls.User.ViewModels;

namespace WebAPI.Moduls.User.Handlers.QueryHendler;

public sealed class GetUsersHandler(IUnitOfWork<Entities.User> unitOfWork) : IRequestHandler<GetUserVmRequest, Result<PagedResponse<IEnumerable<UserReadInfo>>>>
{

    public async Task<Result<PagedResponse<IEnumerable<UserReadInfo>>>> Handle(GetUserVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Entities.User> repository = unitOfWork.UserFindRepository;

        Expression<Func<Entities.User, bool>> filterExpression = user =>
            (string.IsNullOrEmpty(request.Filter.UserName) || user.UserName.ToLower().Contains(request.Filter.UserName.ToLower())) &&
            (string.IsNullOrEmpty(request.Filter.Phone) || user.Phone.ToLower().Contains(request.Filter.Phone.ToLower()));

        IEnumerable<Entities.User> query = (await repository
            .FindAsync(filterExpression)).ToList(); 
        
        int totalRecords =  query.Count();
        
        IEnumerable<UserReadInfo> result =  query
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize)
            .Select(x => x.ToReadInfo()).ToList();
        

        PagedResponse<IEnumerable<UserReadInfo>> response = PagedResponse<IEnumerable<UserReadInfo>>.Create(
            request.Filter.PageNumber, 
            request.Filter.PageSize, 
            totalRecords, 
            result
        );

        return Result<PagedResponse<IEnumerable<UserReadInfo>>>.Success(response);
    }
}
