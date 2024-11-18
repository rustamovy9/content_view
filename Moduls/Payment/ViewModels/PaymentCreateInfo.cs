using MediatR;
using WebAPI.Common.Base.BaseDTO_s;
using WebAPI.Common.Extensions.PatternResultExtensions;

namespace WebAPI.Moduls.Payment.ViewModels;

public readonly record struct PaymentCreateDto(PaymentBaseInfo PaymentBaseInfo) : IRequest<BaseResult>;
