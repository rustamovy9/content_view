using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.FileService;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Video.Extensions.Mappers;
using WebAPI.Moduls.Video.ViewModels;

namespace WebAPI.Moduls.Video.Handlers.CommandHandler;

public class UpdateVideoHandler(IUnitOfWork<Entities.Video> unitOfWork,IFileService fileService) : IRequestHandler<VideoUpdateInfo,BaseResult>
{
    public async Task<BaseResult> Handle(VideoUpdateInfo request, CancellationToken cancellationToken)
    {
        IGenericUpdateRepository<Entities.Video> repository = unitOfWork.VideoUpdateRepository;
        IGenericFindRepository<Entities.Video> findRepository = unitOfWork.VideoFindRepository;
        
        Entities.Video? video = await findRepository.GetByIdAsync(request.Id);
        if(video is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));;
        

        
        await repository.UpdateAsync(await video.ToUpdate(request,fileService));
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("oops...!!! Data is not updated🤷‍♂️🤷‍♂️"))
             : BaseResult.Success();
    }
}