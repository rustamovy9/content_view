using MediatR;
using WebAPI.Common.Base.BaseDTO_s;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Responses;
using WebAPI.Moduls.Category.Filters;

namespace WebAPI.Moduls.Category.ViewModels;

public readonly record struct CategoryReadInfo(
    int Id,
    CategoryBaseInfo CategoryBaseInfo);
    
    
public record GetCategoryVmRequest(CategoryFilter Filter) : IRequest<Result<PagedResponse<IEnumerable<CategoryReadInfo>>>>;

public record GetCategoryByIdVmRequest(int Id) : IRequest<Result<CategoryReadInfo>>;