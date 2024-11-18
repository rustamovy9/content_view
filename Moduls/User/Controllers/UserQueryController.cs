using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.Controllers;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Responses;
using WebAPI.Moduls.User.Filters;
using WebAPI.Moduls.User.ViewModels;

namespace WebAPI.Moduls.User.Controllers;

[Route("api/users")]
public sealed class UserQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] UserFilter filter)
    {
        Result<PagedResponse<IEnumerable<UserReadInfo>>> response = await sender.Send(new GetUserVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get( int id)
    {
        Result<UserReadInfo> response = await sender.Send(new GetUserByIdVmRequest(id));
        return response.ToActionResult();
    }
}