using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Category.Extensions.Mappers;
using WebAPI.Moduls.Category.ViewModels;

namespace WebAPI.Moduls.Category.Handlers.CommandHandler;

public class UpdateCategoryHandler(IUnitOfWork<Entities.Category> unitOfWork) : IRequestHandler<CategoryUpdateInfo,BaseResult>
{
    public async Task<BaseResult> Handle(CategoryUpdateInfo request, CancellationToken cancellationToken)
    {
        IGenericUpdateRepository<Entities.Category> repository = unitOfWork.CategoryUpdateRepository;
        IGenericFindRepository<Entities.Category> findRepository = unitOfWork.CategoryFindRepository;
        
        Entities.Category? category = await findRepository.GetByIdAsync(request.Id);
        if(category is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));;
        
        
        bool conflict = (await findRepository.FindAsync(x =>
            x.Name.ToLower().
                Contains(request.CategoryBaseInfo.CategoryName.ToLower()))).Any();
        if(conflict)
            return BaseResult.Failure(Error.AlreadyExist("ooops! conflict🤷‍♂️🤷‍♂️"));

        
        await repository.UpdateAsync(category.ToUpdate(request));
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("oops...!!! Data is not updated🤷‍♂️🤷‍♂️"))
             : BaseResult.Success();
    }
}