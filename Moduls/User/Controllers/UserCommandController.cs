using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.Controllers;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Moduls.User.ViewModels;

namespace WebAPI.Moduls.User.Controllers;

[Route("api/users")]
public sealed class UserCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] UserCreateDto user)
    {
        BaseResult result = await sender.Send(user);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] UserUpdateInfo user)
    {
        BaseResult result = await sender.Send(user);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new UserDelete(id));
        return result.ToActionResult();
    }
}