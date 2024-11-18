using MediatR;
using WebAPI.Common.Base.BaseDTO_s;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Responses;
using WebAPI.Moduls.User.Filters;

namespace WebAPI.Moduls.User.ViewModels;

public readonly record struct UserReadInfo(
    int Id,
    UserBaseInfo UserBaseInfo,
    string Filename);
    
    
public record GetUserVmRequest(UserFilter Filter) : IRequest<Result<PagedResponse<IEnumerable<UserReadInfo>>>>;

public record GetUserByIdVmRequest(int Id) : IRequest<Result<UserReadInfo>>;