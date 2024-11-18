using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.Controllers;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Responses;
using WebAPI.Moduls.Payment.Filters;
using WebAPI.Moduls.Payment.ViewModels;

namespace WebAPI.Moduls.Payment.Controllers;

[Route("api/payments")]
public sealed class PaymentQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PaymentFilter filter)
    {
        Result<PagedResponse<IEnumerable<PaymentReadInfo>>> response = await sender.Send(new GetPaymentVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get( int id)
    {
        Result<PaymentReadInfo> response = await sender.Send(new GetPaymentByIdVmRequest(id));
        return response.ToActionResult();
    }
}