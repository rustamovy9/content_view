using MediatR;
using WebAPI.Common.Base.BaseDTO_s;
using WebAPI.Common.Extensions.PatternResultExtensions;

namespace WebAPI.Moduls.Payment.ViewModels;

public readonly record struct PaymentUpdateInfo(int Id, PaymentBaseInfo PaymentBaseInfo) : IRequest<BaseResult>;
