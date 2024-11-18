using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;

namespace WebAPI.Moduls.Category.ViewModels;

public readonly record struct CategoryDelete(int Id) : IRequest<BaseResult>;
