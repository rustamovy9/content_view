using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;

namespace WebAPI.Moduls.User.ViewModels;

public record UserUpdateInfo : IRequest<BaseResult>
{
    public int Id { get; set; }
    public string UserName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Phone { get; init; } = null!;
    public IFormFile? File { get; set; }
}