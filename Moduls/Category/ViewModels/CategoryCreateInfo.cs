using MediatR;
using WebAPI.Common.Base.BaseDTO_s;
using WebAPI.Common.Extensions.PatternResultExtensions;

namespace WebAPI.Moduls.Category.ViewModels;

public readonly record struct CategoryCreateDto(CategoryBaseInfo CategoryBaseInfo) : IRequest<BaseResult>;
