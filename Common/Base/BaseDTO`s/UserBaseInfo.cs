namespace WebAPI.Common.Base.BaseDTO_s;

public readonly record struct UserBaseInfo(
    string UserName,
    string Email,
    string PhoneNumber);