using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;

namespace WebAPI.Moduls.Video.ViewModels;

public readonly record struct VideoDelete(int Id) : IRequest<BaseResult>;
