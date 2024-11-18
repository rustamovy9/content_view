using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.Controllers;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Responses;
using WebAPI.Moduls.Video.Filters;
using WebAPI.Moduls.Video.ViewModels;

namespace WebAPI.Moduls.Video.Controllers;

[Route("api/video")]
public sealed class VideoQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] VideoFilter filter)
    {
        Result<PagedResponse<IEnumerable<VideoReadInfo>>> response = await sender.Send(new GetVideoVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get( int id)
    {
        Result<VideoReadInfo> response = await sender.Send(new GetVideoByIdVmRequest(id));
        return response.ToActionResult();
    }
}