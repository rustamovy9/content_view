using FluentValidation;
using WebAPI.Moduls.User.ViewModels;

namespace WebAPI.Moduls.User.Validations;

public class CreateUserValidator : AbstractValidator<UserCreateDto>
{
    public CreateUserValidator()
    {

        
        RuleFor(user => user.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .Length(4, 30).WithMessage("Username must be between 4 and 30 characters.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email address is required.")
            .EmailAddress().WithMessage("Invalid email address format.")
            .Length(4, 50).WithMessage("Email address must be between 4 and 50 characters.");

         RuleFor(user => user.Phone)
            .NotEmpty().WithMessage("Phone  is required.")
            .Length(13).WithMessage("Phone  must be exactly 13 characters.");


         RuleFor(x => x.Password)
             .NotEmpty().WithMessage("Password is required.")
             .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

         RuleFor(x => x.ConfirmPassword)
             .NotEmpty().WithMessage("Confirm Password is required.")
             .Equal(x => x.Password).WithMessage("Passwords do not match.");
        
    }
}