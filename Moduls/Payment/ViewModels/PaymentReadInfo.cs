using MediatR;
using WebAPI.Common.Base.BaseDTO_s;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Responses;
using WebAPI.Moduls.Payment.Filters;

namespace WebAPI.Moduls.Payment.ViewModels;

public readonly record struct PaymentReadInfo(
    int Id,
    PaymentBaseInfo PaymentBaseInfo);


public record GetPaymentVmRequest(PaymentFilter Filter) : IRequest<Result<PagedResponse<IEnumerable<PaymentReadInfo>>>>;

public record GetPaymentByIdVmRequest(int Id) : IRequest<Result<PaymentReadInfo>>;