using System.Linq.Expressions;
using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.Responses;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Category.Extensions.Mappers;
using WebAPI.Moduls.Category.ViewModels;

namespace WebAPI.Moduls.Category.Handlers.QueryHendler;

public sealed class GetCategoryHandler(IUnitOfWork<Entities.Category> unitOfWork) : IRequestHandler<GetCategoryVmRequest, Result<PagedResponse<IEnumerable<CategoryReadInfo>>>>
{

    public async Task<Result<PagedResponse<IEnumerable<CategoryReadInfo>>>> Handle(GetCategoryVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Entities.Category> repository = unitOfWork.CategoryFindRepository;

        Expression<Func<Entities.Category, bool>> filterExpression = ca =>
            (string.IsNullOrEmpty(request.Filter.CategoryName) || ca.Name.ToLower().Contains(request.Filter.CategoryName.ToLower()));

        IEnumerable<Entities.Category> query = (await repository
            .FindAsync(filterExpression)).ToList(); 
        
        int totalRecords =  query.Count();
        
        IEnumerable<CategoryReadInfo> result =  query
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize)
            .Select(x => x.ToReadInfo()).ToList();
        

        PagedResponse<IEnumerable<CategoryReadInfo>> response = PagedResponse<IEnumerable<CategoryReadInfo>>.Create(
            request.Filter.PageNumber, 
            request.Filter.PageSize, 
            totalRecords, 
            result
        );

        return Result<PagedResponse<IEnumerable<CategoryReadInfo>>>.Success(response);
    }
}
