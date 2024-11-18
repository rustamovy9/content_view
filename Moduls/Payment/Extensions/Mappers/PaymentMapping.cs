using WebAPI.Moduls.Payment.ViewModels;

namespace WebAPI.Moduls.Payment.Extensions.Mappers;

public static class PaymentMapping
{
    public static PaymentReadInfo ToReadInfo(this Entities.Payment payment)
    {
        return new()
        {
            Id = payment.Id,
            PaymentBaseInfo = new()
            {
                UserId = payment.UserId,
                VideoId = payment.VideoId,
                Amount = payment.Amount,
                IsSuccessful = payment.IsSuccessful
            }
        };
    }

    public static Entities.Payment ToPayment(this PaymentCreateDto createInfo)
    {
        return new()
        {
            UserId = createInfo.PaymentBaseInfo.UserId,
            VideoId = createInfo.PaymentBaseInfo.VideoId,
            Amount = createInfo.PaymentBaseInfo.Amount,
            IsSuccessful = createInfo.PaymentBaseInfo.IsSuccessful
        };
    }

    public static Entities.Payment ToUpdate(this Entities.Payment payment,PaymentUpdateInfo updateInfo)
    {
       
        payment.UserId = updateInfo.PaymentBaseInfo.UserId;
        payment.VideoId = updateInfo.PaymentBaseInfo.VideoId;
        payment.Amount = updateInfo.PaymentBaseInfo.Amount;
        payment.IsSuccessful = updateInfo.PaymentBaseInfo.IsSuccessful;
        payment.Version++;
        payment.UpdatedAt = DateTime.UtcNow;
        return payment;
    }

    public static Entities.Payment ToDeleted(this Entities.Payment payment)
    {
        payment.IsDeleted = true;
        payment.DeletedAt = DateTime.UtcNow;
        payment.UpdatedAt = DateTime.UtcNow;
        payment.Version++;
        return payment;
    }
}