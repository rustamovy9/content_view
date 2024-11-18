using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.FileService;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Video.Extensions.Mappers;
using WebAPI.Moduls.Video.ViewModels;

namespace WebAPI.Moduls.Video.Handlers.CommandHandler;

public class DeleteVideoHandler(IUnitOfWork<Entities.Video> unitOfWork,IFileService fileService) : IRequestHandler<VideoDelete,BaseResult>
{
    public async Task<BaseResult> Handle(VideoDelete request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<Entities.Video> repository = unitOfWork.VideoDeleteRepository;
        IGenericFindRepository<Entities.Video> findRepository = unitOfWork.VideoFindRepository;

        Entities.Video? video = await findRepository.GetByIdAsync(request.Id);
        if(video is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));

        await repository.RemoveAsync(video.ToDeleted(fileService));
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops! Data is not deleted🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}