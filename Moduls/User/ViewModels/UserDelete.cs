using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;

namespace WebAPI.Moduls.User.ViewModels;

public readonly record struct UserDelete(int Id) : IRequest<BaseResult>;
