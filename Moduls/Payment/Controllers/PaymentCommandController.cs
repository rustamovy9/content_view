using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.Controllers;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Moduls.Payment.ViewModels;

namespace WebAPI.Moduls.Payment.Controllers;

[Route("api/payments")]
public sealed class PaymentCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PaymentCreateDto payment)
    {
        BaseResult result = await sender.Send(payment);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PaymentUpdateInfo payment)
    {
        BaseResult result = await sender.Send(payment);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new PaymentDelete(id));
        return result.ToActionResult();
    }
}