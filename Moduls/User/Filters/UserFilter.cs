using WebAPI.Common.Base.BaseFilter;

namespace WebAPI.Moduls.User.Filters;

public record UserFilter(string? UserName,string? Phone) : BaseFilter;