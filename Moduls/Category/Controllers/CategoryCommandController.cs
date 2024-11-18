using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.Controllers;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Moduls.Category.ViewModels;

namespace WebAPI.Moduls.Category.Controllers;

[Route("api/categories")]
public sealed class CategoryCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CategoryCreateDto user)
    {
        BaseResult result = await sender.Send(user);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CategoryUpdateInfo user)
    {
        BaseResult result = await sender.Send(user);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new CategoryDelete(id));
        return result.ToActionResult();
    }
}