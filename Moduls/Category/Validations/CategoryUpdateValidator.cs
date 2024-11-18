using FluentValidation;
using WebAPI.Moduls.Category.ViewModels;

namespace WebAPI.Moduls.Category.Validations;

public sealed class CategoryUpdateValidator : AbstractValidator<CategoryUpdateInfo>
{
    public CategoryUpdateValidator()
    {
        
        RuleFor(ca => ca.CategoryBaseInfo.CategoryName)
            .NotEmpty().WithMessage("Username is required.")
            .Length(4, 30).WithMessage("Username must be between 4 and 30 characters.");

    }
    
}