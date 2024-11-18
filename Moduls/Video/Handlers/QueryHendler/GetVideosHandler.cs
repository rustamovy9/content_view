using System.Linq.Expressions;
using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.Responses;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Video.Extensions.Mappers;
using WebAPI.Moduls.Video.ViewModels;

namespace WebAPI.Moduls.Video.Handlers.QueryHendler;

public sealed class GetVideosHandler(IUnitOfWork<Entities.Video> unitOfWork) : IRequestHandler<GetVideoVmRequest, Result<PagedResponse<IEnumerable<VideoReadInfo>>>>
{

    public async Task<Result<PagedResponse<IEnumerable<VideoReadInfo>>>> Handle(GetVideoVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Entities.Video> repository = unitOfWork.VideoFindRepository;

        Expression<Func<Entities.Video, bool>> filterExpression = v =>
            (string.IsNullOrEmpty(request.Filter.Title) || v.Title.ToLower().Contains(request.Filter.Title.ToLower())) &&
            (string.IsNullOrEmpty(request.Filter.Description) || v.Description.ToLower().Contains(request.Filter.Description.ToLower())) && 
            (request.Filter.MinPrice == null || v.Price >= request.Filter.MinPrice ) &&
            (request.Filter.MinPrice == null || v.Price <= request.Filter.MaxPrice );

        IEnumerable<Entities.Video> query = (await repository
            .FindAsync(filterExpression)).ToList(); 
        
        int totalRecords =  query.Count();
        
        IEnumerable<VideoReadInfo> result =  query
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize)
            .Select(x => x.ToReadInfo()).ToList();
        

        PagedResponse<IEnumerable<VideoReadInfo>> response = PagedResponse<IEnumerable<VideoReadInfo>>.Create(
            request.Filter.PageNumber, 
            request.Filter.PageSize, 
            totalRecords, 
            result
        );

        return Result<PagedResponse<IEnumerable<VideoReadInfo>>>.Success(response);
    }
}
