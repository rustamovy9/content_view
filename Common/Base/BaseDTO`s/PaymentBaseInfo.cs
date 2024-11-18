namespace WebAPI.Common.Base.BaseDTO_s;

public readonly record struct PaymentBaseInfo(
    int UserId,
    int VideoId,
    decimal Amount,
    bool IsSuccessful);