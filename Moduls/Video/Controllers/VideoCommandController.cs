using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.Controllers;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Moduls.Video.ViewModels;

namespace WebAPI.Moduls.Video.Controllers;

[Route("api/video")]
public sealed class VideoCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] VideoCreateDto video)
    {
        BaseResult result = await sender.Send(video);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] VideoUpdateInfo video)
    {
        BaseResult result = await sender.Send(video);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new VideoDelete(id));
        return result.ToActionResult();
    }
}