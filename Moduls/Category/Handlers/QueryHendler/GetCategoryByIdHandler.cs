using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Category.Extensions.Mappers;
using WebAPI.Moduls.Category.ViewModels;

namespace WebAPI.Moduls.Category.Handlers.QueryHendler;

public class GetCategoryByIdHandler(IUnitOfWork<Entities.Category> unitOfWork) : IRequestHandler<GetCategoryByIdVmRequest,Result<CategoryReadInfo>>
{
    public async Task<Result<CategoryReadInfo>> Handle(GetCategoryByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Entities.Category>? repository = unitOfWork.CategoryFindRepository;
        Category.Entities.Category? category = await repository.GetByIdAsync(request.Id);
        return category is null
            ? Result<CategoryReadInfo>.Failure(Error.NotFound())
            : Result<CategoryReadInfo>.Success(category.ToReadInfo());
    }
}