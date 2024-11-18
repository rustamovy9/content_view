namespace WebAPI.Common.Base.BaseDTO_s;

public readonly record struct VideoBaseInfo(
    string Title,
    string Description,
    decimal Price,
    bool IsPaid,
    int CategoryId);
