using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Category.Extensions.Mappers;
using WebAPI.Moduls.Category.ViewModels;

namespace WebAPI.Moduls.Category.Handlers.CommandHandler;

public class DeleteCategoryHandler(IUnitOfWork<Entities.Category> unitOfWork) : IRequestHandler<CategoryDelete,BaseResult>
{
    public async Task<BaseResult> Handle(CategoryDelete request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<Entities.Category> repository = unitOfWork.CategoryDeleteRepository;
        IGenericFindRepository<Entities.Category> findRepository = unitOfWork.CategoryFindRepository;

        Entities.Category? category = await findRepository.GetByIdAsync(request.Id);
        if(category is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));

        await repository.RemoveAsync(category.ToDeleted());
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops! Data is not deleted🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}