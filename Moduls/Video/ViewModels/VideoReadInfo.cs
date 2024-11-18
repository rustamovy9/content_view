using MediatR;
using WebAPI.Common.Base.BaseDTO_s;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Responses;
using WebAPI.Moduls.Video.Filters;

namespace WebAPI.Moduls.Video.ViewModels;

public readonly record struct VideoReadInfo(
    int Id,
    VideoBaseInfo VideoBaseInfo,
    string Filename);
    
    
public record GetVideoVmRequest(VideoFilter Filter) : IRequest<Result<PagedResponse<IEnumerable<VideoReadInfo>>>>;

public record GetVideoByIdVmRequest(int Id) : IRequest<Result<VideoReadInfo>>;

