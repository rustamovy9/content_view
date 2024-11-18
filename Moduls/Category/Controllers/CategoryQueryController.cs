using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.Controllers;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Responses;
using WebAPI.Moduls.Category.Filters;
using WebAPI.Moduls.Category.ViewModels;

namespace WebAPI.Moduls.Category.Controllers;

[Route("api/categories")]
public sealed class CategoryQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] CategoryFilter filter)
    {
        Result<PagedResponse<IEnumerable<CategoryReadInfo>>> response = await sender.Send(new GetCategoryVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<CategoryReadInfo> response = await sender.Send(new GetCategoryByIdVmRequest(id));
        return response.ToActionResult();
    }
}