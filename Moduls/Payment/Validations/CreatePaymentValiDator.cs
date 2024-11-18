using FluentValidation;
using WebAPI.Moduls.Payment.ViewModels;

namespace WebAPI.Moduls.Payment.Validations;

public class CreatePaymentValidator : AbstractValidator<PaymentCreateDto>
{
    public CreatePaymentValidator()
    {

        RuleFor(p => p.PaymentBaseInfo.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be greater than 0.");

        RuleFor(p => p.PaymentBaseInfo.VideoId)
            .GreaterThan(0)
            .WithMessage("VideoId must be greater than 0.");

        RuleFor(p => p.PaymentBaseInfo.Amount)
            .GreaterThan(0)
            .WithMessage("Amount must be greater than 0.");

        RuleFor(p => p.PaymentBaseInfo.IsSuccessful)
            .Must((dto, isSuccessful) => !isSuccessful || dto.PaymentBaseInfo.Amount > 0)
            .WithMessage("If payment is marked as successful, Amount must be greater than 0.");
        
    }
}