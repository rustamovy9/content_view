using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.FileService;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Video.Extensions.Mappers;
using WebAPI.Moduls.Video.ViewModels;

namespace WebAPI.Moduls.Video.Handlers.CommandHandler;

public sealed class CreateVideoHandler(IUnitOfWork<Entities.Video> unitOfWork,IFileService fileService) : IRequestHandler<VideoCreateDto,BaseResult>
{
    public async Task<BaseResult> Handle(VideoCreateDto request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<Entities.Video> repository = unitOfWork.VideoAddRepository;
        

        await repository.AddAsync(await request.ToVideo(fileService));
        int res = await unitOfWork.Complete();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops...!!! Data not saved🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}