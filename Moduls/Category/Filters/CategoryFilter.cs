using WebAPI.Common.Base.BaseFilter;

namespace WebAPI.Moduls.Category.Filters;

public record CategoryFilter(string? CategoryName) : BaseFilter;