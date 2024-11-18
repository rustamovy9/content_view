using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;

namespace WebAPI.Moduls.User.ViewModels;

public record  UserCreateDto : IRequest<BaseResult>
{ 
    public string UserName { get; init; } = null!;
    public string Email { get; init; } = null!; 
    public string Phone { get; init; } = null!; 
    public string Password { get; init; } = null!; 
    public string ConfirmPassword { get; init; } = null!; 
    public IFormFile? File { get; set; }
}