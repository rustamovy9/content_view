using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;

namespace WebAPI.Moduls.Payment.ViewModels;

public readonly record struct PaymentDelete(int Id) : IRequest<BaseResult>;
