using FluentValidation;
using WebAPI.Moduls.Category.ViewModels;

namespace WebAPI.Moduls.Category.Validations;

public class CreateCategoryValidator : AbstractValidator<CategoryCreateDto>
{
    public CreateCategoryValidator()
    {

        
        RuleFor(ca => ca.CategoryBaseInfo.CategoryName)
            .NotEmpty().WithMessage("CategoryName is required.")
            .Length(4, 30).WithMessage("CategoryName must be between 4 and 30 characters.");
        
    }
}