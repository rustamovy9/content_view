using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;

namespace WebAPI.Moduls.Video.ViewModels;

public record VideoUpdateInfo : IRequest<BaseResult>
{
    public int Id { get; init; }
    public string Title { get; init; } = null!;
    public string Description { get; init; } = null!; 
    public decimal Price { get; init; } 
    public int CategoryId { get; init; } 
    public IFormFile? File { get; set; }
}