using FluentValidation;
using WebAPI.Moduls.User.ViewModels;

namespace WebAPI.Moduls.User.Validations;

public sealed class UserUpdateValidator : AbstractValidator<UserUpdateInfo>
{
    public UserUpdateValidator()
    {
        
        RuleFor(user => user.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .Length(4, 30).WithMessage("Username must be between 4 and 30 characters.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email address is required.")
            .EmailAddress().WithMessage("Invalid email address format.")
            .Length(4, 50).WithMessage("Email address must be between 4 and 50 characters.");

        RuleFor(user => user.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+992\d{9}$").WithMessage("Phone number must start with +992 and be followed by 9 digits.");
        

    }
    
}