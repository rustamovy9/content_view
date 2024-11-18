using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Video.Extensions.Mappers;
using WebAPI.Moduls.Video.ViewModels;

namespace WebAPI.Moduls.Video.Handlers.QueryHendler;

public class GetVideoByIdHandler(IUnitOfWork<Entities.Video> unitOfWork) : IRequestHandler<GetVideoByIdVmRequest,Result<VideoReadInfo>>
{
    public async Task<Result<VideoReadInfo>> Handle(GetVideoByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Entities.Video>? repository = unitOfWork.VideoFindRepository;
        Entities.Video? video = await repository.GetByIdAsync(request.Id);
        return video is null
            ? Result<VideoReadInfo>.Failure(Error.NotFound())
            : Result<VideoReadInfo>.Success(video.ToReadInfo());
    }
}