using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Category.Extensions.Mappers;
using WebAPI.Moduls.Category.ViewModels;

namespace WebAPI.Moduls.Category.Handlers.CommandHandler;

public sealed class CreateCategoryHandler(IUnitOfWork<Entities.Category> unitOfWork) : IRequestHandler<CategoryCreateDto,BaseResult>
{
    public async Task<BaseResult> Handle(CategoryCreateDto request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<Entities.Category> repository = unitOfWork.CategoryAddRepository;
        IGenericFindRepository<Entities.Category> findRepository = unitOfWork.CategoryFindRepository;
        
        bool conflict = (await findRepository.FindAsync(x =>
                x.Name.ToLower().
                    Contains(request.CategoryBaseInfo.CategoryName.ToLower()))).Any();
        if(conflict)
            return BaseResult.Failure(Error.AlreadyExist("ooops! conflict🤷‍♂️🤷‍♂️"));
        

        await repository.AddAsync( request.ToCategory());
        int res = await unitOfWork.Complete();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops...!!! Data not saved🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}