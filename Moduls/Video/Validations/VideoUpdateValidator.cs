using FluentValidation;
using WebAPI.Moduls.Video.ViewModels;

namespace WebAPI.Moduls.Video.Validations;

public sealed class VideoUpdateValidator : AbstractValidator<VideoUpdateInfo>
{
    public VideoUpdateValidator()
    {

        RuleFor(v => v.Title)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Title is required and should not exceed 200 characters.");

        RuleFor(v => v.Description)
            .NotEmpty()
            .MaximumLength(1000)
            .WithMessage("Description is required and should not exceed 1000 characters.");


        RuleFor(v => v.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price cannot be negative.");

        RuleFor(v => v.CategoryId)
            .GreaterThan(0)
            .WithMessage("CategoryId must be a valid ID.");
    }

}